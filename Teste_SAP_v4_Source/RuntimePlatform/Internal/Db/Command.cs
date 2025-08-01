/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Collections;
using OutSystems.HubEdition.Extensibility.Data.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data.Platform;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OutSystems.HubEdition.RuntimePlatform;

namespace OutSystems.Internal.Db {
    public class Command : IDisposable {

        public IDbCommand DriverCommand { get; private set; }

        public IExecutionService ExecutionService { get; private set; }

        internal Command(IExecutionService executionService, IDbCommand command) {
            if (executionService == null || command == null) {
                throw new ArgumentNullException();
            }
            ExecutionService = executionService;
            DriverCommand = command;
            CommandTimeout = DatabaseAccess.QueryTimeout;
        }

        public string CommandText {
            get { return DriverCommand.CommandText; }
            set { DriverCommand.CommandText = value; }
        }

        private static readonly Regex paramAtRegex = new Regex("@(\"?\\w+\"?)", RegexOptions.Compiled);

        /// <summary>
        /// Replaces the parameters prefix '@' with the one defined in <see cref="IExecutionService.ParameterPrefix"/>
        /// in both the command text and the command parameters. Nothing is done if the defined prefix is '@'.
        /// </summary>
        public void TransformParametersSyntax() {
            string paramPrefix = ExecutionService.DatabaseServices.ExecutionService.ParameterPrefix;
            if (paramPrefix == "@" || DriverCommand.Parameters.Count == 0) {
                return;
            }
            var parameters = new HashSet<string>();

            for (int i = 0; i < DriverCommand.Parameters.Count; i++) {
                IDbDataParameter parameter = (IDbDataParameter)DriverCommand.Parameters[i];
                // Grab param name without prefix (sometimes prefix is already used in the parameters but not in SQL)
                string paramName = parameter.ParameterName.ToLower().Trim((" @" + paramPrefix.ToLower()).ToCharArray());
                // This will do nothing when the paramPrefix="@" 
                parameter.ParameterName = parameter.ParameterName.Replace("@", paramPrefix);
                // In Java, parameter list includes repetitions
                if (!parameters.Contains(paramName)) {
                    parameters.Add(paramName);
                }
            }

            
            if (DriverCommand.CommandType != CommandType.Text) {
                return;
            }
            // #115001: Replace only the @foo's that are params to the query so we don't substitute @DBLinks
            DriverCommand.CommandText = paramAtRegex.Replace(DriverCommand.CommandText, match => {
                string paramName = match.Groups[1].Value;
                return parameters.Contains(paramName.ToLower()) ? paramPrefix + paramName : match.Value;
            });
        }

        public DataParameter CreateParameter(string name) {
            return CreateParameter(name, DbType.String, (object) null);
        }

        public DataParameter CreateParameter(string name, object paramValue) {
            return CreateParameter(name, DbType.String, paramValue);
        }

        public DataParameter CreateParameter(string name, DbType dbType, object paramValue) {
            return CreateParameter(name, dbType, paramValue, true);
        }

        public DataParameter CreateParameterWithoutReplacements(string name, DbType dbType, object paramValue) {
            return CreateParameter(name, dbType, paramValue, false);
        }

        public DataParameter CreateParameterWithDirection(string name, DbType dbType, ParameterDirection direction) {
            DataParameter param = CreateParameter(name, dbType, null);
            param.ParamDirection = direction;
            return param;
        }

        public DataParameter CreateParameter(string name, DbType dbType, object paramValue, bool transformLiteral) {
            if (transformLiteral) {
                paramValue = ExecutionService.TransformRuntimeToDatabaseValue(dbType, paramValue);
            }
            IDbDataParameter parameter = ExecutionService.CreateParameter(DriverCommand, name, dbType, paramValue);
            return new DataParameter(ExecutionService, parameter);
        }

        public DataParameter CreateParameter(string name, DbType dbType, ObjectKey key) {
            if (key == null) {
                /* The key should never be null, if something like that happens we should
                 * go to the other AddParameter because .Net will use the most specific method instead
                 * of using the most generic one or giving some kind of warning/error.
                 * 
                 * This happens when we call an AddParameter in SqlStateConnection.TempGet and other places. */
                return CreateParameter(name, dbType, (object)null);
            }

            string keyToInsert = ObjectKeyUtils.DatabaseValue(key);
            return CreateParameter(name, dbType, keyToInsert);
        }

        public DataParameter CreateOutputParameter(string name, DbType dbType) {
            DataParameter parameter = CreateParameter(name, dbType, null);
            parameter.ParamDirection = ParameterDirection.Output;
            return parameter;
        }
        
        public int ExecuteNonQuery() {
            return ExecuteNonQuery(false);
        }

        public int ExecuteNonQuery(bool skipLog) {
            return ExecuteNonQuery(null, false, skipLog, true);
        }

        public int ExecuteNonQuery(string description, bool isApplication) {
            return ExecuteNonQuery(description, isApplication, false, true);
        }

        public int ExecuteNonQuery(string description, bool isApplication, bool skipLog, bool applyTransformationsToParameters) {
            DateTime startTime = DateTime.Now;
            IDbTransaction trans = DriverCommand.Transaction;
            IDbConnection conn = DriverCommand.Connection;
            int result;
            try {
                if (applyTransformationsToParameters) {
                    TransformParametersSyntax();
                }
                result = ExecutionService.ExecuteNonQuery(DriverCommand);

                IEnumerable parameters = DriverCommand.Parameters;

                foreach (IDbDataParameter parameter in parameters) {
                    if (IsOutputParameter(parameter.Direction)) {
                        parameter.Value = ExecutionService.TransformDatabaseToRuntimeValue(parameter.Value);
                    }
                }
            } catch (DbException e) {
                HandleDatabaseException(e, null, conn, trans);
                throw;
            }
            if (!skipLog)
                LogSlowQuery(startTime, description, isApplication);
            return result;
        }

        private bool IsOutputParameter(ParameterDirection direction) {
#if JAVA
            return direction == ParameterDirection.Output;
#else
            return direction == ParameterDirection.Output || direction == ParameterDirection.InputOutput ||
                   direction == ParameterDirection.ReturnValue;
#endif
        }

        public int ExecuteNonQueryWithoutSlowSqlLog() {
            return ExecuteNonQuery(null, false, true, true);
        }

        public int ExecuteNonQueryWithoutTransformParametersSyntax(string description, bool isApplication) {
            return ExecuteNonQueryWithoutTransformParametersSyntax(description, isApplication, false);
        }

        public int ExecuteNonQueryWithoutTransformParametersSyntax(string description, bool isApplication, bool skipLog) {
            return ExecuteNonQuery(description, isApplication, skipLog, false);
        }

        public IDataReader ExecuteReader() {
            return ExecuteReader(null, false);
        }

        public IDataReader ExecuteReader(bool skipLog) {
            return ExecuteReader(null, false, skipLog);
        }

        public IDataReader ExecuteReader(string description, bool isApplication) {
            return ExecuteReader(description, isApplication, true, false);
        }

        public IDataReader ExecuteReader(string description, bool isApplication, bool skipLog) {
            return ExecuteReader(description, isApplication, true, skipLog);
        }

        public virtual IDataReader ExecuteReader(string description, bool isApplication, bool applyTransformationsToParameters, bool skipLog) {
            DateTime startTime = DateTime.Now;
            IDbTransaction trans = DriverCommand.Transaction;
            IDbConnection conn = DriverCommand.Connection;
            IDataReader reader = null;
            try {
                if (applyTransformationsToParameters) {
                    TransformParametersSyntax();
                }
                reader = new DataReader(ExecutionService, this, ExecutionService.ExecuteReader(DriverCommand));
            } catch (DbException e) {
                HandleDatabaseException(e, reader, conn, trans);
                throw;
            }

            if (!skipLog) {
                LogSlowQuery(startTime, description, isApplication);
            }

            return reader;
        }

        public object ExecuteScalar() {
            return ExecuteScalar(null, false, false);
        }

        public object ExecuteScalar(bool skipLog) {
            return ExecuteScalar(null, false, skipLog);
        }

        public object ExecuteScalar(string description, bool isApplication) {
            return ExecuteScalar(description, isApplication, false);
        }

        public object ExecuteScalar(string description, bool isApplication, bool skipLog) {
            return ExecuteScalar(description, isApplication, skipLog, true);
        }

        public object ExecuteScalarWithoutTransformParametersSyntax() {
            return ExecuteScalarWithoutTransformParametersSyntax(null, false);
        }

        public object ExecuteScalarWithoutTransformParametersSyntax(bool skipLog) {
            return ExecuteScalarWithoutTransformParametersSyntax(null, skipLog);
        }

        public object ExecuteScalarWithoutTransformParametersSyntax(string description, bool skipLog) {
            return ExecuteScalar(description, false, skipLog, false);
        }

        public object ExecuteScalar(string description, bool isApplication, bool skipLog, bool applyTransformationsToParameters) {
            DateTime startTime = DateTime.Now;
            IDbTransaction trans = DriverCommand.Transaction;
            IDbConnection conn = DriverCommand.Connection;
            object result;
            try {
                if (applyTransformationsToParameters) {
                    TransformParametersSyntax();
                }
                result = ExecutionService.TransformDatabaseToRuntimeValue(ExecutionService.ExecuteScalar(DriverCommand));
            } catch (DbException e) {
                HandleDatabaseException(e, null, conn, trans);
                throw;
            }
            if (!skipLog)
                LogSlowQuery(startTime, description, isApplication);
            return result;
        }

        public IDataReader ExecuteStoredProcedureWithResultSet(string readerParamName) {
            return ExecuteStoredProcedureWithResultSet(false, readerParamName);
        }

        public virtual IDataReader ExecuteStoredProcedureWithResultSet(bool skipLog, string readerParamName) {
            DateTime startTime = DateTime.Now;
            IDbTransaction trans = DriverCommand.Transaction;
            IDbConnection conn = DriverCommand.Connection;
            IDataReader reader = null;
            try {
                var platformDatabaseServices = ExecutionService.DatabaseServices as IPlatformDatabaseServices;
                if (platformDatabaseServices == null) {
                    throw new InvalidOperationException("ExecuteStoredProcedureWithResultSet is only available for platform database providers");
                }
                TransformParametersSyntax();
                reader = new DataReader(ExecutionService, this, platformDatabaseServices.ExecutionService.ExecuteStoredProcedureWithResultSet(DriverCommand, readerParamName));
            } catch (DbException e) {
                HandleDatabaseException(e, reader, conn, trans);
                throw;
            }
            if (!skipLog) {
                LogSlowQuery(startTime, null, false);
            }
            return reader;
        }

        public int CommandTimeout {
            get { return DriverCommand.CommandTimeout; }
            set { DriverCommand.CommandTimeout = value; }
        }

        public void SetTypeToText() {
            DriverCommand.CommandType = CommandType.Text;
        }

        public void SetTypeToStoredProcedure() {
            DriverCommand.CommandType = CommandType.StoredProcedure;
        }

        public DatabaseConnection GetConnection() {
            return new DatabaseConnection(ExecutionService.DatabaseServices, DriverCommand.Connection);
        }

        public void ClearParameters() {
            
            DriverCommand.Parameters.Clear();
        }

        public DataParameter GetParameter(string columnName) {
            return new DataParameter(ExecutionService, ((IDbDataParameter)DriverCommand.Parameters[columnName]));
        }

        public DataParameter GetParameter(int index) {
            return new DataParameter(ExecutionService, (IDbDataParameter)DriverCommand.Parameters[index]);
        }

        internal static void LogSlowQuery(DateTime startTime, string description, bool isApplication) {
            if (DatabaseAccess.SkipSlowQueries) {
                return;
            }

            double duration = DateTime.Now.Subtract(startTime).TotalMilliseconds;

            if (description == null) {
                description = GetCallerName();
            }

            if (duration > DatabaseAccess.SlowQueryThreshold) {
                if (!isApplication) {
                    description = "OS: " + description;
                }
                description += " took " + Convert.ToInt32(duration) + " ms";
                DatabaseAccess.LogSlowQuery(startTime, description);                
            }
        }

        private static string RemoveFromDescription(string description, string partToRemove) {
            int partToRemoveIndex = description.IndexOf(partToRemove);
            if (partToRemoveIndex >= 0)
                return description.Remove(partToRemoveIndex, partToRemove.Length);
            return description;
        }

        protected static string GetCallerName() {
            StackTrace st = new StackTrace();
            System.Reflection.MethodBase method;
            for (int i = 0; i < st.FrameCount; i++) {
                method = st.GetFrame(i).GetMethod();
                if (method.DeclaringType != typeof(Command) && method.DeclaringType != typeof(ManagedCommand)) {
                    return method.DeclaringType + "." + method.Name;
                }
            }
            return "getCallerName: Cannot find caller...";
        }

        protected virtual void HandleDatabaseException(DbException e, IDataReader reader, IDbConnection conn, IDbTransaction trans) {
            ExecutionService.OnExecuteException(e, DriverCommand, reader, conn, trans, null);
        }
        
        #region IDisposable Members
        
        public void Dispose() {
#if !JAVA
            foreach (IDbDataParameter param in DriverCommand.Parameters) {
                var paramValue = param.Value as IDisposable;
                if (paramValue != null) {
                    paramValue.Dispose();
                }
            }
#endif
            DriverCommand.Dispose();
        }

        #endregion
    }
}
