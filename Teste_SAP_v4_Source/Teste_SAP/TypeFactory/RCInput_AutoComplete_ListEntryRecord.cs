﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;

namespace ssTeste_SAP {
	public class RCInput_AutoComplete_ListEntryRecordTypeFactoryImpl: RsseSpaceRichWidgets.IRCInput_AutoComplete_ListEntryRecordTypeFactory {
		private static readonly RCInput_AutoComplete_ListEntryRecordTypeFactoryImpl Instance = new RCInput_AutoComplete_ListEntryRecordTypeFactoryImpl();

		private RCInput_AutoComplete_ListEntryRecordTypeFactoryImpl() {}

		public static void InitializeFactory() {
			RsseSpaceRichWidgets.Factory.FactoryRCInput_AutoComplete_ListEntryRecordSingleton = Instance;

		}

		public IRecord CreateRsseSpaceRichWidgetsRCInput_AutoComplete_ListEntryRecord() {
			return new RCInput_AutoComplete_ListEntryRecord(null);
		}

	}
}