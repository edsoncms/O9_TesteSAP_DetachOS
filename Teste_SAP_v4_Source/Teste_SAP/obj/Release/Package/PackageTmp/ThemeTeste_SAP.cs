﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.HubEdition.WebWidgets;

namespace ssTeste_SAP.Themes.ThemeTeste_SAP {

	public class ExceptionHandler {

		private readonly OSPage page;
		private readonly bool isEmailScreen;

		public ExceptionHandler(OSPage page, bool isEmailScreen) {
			this.page = page;
			this.isEmailScreen = isEmailScreen;
		}

		private OSPage Page {
			get {
				return page; 
			}
		}

		public bool HandleException() {
			LocalState dummy = null;
			return HandleException(ref dummy);
		}

		public bool HandleException(ref LocalState flowState) {
			return new ssTeste_SAP.Flows.FlowCommon.ExceptionHandler(page, isEmailScreen).HandleException();

		}
	}
}