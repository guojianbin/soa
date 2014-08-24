﻿using ESB.Core.Entity;
using ESB.Core.Registry;
using ESB.Core.Rpc;
using ESB.Core.Util;
using NewLife.Configuration;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ESB.Core.Monitor
{
    /// <summary>
    /// 和监控中心的连接类：主要由注册中心和管理中心使用
    /// </summary>
    public class MonitorCenterClient
    {
        private CometClient m_CometClient = null;

        private static MonitorCenterClient m_Instance;

        public static MonitorCenterClient GetInstance()
        {
            if (m_Instance != null) return m_Instance;

            MonitorCenterClient mcClient = new MonitorCenterClient();

            Interlocked.CompareExchange<MonitorCenterClient>(ref m_Instance, mcClient, null);

            return m_Instance;
        }

        /// <summary>
        /// 监控中心消费者客户端
        /// </summary>
        /// <param name="esbProxy"></param>
        private MonitorCenterClient()
        {
        }

        /// <summary>
        /// 连接到监控中心
        /// </summary>
        /// <returns></returns>
        public void Connect(CometClientType ccType)
        {
            String uri = Config.GetConfig<String>("ESB.MonitorCenter");
            m_CometClient = new CometClient(uri, ccType);

            m_CometClient.OnReceiveNotify += m_CometClient_OnReceiveNotify;
            m_CometClient.Connect();
        }

        /// <summary>
        /// 接收注册中心的消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_CometClient_OnReceiveNotify(object sender, CometEventArgs e)
        {
            try
            {
                if (e.Type == CometEventType.ReceiveMessage)    // 接收到来自服务器的配置信息
                {
                    CometMessage rm = XmlUtil.LoadObjFromXML<CometMessage>(e.Response);

                    if (rm.Action == CometMessageAction.Publish)
                    {

                        List<ServiceMonitor> lstServiceMonitor = XmlUtil.LoadObjFromXML<List<ServiceMonitor>>(rm.MessageBody);

                        
                    }
                }
                else if (e.Type == CometEventType.Lost)     // 当和注册中心断开连接时
                {
                    Console.WriteLine("和监控中心断开连接。");
                }

            }
            catch (Exception ex)
            {
                XTrace.WriteLine("接收监控中心消息时发生错误：" + ex.ToString());
            }
        }
    }
}
