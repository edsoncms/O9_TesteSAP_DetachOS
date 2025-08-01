﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Processes;
using OutSystems.ObjectKeys;

namespace ssTeste_SAP.Processes {
	public abstract class AbstractProcess: ProcessBase {

		protected AbstractProcess(IProcessActivity ownerActivity): base(ownerActivity) {}

		private static object processesDefinitionLock = new object();
		private static volatile Dictionary<ObjectKey, IProcess> processesDefinition = null;
		private static Dictionary<ObjectKey, IProcess> ProcessesDefinition {
			get {
				if (processesDefinition == null) {
					lock(processesDefinitionLock) {
						if (processesDefinition == null) {
							Dictionary<ObjectKey, IProcess> temp = new Dictionary<ObjectKey, IProcess>();

							processesDefinition = temp;
						}
					}
				}
				return processesDefinition;
			}
		}

		public static bool GetProcessDefinition(ObjectKey processKey, out IProcess definition) {
			return ProcessesDefinition.TryGetValue(processKey, out definition);
		}

		public static void FillAllActivitiesDefinitions(Dictionary<ObjectKey, CreateActivityDelegate> dic) {
			foreach(IProcess value in ProcessesDefinition.Values) {
				ProcessBase proc = value as ProcessBase;

				if (proc != null) {
					proc.FillActivitiesDefinitions(dic);
				}
			}
		}

		/// <summary>
		/// Used to get a generic activity instance using a intance of a process definition
		/// </summary>
		public sealed override bool GetProcessActivityInstance(int processId, int activityId, ObjectKey activityKey, bool isRunning, out IProcessActivity instance) {
			return AbstractProcessActivity.GetProcessActivityImplementation(processId, activityId, activityKey, isRunning, out instance);
		}

		protected static string GetString(string key, string defaultValue) {
			return Global.GetStringResource(key, defaultValue);
		}

	}
}
