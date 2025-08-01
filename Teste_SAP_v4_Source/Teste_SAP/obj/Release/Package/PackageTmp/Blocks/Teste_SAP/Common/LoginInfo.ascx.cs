﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.HubEdition.RuntimePlatform.Email;
using OutSystems.HubEdition.WebWidgets;
using OutSystems.HubEdition.WebWidgets.Behaviors;
using OutSystems.RuntimeCommon;
using OutSystems.ObjectKeys;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Runtime.Serialization;
using System.Web.Caching;
using System.Text;


namespace ssTeste_SAP.Flows.FlowCommon {
	public abstract class WBlkLoginInfo: OSUserControl, IWebScreen, INegotiateTabIndexes, IAjaxNotifyEvent, INotifyTriggers, INotifySender {

		/// <summary>
		/// Delegate Definitions
		/// </summary>
		/// <summary>
		/// Custom Events Definitions
		/// </summary>
		/// <summary>
		/// Parameters and Local Variables Definitions
		/// </summary>
		/// <summary>
		/// Variable "True" if the Widget wt_If2
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.If wt_If2T;

		/// <summary>
		/// Variable "True" if the Widget wt_If2
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.If wt_If2F;
		protected OutSystems.HubEdition.WebWidgets.Container wt_Container5;
		/// <summary>
		/// Variable (wt_Link7) with Link component
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.HyperLink wt_Link7;
		/// <summary>
		/// Variable (wtLogoutLink) with Link component
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.LinkButton wtLogoutLink;
		private List<object> explicitChangedVariables = new List<object>();
		private bool _isRendering = false;
		public HeContext heContext;
		private static Hashtable htTabIndexGroups = new Hashtable();
		private Hashtable htTabIndexGroupsTI = new Hashtable();
		public string InstanceID;
		public string RuntimeID= "";
		public event EventHandler NotifyTriggered;
		private BlocksJavascript.JavascriptNode _javascriptNode;
		static WBlkLoginInfo() {
		}

		public void OnNotifyCalled(string message) {
			BindDelegatesIfNeeded();
			if (NotifyTriggered != null) {
				NotifyTriggered(this, new MsgEventArgs(message));
			}
		}

		override protected void OnInit(EventArgs e) {
			InitializeComponent();
			base.OnInit(e);
		}
		private void InitializeComponent() {
			if (this.wtLogoutLink != null) {
				this.wtLogoutLink.Click += new System.EventHandler(this.wtLogoutLink_Click);
			}
			this.Load += new System.EventHandler(this.Page_Load);
			this.Unload += new System.EventHandler(this.Page_Unload);
		}
		private void Page_Load(object sender, System.EventArgs e) {
			heContext = Global.App.OsContext;
			RuntimeID = ClientID;
			if (!Visible) return;
			int oldCurrentESpaceId = heContext.CurrentESpaceId;
			try {
				heContext.CurrentESpaceId = ssTeste_SAP.Global.eSpaceId;
				if (!IsPostBack || _isRendering) {
					// register this block in the page so for later outputting the block javascript includes in their correct order
					((OSPage) Page).RegisterBlock(this, out _javascriptNode);
					if (_isRendering) {
					}
					bool bindEditRecords = IsViewStateEmpty;
				} else {
					FetchViewState();
				}
			} finally {
				heContext.CurrentESpaceId = oldCurrentESpaceId;
			}

		}
		/// <summary>
		/// This method is called when there is a submit. So it should validate input values and call the
		///  correct system event user action if needed
		/// </summary>
		public void OnSubmit(string parentEditRecord, bool validate) {
			if (!WasRendered) {
				return;
			}
			CallOnSubmitOnChildren(Controls, parentEditRecord, validate);
		}
		public void CallOnSubmitOnChildren(ControlCollection children, string parentEditRecord, bool validate) {
			foreach(Control ctrl in children) {
				IWebScreen screen = ctrl as IWebScreen;

				if (screen != null) {
					screen.OnSubmit(parentEditRecord, validate);
				} else {
					CallOnSubmitOnChildren(ctrl.Controls, parentEditRecord, validate);
				}
			}
		}
		public short NegotiateTabIndexes(short tabindex, bool setTabIndex) {
			Control rootCtrl = this;
			if ((this.Controls.Count == 1) && (typeof(HtmlForm).IsInstanceOfType(this.Controls[0]))) {
				rootCtrl = this.Controls[0];
			} else {
				rootCtrl = this;
			}
			tabindex = NegotiateTabIndexesRecursively(tabindex, rootCtrl, setTabIndex);
			return tabindex;
		}

		public short NegotiateTabIndexesRecursively(short tabindex, Control rootCtrl, bool setTabIndex) {

			bool bAssignTabIndex = false;
			WebControl ctrl = null;
			HtmlControl htmlCtrl = null;
			foreach(Control child in rootCtrl.Controls) {
				if (child is INegotiateTabIndexes) {
					tabindex = ((INegotiateTabIndexes) child).NegotiateTabIndexes(tabindex, setTabIndex);
					continue;
				}
				if (typeof(WebControl).IsInstanceOfType(child)) {
					ctrl = (WebControl) child;
					bAssignTabIndex = false;
					if (ctrl is OutSystems.HubEdition.WebWidgets.TextBox | ctrl is OutSystems.HubEdition.WebWidgets.CheckBox | ctrl is OutSystems.HubEdition.WebWidgets.RadioButton | ctrl is OutSystems.HubEdition.WebWidgets.DropDownList) {

						bAssignTabIndex = true;
					} else if (ctrl is System.Web.UI.WebControls.LinkButton | ctrl is System.Web.UI.WebControls.Button | ctrl is System.Web.UI.WebControls.HyperLink | ctrl is System.Web.UI.WebControls.ListBox) {
						bAssignTabIndex = true;
					}
					else if (ctrl is PlaceholderContainer)
					{
						INegotiateTabIndexes placeholderOwner = (INegotiateTabIndexes) Utils.GetOwnerOfControl(ctrl);
						tabindex = placeholderOwner.NegotiateTabIndexesRecursively(tabindex, ctrl, setTabIndex);
						continue;
					}

					short settedTabIndex = 0;
					if (bAssignTabIndex && setTabIndex) {
						object b = htTabIndexGroups[ctrl.ID];
						if (b != null) {
							string groupid = b.ToString();
							if (htTabIndexGroupsTI[groupid] == null) {
								htTabIndexGroupsTI[groupid] = tabindex++;
							}
							ViewStateAttributes.SetTabIndex(ctrl, Convert.ToInt16(htTabIndexGroupsTI[groupid]), out settedTabIndex);
						} else {
							ViewStateAttributes.SetTabIndex(ctrl, tabindex, out settedTabIndex);
							// Increase tabindex if it was not overiden
							if (tabindex == settedTabIndex) {
								tabindex++;
							}
						}
					}
					tabindex = Math.Max(tabindex, ++settedTabIndex);
				} else if (child is HtmlControl && setTabIndex) {
					htmlCtrl = (HtmlControl) child;
					if (htmlCtrl is System.Web.UI.HtmlControls.HtmlInputFile) {
						htmlCtrl.Attributes.Add("tabIndex", Convert.ToString(tabindex++));
					}
				}
				if (child.Controls.Count > 0) {
					tabindex = NegotiateTabIndexesRecursively(tabindex, child, setTabIndex);
				}
			}
			return tabindex;
		}


		/// <summary>
		/// Store widget and variable data in the viewstate
		/// </summary>
		public override void StoreViewState() {
			base.StoreViewState();
			ViewStateAttributes.EnsureNotEmpty();
			((OSPageViewState) Page).RemoveStoreViewStateWebScreenStack(this);
		}
		/// <summary>
		/// Restore widget and variable data from the viewstate
		/// </summary>
		protected override void FetchViewState() {
			base.FetchViewState();
			if (IsViewStateEmpty) return;
			try {
			} catch (Exception e) {
				throw new Exception("Error Deserializing ViewState", e); 
			}
		}

		/// <summary>
		/// Store visibility information of the web block and input widgets in the viewstate
		/// </summary>
		protected override void StoreInputsAndWebBlockVisibility() {
			ViewStateAttributes.EnsureNotEmpty();
		}
		/// <summary>
		/// Restore visibility information of the web block and input widgets from the viewstate
		/// </summary>
		protected override void RestoreInputsAndWebBlockVisibility() {
			WasRendered = true;
		}

		private void Page_Unload(object sender, System.EventArgs e) {
		}

		public LocalState PushStack() {
			throw new NotImplementedException();
		}

		public void doRefreshScreen(HeContext heContext) {
			((IWebScreen) this.Page).doRefreshScreen(heContext);
		}

		public void doAJAXRefreshScreen(HeContext heContext) {
			StoreViewState();
			((IWebScreen) this.Page).doAJAXRefreshScreen(heContext);
		}

		public static void GetCss(TextWriter writer, bool inline, HashSet<string> visited) {
			string blockId = "Teste_SAP.KGxiSVdWauL5OYmSzn6P3Yw";
			if (visited.Contains(blockId)) {
				return; 
			}
			visited.Add(blockId);
			if (!inline) {
				GetCssIncludes(writer, visited);
			} else {
				GetInlineCss(writer, visited);
			}
		}

		private static void GetCssIncludes(TextWriter writer, HashSet<string> visited) {
			InnerGetCss(writer, false, visited);
		}

		private static void GetInlineCss(TextWriter writer, HashSet<string> visited) {
			StringWriter localCssWriter = new StringWriter();
			localCssWriter.NewLine = writer.NewLine;
			string localCss = Environment.NewLine;
			InnerGetCss(localCssWriter, true, visited);
			localCss += localCssWriter.ToString();
			writer.Write(localCss);
		}

		private static void InnerGetCss(TextWriter writer, bool inline, HashSet<string> visited) {
		}

		private void Page_Error(object sender, System.EventArgs e) {
		}
		public void CheckPermissions(HeContext heContext) {
			((IWebScreen) this.Page).CheckPermissions(heContext);
		}
		protected static string GetString(string key, string defaultValue) {
			return Global.GetStringResource(key, defaultValue);
		}

		public ObjectKey Key {
			get {
				return ObjectKey.Parse("GxiSVdWauL5OYmSzn6P3Yw"); 
			}
		}
		public bool isSecure {
			get {
				return ((IWebScreen) Page).isSecure; 
			}
		}
		/// <summary>
		/// Action <code>CommandLogout</code> that represents the Service Studio screen action
		///  <code>Logout</code> <p> Description: </p>
		/// </summary>
		private bool CommandLogout(HeContext heContext) {
			Global.App.Context.Items["osPassedOnAction"] = true;
			CheckPermissions(heContext);
			RequestTracer perfTracer = heContext.RequestTracer; if (perfTracer != null) {
				perfTracer.RegisterAction("ed8daf70-6a2a-461d-b09f-41f98f32ffd1", "LoginInfo.Logout"); 
			}
			// User_Logout
			Actions.ActionUser_Logout(heContext);
			Global.App.OsContext.Session["Teste_SAP.LoginRedirectURL"] = ""; // LoginRedirectURL = ""
			explicitChangedVariables.Add(((string) Global.App.OsContext.Session["Teste_SAP.LoginRedirectURL"]));
			// Destination = Login

			if (OSPage.IsAjaxRequest) {
				// go to target page
				{

					if ((!((IWebScreen) Page).isSecure || !RuntimePlatformUtils.RequestIsSecure(Request)) && (heContext.AppInfo.eSpaceId == Global.eSpaceId)) {
						((OSPage) Page).ClearErrorHandler();
						// get parameters
						heContext.Session["_ScreenParametersKey"] = "w6uCOokgH0mMnYac8X7WSw";
						ArrayList screenParameters = new ArrayList();
						Global.App.OsContext.Session["Teste_SAP._ScreenParameters_Login"] = screenParameters;
						string sURLQuery = null;
						sURLQuery = (sURLQuery == null ? "": "?" + sURLQuery);
						string sURL = GetRedirectionProtocol(Global.App.IsForcingSecurityForScreens(Global.eSpaceId)) + (EmailScreenUtils.SafeGetEmailHost(Page as IEmailScreen) ?? Request.Url.Host) + "" + AppUtils.Instance.getImagePath() + "Login.aspx" + sURLQuery;
						((OSPageViewState) Page).RedirectLocation = sURL;
						return false;

					} else {
						string sURLQuery = null;
						sURLQuery = (sURLQuery == null ? "": "?" + sURLQuery);
						string sURL = GetRedirectionProtocol(Global.App.IsForcingSecurityForScreens(Global.eSpaceId)) + (EmailScreenUtils.SafeGetEmailHost(Page as IEmailScreen) ?? Request.Url.Host) + "" + AppUtils.Instance.getImagePath() + "Login.aspx" + sURLQuery;
						((OSPage) Page).ClearErrorHandler();
						Response.BufferOutput = true;
						if (!OSPage.IsAjaxRequest) {
							Response.Redirect(sURL);
						} else {
							((OSPageViewState) Page).RedirectLocation = sURL;
						}
						return false;

					}
				}
			} else {
				// go to target page
				{

					if ((!((IWebScreen) Page).isSecure || !RuntimePlatformUtils.RequestIsSecure(Request)) && (heContext.AppInfo.eSpaceId == Global.eSpaceId)) {
						((OSPage) Page).ClearErrorHandler();
						// get parameters
						heContext.Session["_ScreenParametersKey"] = "w6uCOokgH0mMnYac8X7WSw";
						ArrayList screenParameters = new ArrayList();
						Global.App.OsContext.Session["Teste_SAP._ScreenParameters_Login"] = screenParameters;
						Server.Transfer("Login.aspx");
						return false;

					} else {
						// get parameters
						heContext.Session["_ScreenParametersKey"] = "w6uCOokgH0mMnYac8X7WSw";
						ArrayList screenParameters = new ArrayList();
						Global.App.OsContext.Session["Teste_SAP._ScreenParameters_Login"] = screenParameters;
						string sURLQuery = null;
						sURLQuery = (sURLQuery == null ? "": "?" + sURLQuery);
						string sURL = GetRedirectionProtocol(Global.App.IsForcingSecurityForScreens(Global.eSpaceId)) + (EmailScreenUtils.SafeGetEmailHost(Page as IEmailScreen) ?? Request.Url.Host) + "" + AppUtils.Instance.getImagePath() + "Login.aspx" + sURLQuery;
						((OSPage) Page).ClearErrorHandler();
						Response.BufferOutput = true;
						if (!OSPage.IsAjaxRequest) {
							Response.Redirect(sURL);
						} else {
							((OSPageViewState) Page).RedirectLocation = sURL;
						}
						return false;

					}
				}
			}
		}
		bool if_wt_If2_hasRun=false;
		bool if_wt_If2_evalResult;
		public bool if_wt_If2() {
			if (if_wt_If2_hasRun) {
				if_wt_If2_hasRun = false;
				return if_wt_If2_evalResult;
			}
			if_wt_If2_hasRun = true;
			if_wt_If2_evalResult = (((int) Global.App.OsContext.Session["UserID"]) !=BuiltInFunction.NullIdentifier());
			return if_wt_If2_evalResult;
		}

		public void cnt_Container5_onDataBinding(object sender, System.EventArgs e) {
			int oldCurrentESpaceId = heContext.CurrentESpaceId;
			try {
				heContext.CurrentESpaceId = ssTeste_SAP.Global.eSpaceId;
				cnt_Container5_setInlineAttributes(sender, e);
			} finally {
				heContext.CurrentESpaceId = oldCurrentESpaceId;
			}
		}
		public string cnt_Container5_setInlineAttributes(object sender, System.EventArgs e) {
			int oldCurrentESpaceId = heContext.CurrentESpaceId;
			try {
				heContext.CurrentESpaceId = ssTeste_SAP.Global.eSpaceId;
				if (!cnt_Container5_isVisible()) {
					string stylevalue = ((IAttributeAccessor) sender).GetAttribute("style");
					{
						string newstyledef;
						string oldstyledef;
						newstyledef = stylevalue + ((stylevalue!=null && !stylevalue.TrimEnd().EndsWith(";")) ? ";": "") + "display:none";
						oldstyledef = ((IAttributeAccessor) sender).GetAttribute("style");
						if (oldstyledef != null) {
							if (!oldstyledef.TrimEnd().EndsWith(";")) newstyledef = ";" + newstyledef;
							if (!oldstyledef.EndsWith(newstyledef)) {
								((IAttributeAccessor) sender).SetAttribute("style", oldstyledef + newstyledef.ToString());
							} else {
								((IAttributeAccessor) sender).SetAttribute("style", oldstyledef.ToString());
							}
						} else {
							((IAttributeAccessor) sender).SetAttribute("style", newstyledef.ToString());
						}
					}
				} else {
					string stylevalue = ((IAttributeAccessor) sender).GetAttribute("style");
					if (stylevalue != null) {
						((IAttributeAccessor) sender).SetAttribute("style", stylevalue.Replace("display:none;", "").Replace("display:none", "").ToString());
					}
				}
				return "";
			} finally {
				heContext.CurrentESpaceId = oldCurrentESpaceId;
			}
		}
		/// <summary>
		/// Gets the visible state of component (wt_Container5)
		/// </summary>
		/// <returns>The Visible State of wt_Container5</returns>
		public bool cnt_Container5_isVisible() {
			int oldCurrentESpaceId = heContext.CurrentESpaceId;
			try {
				heContext.CurrentESpaceId = ssTeste_SAP.Global.eSpaceId;
				return true;
			} finally {
				heContext.CurrentESpaceId = oldCurrentESpaceId;
			}
		}

		/// <summary>
		/// Gets the Navigate URL for the link of variable (wt_Link7)
		/// </summary>
		/// <returns>The Navigate URL of the link variable (wt_Link7)</returns>
		public string lnk_Link7_NavigateUrl() {
			string navUrl = "";
			string urlParameter = AppInfo.GetAppInfo().GetURLParameter();

			if (heContext.AppInfo.eSpaceId != Global.eSpaceId || (this.Page is IEmailScreen) || ((IWebScreen) Page).isSecure) {
				navUrl = GetRedirectionProtocol(Global.App.IsForcingSecurityForScreens(Global.eSpaceId)) + (EmailScreenUtils.SafeGetEmailHost(Page as IEmailScreen) ?? Request.Url.Host) + "" + AppUtils.Instance.getImagePath();
			} else {
				string pageHeader = heContext.OsISAPIFilter.GetPage(Request);
				if (pageHeader != null && pageHeader.IndexOf('/', 1) != -1) {
					navUrl = AppUtils.Instance.getImagePath(/*forInternalUse*/false,/*includeSessionIdIfNeeded*/ false);
				}
			}
			List<Pair<string, string>> parameters = new List<Pair<string, string>>();
			parameters.Add(new Pair<string, string>(urlParameter, (string) null));
			navUrl += AppUtils.GetPageName(heContext, Global.eSpaceId, "MyInfo", parameters);

			return navUrl;
		}
		/// <summary>
		/// Gets the title of the link (wt_Link7)
		/// </summary>
		/// <returns>title of the Link (wt_Link7)</returns>
		public string
		lnk_Link7_getTitle() {
			return "My Info";
		}
		/// <summary>
		/// Gets the visible state of component (wt_Link7)
		/// </summary>
		/// <returns>The Visible State of wt_Link7</returns>
		public bool lnk_Link7_isVisible() {
			int oldCurrentESpaceId = heContext.CurrentESpaceId;
			try {
				heContext.CurrentESpaceId = ssTeste_SAP.Global.eSpaceId;
				return true;
			} finally {
				heContext.CurrentESpaceId = oldCurrentESpaceId;
			}
		}

		/// <summary>
		/// Gets the enabled state of component (wt_Link7)
		/// </summary>
		/// <returns>The Enabled State of wt_Link7</returns>
		public bool lnk_Link7_isEnabled() {
			int oldCurrentESpaceId = heContext.CurrentESpaceId;
			try {
				heContext.CurrentESpaceId = ssTeste_SAP.Global.eSpaceId;
				return true; 
			} finally {
				heContext.CurrentESpaceId = oldCurrentESpaceId;
			}
		}
		/// <summary>
		/// Function to dump expression (Key = ic9D4zOzQkO1IKFK3BGBug) Expression: GetUser(UserID).User.Name
		/// </summary>
		/// <returns>Returns the value of the Expression</returns>
		public string expression_InlineExpression8() {
			return Functions.ssGetUser(heContext, ((int) Global.App.OsContext.Session["UserID"])).ssENUser.ssName;
		}
		/// <summary>
		/// Action to be taken at a Link submit action)
		/// </summary>
		/// <param name="sender"> The associated sender components</param>
		/// <param name="e"> The associated event arguments</param>
		public void wtLogoutLink_Click(object sender, System.EventArgs e) {
			int oldCurrentESpaceId = heContext.CurrentESpaceId;
			try {
				heContext.CurrentESpaceId = ssTeste_SAP.Global.eSpaceId;
				((IWebScreen) ((System.Web.UI.Control) sender).Page).OnSubmit(((IParentEditRecordProp) sender).GetParentEditRecordClientId(), false);
				CommandLogout(heContext);
			} finally {
				heContext.CurrentESpaceId = oldCurrentESpaceId;
			}
		}
		/// <summary>
		/// Gets the title of the link (wtLogoutLink)
		/// </summary>
		/// <returns>title of the Link (wtLogoutLink)</returns>
		public string
		lnkLogoutLink_getTitle() {
			return "Logout";
		}
		/// <summary>
		/// Gets the visible state of component (wtLogoutLink)
		/// </summary>
		/// <returns>The Visible State of wtLogoutLink</returns>
		public bool lnkLogoutLink_isVisible() {
			int oldCurrentESpaceId = heContext.CurrentESpaceId;
			try {
				heContext.CurrentESpaceId = ssTeste_SAP.Global.eSpaceId;
				return true;
			} finally {
				heContext.CurrentESpaceId = oldCurrentESpaceId;
			}
		}

		/// <summary>
		/// Gets the enabled state of component (wtLogoutLink)
		/// </summary>
		/// <returns>The Enabled State of wtLogoutLink</returns>
		public bool lnkLogoutLink_isEnabled() {
			int oldCurrentESpaceId = heContext.CurrentESpaceId;
			try {
				heContext.CurrentESpaceId = ssTeste_SAP.Global.eSpaceId;
				return true; 
			} finally {
				heContext.CurrentESpaceId = oldCurrentESpaceId;
			}
		}
		public static class FuncCommandLogout {
		}

		public override Control FindControl(string id) {
			return base.FindControl(id);
		}
		public String BreakpointHook(String breakpointId) {
			return "";
		}

		public String BreakpointHook(String breakpointId, bool isExpressionlessWidget) {
			return "";
		}

		public String PageStartHook() {
			_isRendering = true;
			Page_Load(null, null); _isRendering = false;
			this.Load -= new System.EventHandler(this.Page_Load);
			return "";
		}
		public String PageEndHook() {
			return "";
		}
		public override string WebBlockIdentifier {
			get {
				return "Teste_SAP.KGxiSVdWauL5OYmSzn6P3Yw";
			}
		}
	}

}
