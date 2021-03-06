using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using NewLife.Log;
using NewLife.Reflection;
using NewLife.Threading;
using XCode.Code;
using XCode.Exceptions;
using NewLife.Configuration;

namespace XCode.DataAccessLayer
{
    /// <summary>数据访问层</summary>
    /// <remarks>
    /// 主要用于选择不同的数据库，不同的数据库的操作有所差别。
    /// 每一个数据库链接字符串，对应唯一的一个DAL实例。
    /// 数据库链接字符串可以写在配置文件中，然后在Create时指定名字；
    /// 也可以直接把链接字符串作为AddConnStr的参数传入。
    /// 每一个数据库操作都必须指定表名以用于管理缓存，空表名或*将匹配所有缓存
    /// </remarks>
    public partial class DAL
    {
        #region 创建函数
        /// <summary>构造函数</summary>
        /// <param name="connName">配置名</param>
        private DAL(String connName)
        {
            _ConnName = connName;

            if (!ConnStrs.ContainsKey(connName)) throw new XCodeException("请在使用数据库前设置[" + connName + "]连接字符串");

            ConnStr = ConnStrs[connName].ConnectionString;
            if (String.IsNullOrEmpty(ConnStr)) throw new XCodeException("请在使用数据库前设置[" + connName + "]连接字符串");

            //// 创建数据库访问对象的时候，就开始检查数据库架构
            //// 尽管这样会占用大量时间，但这种情况往往只存在于安装部署的时候
            //// 要尽可能的减少非安装阶段的时间占用
            //try
            //{
            //    //DatabaseSchema.Check(Db);
            //    SetTables();
            //}
            //catch (Exception ex)
            //{
            //    if (Debug) WriteLog(ex.ToString());
            //}
        }

        private static Dictionary<String, DAL> _dals = new Dictionary<String, DAL>(StringComparer.OrdinalIgnoreCase);
        /// <summary>创建一个数据访问层对象。</summary>
        /// <param name="connName">配置名，或链接字符串</param>
        /// <returns>对应于指定链接的全局唯一的数据访问层对象</returns>
        public static DAL Create(String connName)
        {
            if (String.IsNullOrEmpty(connName)) throw new ArgumentNullException("connName");

            DAL dal = null;
            if (_dals.TryGetValue(connName, out dal)) return dal;
            lock (_dals)
            {
                if (_dals.TryGetValue(connName, out dal)) return dal;

                ////检查数据库最大连接数授权。
                //if (License.DbConnectCount != _dals.Count + 1)
                //    License.DbConnectCount = _dals.Count + 1;

                dal = new DAL(connName);
                // 不用connName，因为可能在创建过程中自动识别了ConnName
                _dals.Add(dal.ConnName, dal);
            }

            return dal;
        }

        private static Object _connStrs_lock = new Object();
        private static Dictionary<String, ConnectionStringSettings> _connStrs;
        private static Dictionary<String, Type> _connTypes = new Dictionary<String, Type>(StringComparer.OrdinalIgnoreCase);
        /// <summary>链接字符串集合</summary>
        public static Dictionary<String, ConnectionStringSettings> ConnStrs
        {
            get
            {
                if (_connStrs != null) return _connStrs;
                lock (_connStrs_lock)
                {
                    if (_connStrs != null) return _connStrs;
                    Dictionary<String, ConnectionStringSettings> cs = new Dictionary<String, ConnectionStringSettings>(StringComparer.OrdinalIgnoreCase);

                    // 读取配置文件
                    ConnectionStringSettingsCollection css = GetConnectionStrings();
                    if (css != null && css.Count > 0)
                    {
                        foreach (ConnectionStringSettings set in css)
                        {
                            if (set.Name == "LocalSqlServer") continue;
                            if (set.Name == "LocalMySqlServer") continue;
                            if (String.IsNullOrEmpty(set.ConnectionString)) continue;
                            if (String.IsNullOrEmpty(set.ConnectionString.Trim())) continue;

                            Type type = DbFactory.GetProviderType(set.ConnectionString, set.ProviderName);
                            //if (type == null) throw new XCodeException("无法识别的提供者" + set.ProviderName + "！");
                            if (type == null) XTrace.WriteLine("无法识别{0}的提供者{1}！", set.Name, set.ProviderName);

                            cs.Add(set.Name, set);
                            _connTypes.Add(set.Name, type);
                        }
                    }
                    _connStrs = cs;
                }
                return _connStrs;
            }
        }

        /// <summary>
        /// Tony.2014.09.11
        /// 获取到连接字符串，如果配置了XCode.ConnConfigFile项则优先使用，否则使用ConnectionStrings节
        /// </summary>
        /// <returns></returns>
        private static ConnectionStringSettingsCollection GetConnectionStrings()
        {
            String connFile = Config.GetConfig<String>("XCode.ConnConfigFile");
            if (String.IsNullOrWhiteSpace(connFile))
            {
                return ConfigurationManager.ConnectionStrings;
            }
            else
            {
                ConnectionStringSettingsCollection cnsc = new ConnectionStringSettingsCollection();
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(connFile);

                    foreach (XmlNode conn in xmlDoc.SelectNodes("/connectionStrings/add"))
                    {
                        ConnectionStringSettings css = new ConnectionStringSettings();
                        css.Name = conn.Attributes["name"] == null ? String.Empty : conn.Attributes["name"].Value;
                        css.ConnectionString = conn.Attributes["connectionString"] == null ? String.Empty : conn.Attributes["connectionString"].Value;
                        css.ProviderName = conn.Attributes["providerName"] == null ? String.Empty : conn.Attributes["providerName"].Value;

                        cnsc.Add(css);
                    }
                }
                catch (Exception ex)
                {
                    XTrace.WriteLine("无法从XCode.ConnConfigFile配置节中获取到ConnectionStrings，异常详情：{0}", ex.ToString());
                }

                return cnsc;
            }
        }

        /// <summary>添加连接字符串</summary>
        /// <param name="connName">连接名</param>
        /// <param name="connStr">连接字符串</param>
        /// <param name="type">实现了IDatabase接口的数据库类型</param>
        /// <param name="provider">数据库提供者，如果没有指定数据库类型，则有提供者判断使用哪一种内置类型</param>
        public static void AddConnStr(String connName, String connStr, Type type, String provider)
        {
            if (String.IsNullOrEmpty(connName)) throw new ArgumentNullException("connName");

            if (type == null) type = DbFactory.GetProviderType(connStr, provider);
            if (type == null) throw new XCodeException("无法识别的提供者" + provider + "！");

            // 允许后来者覆盖前面设置过了的
            ConnectionStringSettings set = new ConnectionStringSettings(connName, connStr, provider);
            ConnStrs[connName] = set;
            _connTypes[connName] = type;
        }

        /// <summary>获取所有已注册的连接名</summary>
        /// <returns></returns>
        public static IEnumerable<String> GetNames() { return ConnStrs.Keys; }
        #endregion

        #region 属性
        private String _ConnName;
        /// <summary>连接名</summary>
        public String ConnName { get { return _ConnName; } }

        private Type _ProviderType;
        /// <summary>实现了IDatabase接口的数据库类型</summary>
        private Type ProviderType
        {
            get
            {
                if (_ProviderType == null && _connTypes.ContainsKey(ConnName)) _ProviderType = _connTypes[ConnName];
                return _ProviderType;
            }
        }

        /// <summary>数据库类型</summary>
        public DatabaseType DbType
        {
            get
            {
                var db = DbFactory.GetDefault(ProviderType);
                if (db == null) return DatabaseType.Other;
                return db.DbType;
            }
        }
        //public DatabaseType DbType { get { return Db.DbType; } }

        private String _ConnStr;
        /// <summary>连接字符串</summary>
        public String ConnStr
        {
            get { return _ConnStr; }
            set
            {
                if (_ConnStr != value)
                {
                    _ConnStr = value;
                    _Db = null;
                }
            }
        }

        private IDatabase _Db;
        /// <summary>数据库。所有数据库操作在此统一管理，强烈建议不要直接使用该属性，在不同版本中IDatabase可能有较大改变</summary>
        public IDatabase Db
        {
            get
            {
                if (_Db != null) return _Db;

                Type type = ProviderType;
                if (type != null)
                {
                    //_Db = TypeX.CreateInstance(type) as IDatabase;
                    // 使用鸭子类型，避免因接口版本差异而导致无法使用
                    _Db = TypeX.ChangeType<IDatabase>(TypeX.CreateInstance(type));
                    // 不为空才设置连接字符串，因为可能有内部包装
                    if (!String.IsNullOrEmpty(ConnName)) _Db.ConnName = ConnName;
                    if (!String.IsNullOrEmpty(ConnStr)) _Db.ConnectionString = DecodeConnStr(ConnStr);
                }

                return _Db;
            }
        }

        /// <summary>数据库会话</summary>
        public IDbSession Session { get { return Db.CreateSession(); } }
        #endregion

        #region 连接字符串编码解码
        /// <summary>连接字符串编码</summary>
        /// <remarks>明文=>UTF8字节=>Base64</remarks>
        /// <param name="connstr"></param>
        /// <returns></returns>
        public static String EncodeConnStr(String connstr)
        {
            if (String.IsNullOrEmpty(connstr)) return connstr;

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(connstr));
        }

        /// <summary>连接字符串解码</summary>
        /// <remarks>Base64=>UTF8字节=>明文</remarks>
        /// <param name="connstr"></param>
        /// <returns></returns>
        static String DecodeConnStr(String connstr)
        {
            if (String.IsNullOrEmpty(connstr)) return connstr;

            // 如果包含任何非Base64编码字符，直接返回
            foreach (Char c in connstr)
            {
                if (!(c >= 'a' && c <= 'z' ||
                    c >= 'A' && c <= 'Z' ||
                    c >= '0' && c <= '9' ||
                    c == '+' || c == '/' || c == '=')) return connstr;
            }
            //if (!connstr.Any(c => !(c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c >= '0' && c <= '9' || c == '+' || c == '\\' || c == '='))) return connstr;

            Byte[] bts = null;
            try
            {
                // 尝试Base64解码，如果解码失败，估计就是连接字符串，直接返回
                bts = Convert.FromBase64String(connstr);
            }
            catch { return connstr; }

            return Encoding.UTF8.GetString(bts);
        }
        #endregion

        #region 正向工程
        private List<IDataTable> _Tables;
        /// <summary>取得所有表和视图的构架信息，为了提高性能，得到的只是准实时信息，可能会有1秒到3秒的延迟</summary>
        /// <remarks>如果不存在缓存，则获取后返回；否则使用线程池线程获取，而主线程返回缓存</remarks>
        /// <returns></returns>
        public List<IDataTable> Tables
        {
            get
            {
                // 如果不存在缓存，则获取后返回；否则使用线程池线程获取，而主线程返回缓存
                if (_Tables == null)
                    _Tables = GetTables();
                else
                    ThreadPool.QueueUserWorkItem(delegate(Object state) { _Tables = GetTables(); });

                return _Tables;
            }
        }

        private List<IDataTable> GetTables()
        {
            CheckBeforeUseDatabase();
            return Db.CreateMetaData().GetTables();
        }

        /// <summary>导出模型</summary>
        /// <returns></returns>
        public String Export()
        {
            var list = Tables;

            if (list == null || list.Count < 1) return null;

            return Export(list);
        }

        /// <summary>导出模型</summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        public static String Export(IEnumerable<IDataTable> tables)
        {
            return ModelHelper.ToXml(tables);
        }

        /// <summary>导入模型</summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static List<IDataTable> Import(String xml)
        {
            if (String.IsNullOrEmpty(xml)) return null;

            return ModelHelper.FromXml(xml, CreateTable);
        }
        #endregion

        #region 反向工程
        Int32 _hasCheck;
        void CheckBeforeUseDatabase()
        {
            if (_hasCheck > 0 || Interlocked.CompareExchange(ref _hasCheck, 1, 0) > 0) return;

            try
            {
                //DatabaseSchema.Check(Db);
                SetTables();
            }
            catch (Exception ex)
            {
                if (Debug) WriteLog(ex.ToString());
            }
        }

        /// <summary>反向工程。检查所有采用当前连接的实体类的数据表架构</summary>
        private void SetTables()
        {
            if (!NegativeEnable || NegativeExclude.Contains(ConnName)) return;

            // NegativeCheckOnly设置为true时，使用异步方式检查，因为上级的意思是不大关心数据库架构
            if (!NegativeCheckOnly)
                CheckTables();
            else
                ThreadPoolX.QueueUserWorkItem(CheckTables);
        }

        internal List<String> HasCheckTables = new List<String>();

        /// <summary>检查数据表架构，不受反向工程启用开关限制</summary>
        public void CheckTables()
        {
            WriteLog("开始检查连接[{0}/{1}]的数据库架构……", ConnName, DbType);

            var sw = new Stopwatch();
            sw.Start();

            try
            {
                var list = EntityFactory.GetTables(ConnName);
                if (list != null && list.Count > 0)
                {
                    // 全都标为已初始化的
                    foreach (var item in list)
                    {
                        if (!HasCheckTables.Contains(item.Name)) HasCheckTables.Add(item.Name);
                    }

                    // 过滤掉被排除的表名
                    if (NegativeExclude.Count > 0)
                    {
                        for (int i = list.Count - 1; i >= 0; i--)
                        {
                            if (NegativeExclude.Contains(list[i].Name)) list.RemoveAt(i);
                        }
                    }
                    // 过滤掉视图
                    list.RemoveAll(dt => dt.IsView);
                    if (list != null && list.Count > 0)
                    {
                        WriteLog(ConnName + "待检查表架构的实体个数：" + list.Count);

                        SetTables(list.ToArray());
                    }
                }
            }
            finally
            {
                sw.Stop();

                WriteLog("检查连接[{0}/{1}]的数据库架构耗时{2}", ConnName, DbType, sw.Elapsed);
            }
        }

        /// <summary>在当前连接上检查指定数据表的架构</summary>
        /// <param name="tables"></param>
        public void SetTables(params IDataTable[] tables)
        {
            var set = new NegativeSetting();
            set.CheckOnly = DAL.NegativeCheckOnly;
            set.NoDelete = DAL.NegativeNoDelete;
            //if (set.CheckOnly && DAL.Debug) WriteLog("XCode.Negative.CheckOnly设置为True，只是检查不对数据库进行操作");
            //if (set.NoDelete && DAL.Debug) WriteLog("XCode.Negative.NoDelete设置为True，不会删除数据表多余字段");
            Db.CreateMetaData().SetTables(set, tables);
        }
        #endregion

        #region 创建数据操作实体
        private EntityAssembly _Assembly;
        /// <summary>根据数据模型动态创建的程序集。带缓存，如果要更新，建议调用<see cref="EntityAssembly.Create(string, string, System.Collections.Generic.List&lt;XCode.DataAccessLayer.IDataTable&gt;)"/></summary>
        public EntityAssembly Assembly
        {
            get
            {
                return _Assembly ?? (_Assembly = EntityAssembly.CreateWithCache(ConnName, Tables));
            }
            set { _Assembly = value; }
        }

        /// <summary>创建实体操作接口</summary>
        /// <remarks>因为只用来做实体操作，所以只需要一个实例即可</remarks>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IEntityOperate CreateOperate(String tableName)
        {
            //var asm = EntityAssembly.Create(ConnName, Tables);
            var asm = Assembly;
            if (asm == null) return null;
            //Type type = TypeX.GetType(asm, tableName);
            //var type = AssemblyX.Create(asm).GetType(tableName);
            var type = asm.GetType(tableName);
            if (type == null)
                //return EntityFactory.CreateOperate(tableName);
                return null;
            else
                return EntityFactory.CreateOperate(type);
        }
        #endregion
    }
}