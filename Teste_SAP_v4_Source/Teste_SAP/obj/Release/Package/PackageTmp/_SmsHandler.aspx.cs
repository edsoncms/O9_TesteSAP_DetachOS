﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using OutSystems.ObjectKeys;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.SMS;

namespace ssTeste_SAP {
	public class SmsHandler: System.Web.UI.Page {

		public static SmsNode GetSmsEntry(HeContext heContext) {
			string largeaccount = heContext.MOMsg.LargeAccount;
			SmsNode wNode = null;
			foreach(ObjectKey nodeName in AppInfo.GetAppInfo().Tenant.GetPhoneNodes(largeaccount, Global.eSpaceId)) {
				return null;
				if (wNode.MatchTest(heContext)) return wNode;
			}
			return wNode;
		}

		public static SmsNode getState() {
			object state = null;
			try {
				state = HttpContext.Current.Session["state"];
			} catch {
				// Ignore errors deserializing ang get a new SmsEntry to restart the process in case of error
			}

			if (state == null) {
				state = (HttpContext.Current.Session["state"] = GetSmsEntry(AppInfo.GetAppInfo().OsContext));
			}
			return (SmsNode) state;
		}

		public static void setState(SmsNode newState) {
			HttpContext.Current.Session["state"] = newState;
		}


		private void Page_Load(object sender, System.EventArgs e) {
			HeContext heContext = Global.App.OsContext;
			// Session[\"Hits\"] = 1 + ( int) Session[\"Hits\"];
			bool processedOk = false;
			try {
				heContext.Session.TenantId = Convert.ToInt32(Request.QueryString["tenantid"]);
				if (heContext.MOMsg != null) {
					heContext.MOMsg = SmsUtils.BuildMsgFromRequest(Request);
				}
				AppUtils.DoOnMobileOriginatedMessage(heContext, ref heContext.MOMsg);
				Global.App.OsContext.Session.MSISDN = heContext.MOMsg.MSISDN;
				SmsLog.Write(DateTime.Now, heContext.AppInfo.eSpaceId, heContext.AppInfo.Tenant.Id, heContext.AppInfo.OsContext.Session.UserId, heContext.AppInfo.TenantPath, "", 0, "", heContext.MOMsg);
				handleRequest(heContext);
				processedOk = true;
			} finally {
				DatabaseAccess.FreeupResources(processedOk);
			}
			Response.End();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e) {
			// 
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			// 
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		public void handleRequest(HeContext heContext) {
			SmsNode currentNode;

			if (!NetworkInterfaceUtils.IsLoopbackAddress(Request.UserHostAddress)) {
				ErrorLog.LogApplicationError("Access denied from " + Request.UserHostAddress,
				 "I is only possible to access the smshandler from 127.0.0.1", heContext, "SmsHandler");
				return;
			}
			currentNode = getState();
			Response.Write("<html><head><meta HTTP-EQUIV=\"Pragma\" CONTENT=\"no-cache\"><title>SMS Message</title></head><body>");
			// Response.Write ("<p>Message: ("+heContext.MOMsg.Message+")</p>");
			if (heContext.MOMsg != null) {
				SmsNode res;
				bool matched;
				// Response.Write ("<p>Current State: "+currentNode.Key+"</p><hr/>");
				res = currentNode.Match(heContext);
				matched = (res != null);
				if (!matched && heContext.AppInfo.IsApplicationEnabled) {
					res = GetSmsEntry(heContext);
					if (res.Key != currentNode.Key) {
						res = res.Match(heContext);
						matched = (res != null);
					}
				}
				setState(res);
				Response.AddHeader("Matched", matched.ToString());
				if (res != null) {
					// Response.Write ("<hr/><p>Next State: "+res.Key+"</p>");
					if (res.ExpectedPatterns != "") {
						Response.AddHeader("ExpectedPatterns", res.ExpectedPatterns);
					}
				} else {
					// Response.Write ("<hr/><p>Next State is null</p>");
				}
			}
			// Response.Write ("<form name=\"form1\" method=\"get\"><input type=\"text\" name=\"message\"/><br/><input type=\"submit\" value=\"Send\"/></form>");
			// Response.Write ("<script type=\"text/javascript\"> document.form1.message.focus(); </script>");
		}
	}
}