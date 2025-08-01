﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Diagnostics;
using System.Xml.Serialization;
using System;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web;
using System.Net;
using System.Web.Services;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.HubEdition.RuntimePlatform.Sms;
using OutSystems.HubEdition.SMS;

namespace ssTeste_SAP {
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(Name="iSmsHandlerSoap", Namespace="http://tempuri.org/")]
	public class iSmsHandlerClient : System.Web.Services.Protocols.SoapHttpClientProtocol {
		private string _msisdn = "";
        
		public iSmsHandlerClient() {
		}

		public void SendSmsMessage (HeContext context, SmsNode node, string largeAccount, string msisdn) {
			string origLA = context.MOMsg.LargeAccount;
			string origMSISDN = context.MOMsg.MSISDN;
			context.MOMsg.LargeAccount = largeAccount;
			context.MOMsg.MSISDN = msisdn;
			context.Session["MSISDN"] = context.MOMsg.MSISDN;
			try {
				node.Execute (context);
			} finally {
				context.MOMsg.LargeAccount = origLA;
				context.MOMsg.MSISDN = origMSISDN;
				context.Session["MSISDN"] = context.MOMsg.MSISDN;
			}
		}
        
		public void SendInteractiveSmsMessage (SmsNode node, string largeAccount, string msisdn) {
			string sessionId = SmsUtils.BuildSession (largeAccount, msisdn);
			_msisdn = msisdn;

			this.Url = "http://127.0.0.1/" + Global.App.eSpaceName + "/" + sessionId + "/ismshandler.asmx";


			if ((HttpContext.Current.Session != null) && (sessionId == RuntimePlatformUtils.SessionPrefix + HttpContext.Current.Session.SessionID + RuntimePlatformUtils.SessionSuffix)) {

				// To make sure the session is not blocked, make an assynchronous request
				BeginSendInteractiveSms (node, largeAccount, msisdn, new AsyncCallback (SendInteractiveSmsResult), null);
			} else {
				SendInteractiveSms (node, largeAccount, msisdn);
			}
		}

		public void SendSmsResult(IAsyncResult target) {
			EndSendSms (target);
		}

		public void SendInteractiveSmsResult(IAsyncResult target) {
			EndSendInteractiveSms (target);
		}

		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendSms", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public int SendSms(SmsNode node, string largeAccount, string msisdn) {
			object[] results = this.Invoke("SendSms", new object[] {
																	   node,
																	   largeAccount,
																	   msisdn});
			return ((int)(results[0]));
		}
        
		public System.IAsyncResult BeginSendSms(SmsNode node, string largeAccount, string msisdn, System.AsyncCallback callback, object asyncState) {
			return this.BeginInvoke("SendSms", new object[] {
																node,
																largeAccount,
																msisdn}, callback, asyncState);
		}
        
		public int EndSendSms(System.IAsyncResult asyncResult) {
			object[] results = this.EndInvoke(asyncResult);
			return ((int)(results[0]));
		}
        
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendInteractiveSms", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public int SendInteractiveSms(SmsNode node, string largeAccount, string msisdn) {
			object[] results = this.Invoke("SendInteractiveSms", new object[] {
																				  node,
																				  largeAccount,
																				  msisdn});
			return ((int)(results[0]));
		}
        
		public System.IAsyncResult BeginSendInteractiveSms(SmsNode node, string largeAccount, string msisdn, System.AsyncCallback callback, object asyncState) {
			return this.BeginInvoke("SendSms", new object[] {
																node,
																largeAccount,
																msisdn}, callback, asyncState);
		}
        
		public int EndSendInteractiveSms(System.IAsyncResult asyncResult) {
			object[] results = this.EndInvoke(asyncResult);
			return ((int)(results[0]));
		}

		protected override WebRequest GetWebRequest( Uri uri) {
			WebRequest request = base.GetWebRequest( uri);
			request.Headers.Add( "MSISDN", _msisdn);
			return request;
		}
	}
}
