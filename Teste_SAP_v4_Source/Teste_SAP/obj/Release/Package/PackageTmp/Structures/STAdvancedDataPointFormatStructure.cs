﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Data;
using System.Runtime.Serialization;
using System.Reflection;
using System.Xml;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using System.Xml.Serialization;
using System.Collections;

namespace ssTeste_SAP {
	/// <summary>
	/// Structure <code>STAdvancedDataPointFormatStructure</code> that represents the Service Studio
	///  structure <code>AdvancedDataPointFormat</code> <p> Description: Information to format a data poin
	/// t using Highcharts JSON.</p>
	/// </summary>
	[Serializable()]
	public partial struct STAdvancedDataPointFormatStructure: ISerializable, ITypedRecord<STAdvancedDataPointFormatStructure>, ISimpleRecord {
		private static readonly GlobalObjectKey IdDataPoint = GlobalObjectKey.Parse("uQHsYT2wwkKZ1wrN3PIifQ*FLPAu8wq2k6K2nHh8lKvqA");
		private static readonly GlobalObjectKey IdDataPointJSON = GlobalObjectKey.Parse("uQHsYT2wwkKZ1wrN3PIifQ*fiFOEiggA0GlPrsCyYCBPg");

		public static void EnsureInitialized() {}

		static STAdvancedDataPointFormatStructure() {
			global::ssTeste_SAP.STAdvancedDataPointFormatStructureTypeFactoryImpl.InitializeFactory();
		}
		[System.Xml.Serialization.XmlElement("DataPoint")]
		public RCDataPointRecord ssDataPoint;

		[System.Xml.Serialization.XmlElement("DataPointJSON")]
		public string ssDataPointJSON;


		public BitArray OptimizedAttributes;

		public STAdvancedDataPointFormatStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssDataPoint = new RCDataPointRecord(null);
			ssDataPointJSON = "";
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssDataPoint.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssDataPointJSON = r.ReadText(index++, "AdvancedDataPointFormat.DataPointJSON", "");
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(STAdvancedDataPointFormatStructure r) {
			this = r;
		}


		public static bool operator == (STAdvancedDataPointFormatStructure a, STAdvancedDataPointFormatStructure b) {
			if (a.ssDataPoint != b.ssDataPoint) return false;
			if (a.ssDataPointJSON != b.ssDataPointJSON) return false;
			return true;
		}

		public static bool operator != (STAdvancedDataPointFormatStructure a, STAdvancedDataPointFormatStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STAdvancedDataPointFormatStructure)) return false;
			return (this == (STAdvancedDataPointFormatStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssDataPoint.GetHashCode()
				^ ssDataPointJSON.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public STAdvancedDataPointFormatStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssDataPoint = new RCDataPointRecord(null);
			ssDataPointJSON = "";
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssDataPoint", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssDataPoint' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssDataPoint = (RCDataPointRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssDataPointJSON", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssDataPointJSON' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssDataPointJSON = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssDataPoint.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssDataPoint.InternalRecursiveSave();
		}


		public STAdvancedDataPointFormatStructure Duplicate() {
			STAdvancedDataPointFormatStructure t;
			t.ssDataPoint = (RCDataPointRecord) this.ssDataPoint.Duplicate();
			t.ssDataPointJSON = this.ssDataPointJSON;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				ssDataPoint.ToXml(this, recordElem, "DataPoint", detailLevel - 1);
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".DataPointJSON")) VarValue.AppendAttribute(recordElem, "DataPointJSON", ssDataPointJSON, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "DataPointJSON");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "datapoint") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".DataPoint")) variable.Value = ssDataPoint; else variable.Optimized = true;
				variable.SetFieldName("datapoint");
			} else if (head == "datapointjson") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".DataPointJSON")) variable.Value = ssDataPointJSON; else variable.Optimized = true;
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdDataPoint) {
				return ssDataPoint;
			} else if (key == IdDataPointJSON) {
				return ssDataPointJSON;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssDataPoint.FillFromOther((IRecord) other.AttributeGet(IdDataPoint));
			ssDataPointJSON = (string) other.AttributeGet(IdDataPointJSON);
		}
	} // STAdvancedDataPointFormatStructure
	/// <summary>
	/// Structure <code>RCAdvancedDataPointFormatRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCAdvancedDataPointFormatRecord: ISerializable, ITypedRecord<RCAdvancedDataPointFormatRecord> {
		private static readonly GlobalObjectKey IdAdvancedDataPointFormat = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*Rdp3k2JpxESpNWWRsiYxbQ");

		public static void EnsureInitialized() {}

		static RCAdvancedDataPointFormatRecord() {
			global::ssTeste_SAP.RCAdvancedDataPointFormatRecordTypeFactoryImpl.InitializeFactory();
		}
		[System.Xml.Serialization.XmlElement("AdvancedDataPointFormat")]
		public STAdvancedDataPointFormatStructure ssSTAdvancedDataPointFormat;


		public static implicit operator STAdvancedDataPointFormatStructure(RCAdvancedDataPointFormatRecord r) {
			return r.ssSTAdvancedDataPointFormat;
		}

		public static implicit operator RCAdvancedDataPointFormatRecord(STAdvancedDataPointFormatStructure r) {
			RCAdvancedDataPointFormatRecord res = new RCAdvancedDataPointFormatRecord(null);
			res.ssSTAdvancedDataPointFormat = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCAdvancedDataPointFormatRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTAdvancedDataPointFormat = new STAdvancedDataPointFormatStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTAdvancedDataPointFormat.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTAdvancedDataPointFormat.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCAdvancedDataPointFormatRecord r) {
			this = r;
		}


		public static bool operator == (RCAdvancedDataPointFormatRecord a, RCAdvancedDataPointFormatRecord b) {
			if (a.ssSTAdvancedDataPointFormat != b.ssSTAdvancedDataPointFormat) return false;
			return true;
		}

		public static bool operator != (RCAdvancedDataPointFormatRecord a, RCAdvancedDataPointFormatRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCAdvancedDataPointFormatRecord)) return false;
			return (this == (RCAdvancedDataPointFormatRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTAdvancedDataPointFormat.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCAdvancedDataPointFormatRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTAdvancedDataPointFormat = new STAdvancedDataPointFormatStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTAdvancedDataPointFormat", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTAdvancedDataPointFormat' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTAdvancedDataPointFormat = (STAdvancedDataPointFormatStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTAdvancedDataPointFormat.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTAdvancedDataPointFormat.InternalRecursiveSave();
		}


		public RCAdvancedDataPointFormatRecord Duplicate() {
			RCAdvancedDataPointFormatRecord t;
			t.ssSTAdvancedDataPointFormat = (STAdvancedDataPointFormatStructure) this.ssSTAdvancedDataPointFormat.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTAdvancedDataPointFormat.ToXml(this, recordElem, "AdvancedDataPointFormat", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "advanceddatapointformat") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".AdvancedDataPointFormat")) variable.Value = ssSTAdvancedDataPointFormat; else variable.Optimized = true;
				variable.SetFieldName("advanceddatapointformat");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdAdvancedDataPointFormat) {
				return ssSTAdvancedDataPointFormat;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTAdvancedDataPointFormat.FillFromOther((IRecord) other.AttributeGet(IdAdvancedDataPointFormat));
		}
	} // RCAdvancedDataPointFormatRecord
	/// <summary>
	/// RecordList type <code>RLAdvancedDataPointFormatRecordList</code> that represents a record list of
	///  <code>AdvancedDataPointFormat</code>
	/// </summary>
	[Serializable()]
	public partial class RLAdvancedDataPointFormatRecordList: GenericRecordList<RCAdvancedDataPointFormatRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		static RLAdvancedDataPointFormatRecordList() {
			global::ssTeste_SAP.RLAdvancedDataPointFormatRecordListTypeFactoryImpl.InitializeFactory();
		}

		protected override RCAdvancedDataPointFormatRecord GetElementDefaultValue() {
			return new RCAdvancedDataPointFormatRecord("");
		}

		public T[] ToArray<T>(Func<RCAdvancedDataPointFormatRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLAdvancedDataPointFormatRecordList recordlist, Func<RCAdvancedDataPointFormatRecord, T> converter) {
			T[] result = new T[recordlist.Length];
			recordlist.StartIteration();
			while (!recordlist.Eof) {
				result[recordlist.CurrentRowNumber] = converter(recordlist.CurrentRec);
				recordlist.Advance();
			}
			recordlist.EndIteration();
			return result;
		}

		public static RLAdvancedDataPointFormatRecordList ToList<T>(T[] array, Func <T, RCAdvancedDataPointFormatRecord> converter) {
			RLAdvancedDataPointFormatRecordList result = new RLAdvancedDataPointFormatRecordList();
			if (array != null) {
				foreach(T item in array) {
					result.Append(converter(item));
				}
			}
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLAdvancedDataPointFormatRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLAdvancedDataPointFormatRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLAdvancedDataPointFormatRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLAdvancedDataPointFormatRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCAdvancedDataPointFormatRecord> NewList() {
			return new RLAdvancedDataPointFormatRecordList();
		}


	} // RLAdvancedDataPointFormatRecordList
	/// <summary>
	/// RecordList type <code>RLAdvancedDataPointFormatList</code> that represents a record list of
	///  <code>Text, DataPointRecord</code>
	/// </summary>
	[Serializable()]
	public partial class RLAdvancedDataPointFormatList: GenericRecordList<STAdvancedDataPointFormatStructure>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override STAdvancedDataPointFormatStructure GetElementDefaultValue() {
			return new STAdvancedDataPointFormatStructure("");
		}

		public T[] ToArray<T>(Func<STAdvancedDataPointFormatStructure, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLAdvancedDataPointFormatList recordlist, Func<STAdvancedDataPointFormatStructure, T> converter) {
			T[] result = new T[recordlist.Length];
			recordlist.StartIteration();
			while (!recordlist.Eof) {
				result[recordlist.CurrentRowNumber] = converter(recordlist.CurrentRec);
				recordlist.Advance();
			}
			recordlist.EndIteration();
			return result;
		}

		public static RLAdvancedDataPointFormatList ToList<T>(T[] array, Func <T, STAdvancedDataPointFormatStructure> converter) {
			RLAdvancedDataPointFormatList result = new RLAdvancedDataPointFormatList();
			if (array != null) {
				foreach(T item in array) {
					result.Append(converter(item));
				}
			}
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLAdvancedDataPointFormatList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLAdvancedDataPointFormatList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLAdvancedDataPointFormatList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLAdvancedDataPointFormatList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<STAdvancedDataPointFormatStructure> NewList() {
			return new RLAdvancedDataPointFormatList();
		}


	} // RLAdvancedDataPointFormatList
}

namespace ssTeste_SAP {
	[XmlType("AdvancedDataPointFormat")]
	public class WORCAdvancedDataPointFormatRecord {
		[System.Xml.Serialization.XmlElement("DataPoint")]
		public WORCDataPointRecord varWSDataPoint;

		[System.Xml.Serialization.XmlElement("DataPointJSON")]
		public string varWSDataPointJSON;

		public WORCAdvancedDataPointFormatRecord() {
			varWSDataPoint = new WORCDataPointRecord();
			varWSDataPointJSON = (string) "";
		}

		public WORCAdvancedDataPointFormatRecord(STAdvancedDataPointFormatStructure r) {
			varWSDataPoint = r.ssDataPoint;
			varWSDataPointJSON = BaseAppUtils.RemoveControlChars(r.ssDataPointJSON);
		}

		public static RLAdvancedDataPointFormatList ToRecordList(WORCAdvancedDataPointFormatRecord[] array) {
			RLAdvancedDataPointFormatList rl = new RLAdvancedDataPointFormatList();
			if (array != null) {
				foreach(WORCAdvancedDataPointFormatRecord val in array) {
					rl.Append(val);
				}
			}
			return rl;
		}

		public static WORCAdvancedDataPointFormatRecord[] FromRecordList(RLAdvancedDataPointFormatList rl) {
			WORCAdvancedDataPointFormatRecord[] array = new WORCAdvancedDataPointFormatRecord[rl == null ? 0: rl.Length];
			for (int i = 0; i < array.Length; i++) {
				array[i] = rl.Data[i];
			}
			return array;
		}
	}
}

namespace ssTeste_SAP {
	partial struct RCAdvancedDataPointFormatRecord {
		public static implicit operator WORCAdvancedDataPointFormatRecord(RCAdvancedDataPointFormatRecord r) {
			return new WORCAdvancedDataPointFormatRecord(r.ssSTAdvancedDataPointFormat);
		}

		public static implicit operator RCAdvancedDataPointFormatRecord(WORCAdvancedDataPointFormatRecord w) {
			RCAdvancedDataPointFormatRecord r = new RCAdvancedDataPointFormatRecord("");
			if (w != null) {
				r.ssSTAdvancedDataPointFormat = w;
			}
			return r;
		}

	}

	partial struct STAdvancedDataPointFormatStructure {
		public static implicit operator WORCAdvancedDataPointFormatRecord(STAdvancedDataPointFormatStructure r) {
			return new WORCAdvancedDataPointFormatRecord(r);
		}

		public static implicit operator STAdvancedDataPointFormatStructure(WORCAdvancedDataPointFormatRecord w) {
			STAdvancedDataPointFormatStructure r = new STAdvancedDataPointFormatStructure("");
			if (w != null) {
				r.ssDataPoint = w.varWSDataPoint;
				r.ssDataPointJSON = ((string) w.varWSDataPointJSON ?? "");
			}
			return r;
		}

	}
}


namespace ssTeste_SAP {
	[Serializable()]
	public partial class WORLAdvancedDataPointFormatRecordList {
		public WORCAdvancedDataPointFormatRecord[] Array;


		public WORLAdvancedDataPointFormatRecordList(WORCAdvancedDataPointFormatRecord[] r) {
			if (r == null)
			Array = new WORCAdvancedDataPointFormatRecord[0];
			else
			Array = r;
		}
		public WORLAdvancedDataPointFormatRecordList() {
			Array = new WORCAdvancedDataPointFormatRecord[0];
		}

		public WORLAdvancedDataPointFormatRecordList(RLAdvancedDataPointFormatRecordList rl) {
			rl=(RLAdvancedDataPointFormatRecordList) rl.Duplicate();
			Array = new WORCAdvancedDataPointFormatRecord[rl.Length];
			while (!rl.Eof) {
				Array[rl.CurrentRowNumber] = new WORCAdvancedDataPointFormatRecord(rl.CurrentRec);
				rl.Advance();
			}
		}

	}
}

namespace ssTeste_SAP {
	partial class RLAdvancedDataPointFormatRecordList {
		public static implicit operator RLAdvancedDataPointFormatRecordList(WORCAdvancedDataPointFormatRecord[] array) {
			RLAdvancedDataPointFormatRecordList rl = new RLAdvancedDataPointFormatRecordList();
			if (array != null) {
				foreach(WORCAdvancedDataPointFormatRecord val in array) {
					rl.Append((RCAdvancedDataPointFormatRecord) val);
				}
			}
			return rl;
		}
		public static implicit operator WORCAdvancedDataPointFormatRecord[](RLAdvancedDataPointFormatRecordList rl) {
			WORCAdvancedDataPointFormatRecord[] array = new WORCAdvancedDataPointFormatRecord[rl == null ? 0: rl.Length];
			for (int i = 0; i < array.Length; i++) {
				array[i] = (RCAdvancedDataPointFormatRecord) rl.Data[i];
			}
			return array;
		}
	}
}

namespace ssTeste_SAP {
	partial class WORLAdvancedDataPointFormatRecordList {
		public static implicit operator RLAdvancedDataPointFormatRecordList(WORLAdvancedDataPointFormatRecordList w) {
			return w.Array;
		}
		public static implicit operator WORLAdvancedDataPointFormatRecordList(RLAdvancedDataPointFormatRecordList rl) {
			return new WORLAdvancedDataPointFormatRecordList(rl);
		}
		public static implicit operator WORCAdvancedDataPointFormatRecord[](WORLAdvancedDataPointFormatRecordList w) {
			if (w != null) {
				return w.Array;
			}
			return null;
		}
		public static implicit operator WORLAdvancedDataPointFormatRecordList(WORCAdvancedDataPointFormatRecord[] array) {
			return new WORLAdvancedDataPointFormatRecordList(array);
		}
	}
}

namespace ssTeste_SAP {
	[Serializable()]
	public partial class WORLAdvancedDataPointFormatList {
		public WORCAdvancedDataPointFormatRecord[] Array;


		public WORLAdvancedDataPointFormatList(WORCAdvancedDataPointFormatRecord[] r) {
			if (r == null)
			Array = new WORCAdvancedDataPointFormatRecord[0];
			else
			Array = r;
		}
		public WORLAdvancedDataPointFormatList() {
			Array = new WORCAdvancedDataPointFormatRecord[0];
		}

		public WORLAdvancedDataPointFormatList(RLAdvancedDataPointFormatList rl) {
			rl=(RLAdvancedDataPointFormatList) rl.Duplicate();
			Array = new WORCAdvancedDataPointFormatRecord[rl.Length];
			while (!rl.Eof) {
				Array[rl.CurrentRowNumber] = rl.CurrentRec.Duplicate();
				rl.Advance();
			}
		}

	}
}

namespace ssTeste_SAP {
	partial class RLAdvancedDataPointFormatList {
		public static implicit operator RLAdvancedDataPointFormatList(WORCAdvancedDataPointFormatRecord[] array) {
			RLAdvancedDataPointFormatList rl = new RLAdvancedDataPointFormatList();
			if (array != null) {
				foreach(WORCAdvancedDataPointFormatRecord val in array) {
					rl.Append((STAdvancedDataPointFormatStructure) val);
				}
			}
			return rl;
		}
		public static implicit operator WORCAdvancedDataPointFormatRecord[](RLAdvancedDataPointFormatList rl) {
			WORCAdvancedDataPointFormatRecord[] array = new WORCAdvancedDataPointFormatRecord[rl == null ? 0: rl.Length];
			for (int i = 0; i < array.Length; i++) {
				array[i] = (STAdvancedDataPointFormatStructure) rl.Data[i];
			}
			return array;
		}
	}
}

namespace ssTeste_SAP {
	partial class WORLAdvancedDataPointFormatList {
		public static implicit operator RLAdvancedDataPointFormatList(WORLAdvancedDataPointFormatList w) {
			return w.Array;
		}
		public static implicit operator WORLAdvancedDataPointFormatList(RLAdvancedDataPointFormatList rl) {
			return new WORLAdvancedDataPointFormatList(rl);
		}
		public static implicit operator WORCAdvancedDataPointFormatRecord[](WORLAdvancedDataPointFormatList w) {
			if (w != null) {
				return w.Array;
			}
			return null;
		}
		public static implicit operator WORLAdvancedDataPointFormatList(WORCAdvancedDataPointFormatRecord[] array) {
			return new WORLAdvancedDataPointFormatList(array);
		}
	}
}

