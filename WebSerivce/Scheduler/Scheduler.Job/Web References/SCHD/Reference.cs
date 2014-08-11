﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.18444 版自动生成。
// 
#pragma warning disable 1591

namespace JN.ESB.Scheduler.Job.SCHD {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SchedulerServiceSoap", Namespace="http://www.jn.com/ESB/Scheduler")]
    public partial class SchedulerService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AddEsbWebServcieSchedulerOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateEsbWebServcieSchedulerOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteEsbWebServcieSchedulerOperationCompleted;
        
        private System.Threading.SendOrPostCallback PauseQuartzWebServiceSchedulerOperationCompleted;
        
        private System.Threading.SendOrPostCallback ResumeQuartzWebServiceSchedulerOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddScheduleHistoryOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SchedulerService() {
            this.Url = global::JN.ESB.Scheduler.Job.Properties.Settings.Default.JN_ESB_Scheduler_Job_SCHD_SchedulerService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event AddEsbWebServcieSchedulerCompletedEventHandler AddEsbWebServcieSchedulerCompleted;
        
        /// <remarks/>
        public event UpdateEsbWebServcieSchedulerCompletedEventHandler UpdateEsbWebServcieSchedulerCompleted;
        
        /// <remarks/>
        public event DeleteEsbWebServcieSchedulerCompletedEventHandler DeleteEsbWebServcieSchedulerCompleted;
        
        /// <remarks/>
        public event PauseQuartzWebServiceSchedulerCompletedEventHandler PauseQuartzWebServiceSchedulerCompleted;
        
        /// <remarks/>
        public event ResumeQuartzWebServiceSchedulerCompletedEventHandler ResumeQuartzWebServiceSchedulerCompleted;
        
        /// <remarks/>
        public event AddScheduleHistoryCompletedEventHandler AddScheduleHistoryCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.jn.com/ESB/Scheduler/AddEsbWebServcieScheduler", RequestNamespace="http://www.jn.com/ESB/Scheduler", ResponseNamespace="http://www.jn.com/ESB/Scheduler", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddEsbWebServcieScheduler(ESB_SCHD scheduler, ESB_SCHD_EsbWS esbWS) {
            this.Invoke("AddEsbWebServcieScheduler", new object[] {
                        scheduler,
                        esbWS});
        }
        
        /// <remarks/>
        public void AddEsbWebServcieSchedulerAsync(ESB_SCHD scheduler, ESB_SCHD_EsbWS esbWS) {
            this.AddEsbWebServcieSchedulerAsync(scheduler, esbWS, null);
        }
        
        /// <remarks/>
        public void AddEsbWebServcieSchedulerAsync(ESB_SCHD scheduler, ESB_SCHD_EsbWS esbWS, object userState) {
            if ((this.AddEsbWebServcieSchedulerOperationCompleted == null)) {
                this.AddEsbWebServcieSchedulerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddEsbWebServcieSchedulerOperationCompleted);
            }
            this.InvokeAsync("AddEsbWebServcieScheduler", new object[] {
                        scheduler,
                        esbWS}, this.AddEsbWebServcieSchedulerOperationCompleted, userState);
        }
        
        private void OnAddEsbWebServcieSchedulerOperationCompleted(object arg) {
            if ((this.AddEsbWebServcieSchedulerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddEsbWebServcieSchedulerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.jn.com/ESB/Scheduler/UpdateEsbWebServcieScheduler", RequestNamespace="http://www.jn.com/ESB/Scheduler", ResponseNamespace="http://www.jn.com/ESB/Scheduler", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateEsbWebServcieScheduler(ESB_SCHD scheduler, ESB_SCHD_EsbWS esbWS) {
            this.Invoke("UpdateEsbWebServcieScheduler", new object[] {
                        scheduler,
                        esbWS});
        }
        
        /// <remarks/>
        public void UpdateEsbWebServcieSchedulerAsync(ESB_SCHD scheduler, ESB_SCHD_EsbWS esbWS) {
            this.UpdateEsbWebServcieSchedulerAsync(scheduler, esbWS, null);
        }
        
        /// <remarks/>
        public void UpdateEsbWebServcieSchedulerAsync(ESB_SCHD scheduler, ESB_SCHD_EsbWS esbWS, object userState) {
            if ((this.UpdateEsbWebServcieSchedulerOperationCompleted == null)) {
                this.UpdateEsbWebServcieSchedulerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateEsbWebServcieSchedulerOperationCompleted);
            }
            this.InvokeAsync("UpdateEsbWebServcieScheduler", new object[] {
                        scheduler,
                        esbWS}, this.UpdateEsbWebServcieSchedulerOperationCompleted, userState);
        }
        
        private void OnUpdateEsbWebServcieSchedulerOperationCompleted(object arg) {
            if ((this.UpdateEsbWebServcieSchedulerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateEsbWebServcieSchedulerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.jn.com/ESB/Scheduler/DeleteEsbWebServcieScheduler", RequestNamespace="http://www.jn.com/ESB/Scheduler", ResponseNamespace="http://www.jn.com/ESB/Scheduler", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteEsbWebServcieScheduler(string schedID) {
            this.Invoke("DeleteEsbWebServcieScheduler", new object[] {
                        schedID});
        }
        
        /// <remarks/>
        public void DeleteEsbWebServcieSchedulerAsync(string schedID) {
            this.DeleteEsbWebServcieSchedulerAsync(schedID, null);
        }
        
        /// <remarks/>
        public void DeleteEsbWebServcieSchedulerAsync(string schedID, object userState) {
            if ((this.DeleteEsbWebServcieSchedulerOperationCompleted == null)) {
                this.DeleteEsbWebServcieSchedulerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteEsbWebServcieSchedulerOperationCompleted);
            }
            this.InvokeAsync("DeleteEsbWebServcieScheduler", new object[] {
                        schedID}, this.DeleteEsbWebServcieSchedulerOperationCompleted, userState);
        }
        
        private void OnDeleteEsbWebServcieSchedulerOperationCompleted(object arg) {
            if ((this.DeleteEsbWebServcieSchedulerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteEsbWebServcieSchedulerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.jn.com/ESB/Scheduler/PauseQuartzWebServiceScheduler", RequestNamespace="http://www.jn.com/ESB/Scheduler", ResponseNamespace="http://www.jn.com/ESB/Scheduler", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void PauseQuartzWebServiceScheduler(string schedID) {
            this.Invoke("PauseQuartzWebServiceScheduler", new object[] {
                        schedID});
        }
        
        /// <remarks/>
        public void PauseQuartzWebServiceSchedulerAsync(string schedID) {
            this.PauseQuartzWebServiceSchedulerAsync(schedID, null);
        }
        
        /// <remarks/>
        public void PauseQuartzWebServiceSchedulerAsync(string schedID, object userState) {
            if ((this.PauseQuartzWebServiceSchedulerOperationCompleted == null)) {
                this.PauseQuartzWebServiceSchedulerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPauseQuartzWebServiceSchedulerOperationCompleted);
            }
            this.InvokeAsync("PauseQuartzWebServiceScheduler", new object[] {
                        schedID}, this.PauseQuartzWebServiceSchedulerOperationCompleted, userState);
        }
        
        private void OnPauseQuartzWebServiceSchedulerOperationCompleted(object arg) {
            if ((this.PauseQuartzWebServiceSchedulerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PauseQuartzWebServiceSchedulerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.jn.com/ESB/Scheduler/ResumeQuartzWebServiceScheduler", RequestNamespace="http://www.jn.com/ESB/Scheduler", ResponseNamespace="http://www.jn.com/ESB/Scheduler", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ResumeQuartzWebServiceScheduler(string schedID) {
            this.Invoke("ResumeQuartzWebServiceScheduler", new object[] {
                        schedID});
        }
        
        /// <remarks/>
        public void ResumeQuartzWebServiceSchedulerAsync(string schedID) {
            this.ResumeQuartzWebServiceSchedulerAsync(schedID, null);
        }
        
        /// <remarks/>
        public void ResumeQuartzWebServiceSchedulerAsync(string schedID, object userState) {
            if ((this.ResumeQuartzWebServiceSchedulerOperationCompleted == null)) {
                this.ResumeQuartzWebServiceSchedulerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnResumeQuartzWebServiceSchedulerOperationCompleted);
            }
            this.InvokeAsync("ResumeQuartzWebServiceScheduler", new object[] {
                        schedID}, this.ResumeQuartzWebServiceSchedulerOperationCompleted, userState);
        }
        
        private void OnResumeQuartzWebServiceSchedulerOperationCompleted(object arg) {
            if ((this.ResumeQuartzWebServiceSchedulerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ResumeQuartzWebServiceSchedulerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.jn.com/ESB/Scheduler/AddScheduleHistory", RequestNamespace="http://www.jn.com/ESB/Scheduler", ResponseNamespace="http://www.jn.com/ESB/Scheduler", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddScheduleHistory(ESB_SCHD_HISTORY history) {
            this.Invoke("AddScheduleHistory", new object[] {
                        history});
        }
        
        /// <remarks/>
        public void AddScheduleHistoryAsync(ESB_SCHD_HISTORY history) {
            this.AddScheduleHistoryAsync(history, null);
        }
        
        /// <remarks/>
        public void AddScheduleHistoryAsync(ESB_SCHD_HISTORY history, object userState) {
            if ((this.AddScheduleHistoryOperationCompleted == null)) {
                this.AddScheduleHistoryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddScheduleHistoryOperationCompleted);
            }
            this.InvokeAsync("AddScheduleHistory", new object[] {
                        history}, this.AddScheduleHistoryOperationCompleted, userState);
        }
        
        private void OnAddScheduleHistoryOperationCompleted(object arg) {
            if ((this.AddScheduleHistoryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddScheduleHistoryCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.jn.com/ESB/Scheduler")]
    public partial class ESB_SCHD {
        
        private string sCHD_IDField;
        
        private string tRIG_NAMEField;
        
        private string tRIG_GROUPField;
        
        private string sCHD_NAMEField;
        
        private string sCHD_DESCField;
        
        private string sTART_TIMEField;
        
        private string eND_TIMEField;
        
        private string sCHD_FREQField;
        
        private string sCHD_HOSTField;
        
        private string sCHD_TIMEField;
        
        private string sCHD_USERField;
        
        private string sCHD_CRONField;
        
        private string jOB_NAMEField;
        
        private ESB_SCHD_EsbWS[] eSB_SCHD_EsbWSField;
        
        private ESB_SCHD_HISTORY[] eSB_SCHD_HISTORYField;
        
        /// <remarks/>
        public string SCHD_ID {
            get {
                return this.sCHD_IDField;
            }
            set {
                this.sCHD_IDField = value;
            }
        }
        
        /// <remarks/>
        public string TRIG_NAME {
            get {
                return this.tRIG_NAMEField;
            }
            set {
                this.tRIG_NAMEField = value;
            }
        }
        
        /// <remarks/>
        public string TRIG_GROUP {
            get {
                return this.tRIG_GROUPField;
            }
            set {
                this.tRIG_GROUPField = value;
            }
        }
        
        /// <remarks/>
        public string SCHD_NAME {
            get {
                return this.sCHD_NAMEField;
            }
            set {
                this.sCHD_NAMEField = value;
            }
        }
        
        /// <remarks/>
        public string SCHD_DESC {
            get {
                return this.sCHD_DESCField;
            }
            set {
                this.sCHD_DESCField = value;
            }
        }
        
        /// <remarks/>
        public string START_TIME {
            get {
                return this.sTART_TIMEField;
            }
            set {
                this.sTART_TIMEField = value;
            }
        }
        
        /// <remarks/>
        public string END_TIME {
            get {
                return this.eND_TIMEField;
            }
            set {
                this.eND_TIMEField = value;
            }
        }
        
        /// <remarks/>
        public string SCHD_FREQ {
            get {
                return this.sCHD_FREQField;
            }
            set {
                this.sCHD_FREQField = value;
            }
        }
        
        /// <remarks/>
        public string SCHD_HOST {
            get {
                return this.sCHD_HOSTField;
            }
            set {
                this.sCHD_HOSTField = value;
            }
        }
        
        /// <remarks/>
        public string SCHD_TIME {
            get {
                return this.sCHD_TIMEField;
            }
            set {
                this.sCHD_TIMEField = value;
            }
        }
        
        /// <remarks/>
        public string SCHD_USER {
            get {
                return this.sCHD_USERField;
            }
            set {
                this.sCHD_USERField = value;
            }
        }
        
        /// <remarks/>
        public string SCHD_CRON {
            get {
                return this.sCHD_CRONField;
            }
            set {
                this.sCHD_CRONField = value;
            }
        }
        
        /// <remarks/>
        public string JOB_NAME {
            get {
                return this.jOB_NAMEField;
            }
            set {
                this.jOB_NAMEField = value;
            }
        }
        
        /// <remarks/>
        public ESB_SCHD_EsbWS[] ESB_SCHD_EsbWS {
            get {
                return this.eSB_SCHD_EsbWSField;
            }
            set {
                this.eSB_SCHD_EsbWSField = value;
            }
        }
        
        /// <remarks/>
        public ESB_SCHD_HISTORY[] ESB_SCHD_HISTORY {
            get {
                return this.eSB_SCHD_HISTORYField;
            }
            set {
                this.eSB_SCHD_HISTORYField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.jn.com/ESB/Scheduler")]
    public partial class ESB_SCHD_EsbWS {
        
        private string oIDField;
        
        private string sCHD_IDField;
        
        private System.Guid entityIDField;
        
        private string entityNameField;
        
        private System.Guid serviceIDField;
        
        private string serviceNameField;
        
        private string methodNameField;
        
        private string paramStringField;
        
        private string paramUrlField;
        
        private string passWordField;
        
        private ESB_SCHD eSB_SCHDField;
        
        /// <remarks/>
        public string OID {
            get {
                return this.oIDField;
            }
            set {
                this.oIDField = value;
            }
        }
        
        /// <remarks/>
        public string SCHD_ID {
            get {
                return this.sCHD_IDField;
            }
            set {
                this.sCHD_IDField = value;
            }
        }
        
        /// <remarks/>
        public System.Guid EntityID {
            get {
                return this.entityIDField;
            }
            set {
                this.entityIDField = value;
            }
        }
        
        /// <remarks/>
        public string EntityName {
            get {
                return this.entityNameField;
            }
            set {
                this.entityNameField = value;
            }
        }
        
        /// <remarks/>
        public System.Guid ServiceID {
            get {
                return this.serviceIDField;
            }
            set {
                this.serviceIDField = value;
            }
        }
        
        /// <remarks/>
        public string ServiceName {
            get {
                return this.serviceNameField;
            }
            set {
                this.serviceNameField = value;
            }
        }
        
        /// <remarks/>
        public string MethodName {
            get {
                return this.methodNameField;
            }
            set {
                this.methodNameField = value;
            }
        }
        
        /// <remarks/>
        public string ParamString {
            get {
                return this.paramStringField;
            }
            set {
                this.paramStringField = value;
            }
        }
        
        /// <remarks/>
        public string ParamUrl {
            get {
                return this.paramUrlField;
            }
            set {
                this.paramUrlField = value;
            }
        }
        
        /// <remarks/>
        public string PassWord {
            get {
                return this.passWordField;
            }
            set {
                this.passWordField = value;
            }
        }
        
        /// <remarks/>
        public ESB_SCHD ESB_SCHD {
            get {
                return this.eSB_SCHDField;
            }
            set {
                this.eSB_SCHDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.jn.com/ESB/Scheduler")]
    public partial class ESB_SCHD_HISTORY {
        
        private string oIDField;
        
        private string sCHD_IDField;
        
        private string bEGIN_TIMEField;
        
        private string eND_TIMEField;
        
        private int cALL_STATUSField;
        
        private string cALL_MEMOField;
        
        private ESB_SCHD eSB_SCHDField;
        
        /// <remarks/>
        public string OID {
            get {
                return this.oIDField;
            }
            set {
                this.oIDField = value;
            }
        }
        
        /// <remarks/>
        public string SCHD_ID {
            get {
                return this.sCHD_IDField;
            }
            set {
                this.sCHD_IDField = value;
            }
        }
        
        /// <remarks/>
        public string BEGIN_TIME {
            get {
                return this.bEGIN_TIMEField;
            }
            set {
                this.bEGIN_TIMEField = value;
            }
        }
        
        /// <remarks/>
        public string END_TIME {
            get {
                return this.eND_TIMEField;
            }
            set {
                this.eND_TIMEField = value;
            }
        }
        
        /// <remarks/>
        public int CALL_STATUS {
            get {
                return this.cALL_STATUSField;
            }
            set {
                this.cALL_STATUSField = value;
            }
        }
        
        /// <remarks/>
        public string CALL_MEMO {
            get {
                return this.cALL_MEMOField;
            }
            set {
                this.cALL_MEMOField = value;
            }
        }
        
        /// <remarks/>
        public ESB_SCHD ESB_SCHD {
            get {
                return this.eSB_SCHDField;
            }
            set {
                this.eSB_SCHDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void AddEsbWebServcieSchedulerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void UpdateEsbWebServcieSchedulerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void DeleteEsbWebServcieSchedulerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void PauseQuartzWebServiceSchedulerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void ResumeQuartzWebServiceSchedulerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void AddScheduleHistoryCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591