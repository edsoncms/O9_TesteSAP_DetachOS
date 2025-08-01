/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

namespace OutSystems.HubEdition.Extensibility.Data.ConfigurationService {

    /// <summary>
    /// Encapsulates a connection string and other configuration information required to connect
    /// to a database.
    /// </summary>
    public interface IIntegrationDatabaseConfiguration {

        /// <summary>
        /// Gets the database provider. It provides information about the database,
        /// and access to its services.
        /// </summary>
        /// <value>
        /// The database provider.
        /// </value>
        IDatabaseProvider DatabaseProvider { get; }

        /// <summary>
        /// Gets the connection string that allows connecting to a database.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        string ConnectionString { get; }

        /// <summary>
        /// Gets the database identifier to be used in the configuration.
        /// </summary>
        /// <value>
        /// The database identifier.
        /// </value>
        string DatabaseIdentifier { get; }

        /// <summary>
        /// Gets the avanced configuration object that allows users to set connection parameters in an advanced way.
        /// </summary>
        /// <value>
        /// The advanced configuration object.
        /// </value>
        AdvancedConfiguration AdvancedConfiguration { get; }

        /// <summary>
        /// Gets the connection string that overrides specified configuration parameter values.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        string ConnectionStringOverride { get; set; }

        /// <summary>
        /// Gets the object that compacts all the needed configuration parameters to be used in runtime.
        /// </summary>
        /// <value>
        /// The runtime database configuration.
        /// </value>
        IRuntimeDatabaseConfiguration RuntimeDatabaseConfiguration { get; }
    }
}
