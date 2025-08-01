/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Collections.Generic;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.Extensibility.Data.Platform.Configuration {

    public interface ISessionConfigurationManager {

        /// <summary>
        /// Sets the command timeout value to use in configuration queries.
        /// </summary>
        /// <value>
        /// The query timeout.
        /// </value>
        int QueryTimeout {
            set;
        }

        /// <summary>
        /// This property will obtain all the statements necessary to recreate the session model.
        /// It has all the opportunities to do changes in templates that depend on configuration information.
        /// </summary>
        /// <value>
        /// Statements to recreate the session model.
        /// </value>
        IEnumerable<string> SessionStatements {
            get;
        }

        /// <summary>
        /// Validates if elevated privileges are acutally required
        /// If plugin has ImplementsElevatedPrivilegesOperations=false, this method should return false.
        /// This ensures pre create or upgrade logic can be ran by hand to avoid elevated privileges during setup 
        /// <returns>Elevated privileges operations still need to run for setup to be complete</returns>
        /// </summary>
        bool RequiresElevatedPrivileges();

        /// <summary>
        /// Generates a setup script containing operations that require elevated privileges 
        /// <returns>Setup script with elevated privileges operations</returns>
        /// </summary>
        string GenerateSetupScript();

        /// <summary>
        /// Allows the plugin to run instructions before the create/upgrade is done.
        /// This operation requires an elevated user privilege.
        /// If plugin has ImplementsElevatedPrivilegesOperations=false, this method should not be implemented. (the caller wouldn’t have a proper config to pass anyway)
        /// This would allow logic such as - create the database if it doesn’t exist.
        /// </summary>
        void Pre_CreateOrUpgradeSession();

        /// <summary>
        /// Validates that the configuration for the user ‘User’ are valid and it can reach the db.
        /// It will return false if it cannot reach the db, and will have a non null errorMessage in that case.
        /// </summary>
        /// <param name="friendlyMessage">The friendly message to be show as output.</param>
        /// <returns>Returns True if the connection to the database was successfully. Otherwise it returns False.</returns>
        bool TestSessionConnection(out string friendlyMessage);
    }
}