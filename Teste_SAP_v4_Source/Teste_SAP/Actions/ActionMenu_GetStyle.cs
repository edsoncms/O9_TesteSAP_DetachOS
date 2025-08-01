﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Sms;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.RuntimePlatform.Email;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.RuntimeCommon;
using OutSystems.ObjectKeys;
using System.Resources;

namespace ssTeste_SAP {

	public partial class Actions {
		/// <summary>
		/// Action <code>ActionMenu_GetStyle</code> that represents the Service Studio reference action
		///  <code>Menu_GetStyle</code> <p> Description: Returns the styles for the menu options.</p>
		/// </summary>
		public static void ActionMenu_GetStyle(HeContext heContext, bool inParamIsActive, string inParamActiveStyle, string inParamInactiveStyle, out string outParamStyle) {
			RsseSpaceRichWidgets.MssMenu_GetStyle(heContext, inParamIsActive, inParamActiveStyle, inParamInactiveStyle, out outParamStyle);
		}

	}


}