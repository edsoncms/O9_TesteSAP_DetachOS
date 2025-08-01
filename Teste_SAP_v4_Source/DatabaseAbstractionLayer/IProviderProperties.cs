/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

namespace OutSystems.HubEdition.Extensibility.Data {

    /// <summary>
    /// Represents a set of properties that are specific to a database provider.
    /// </summary>
    public interface IProviderProperties {

        /// <summary>
        /// Gets the associated <see cref="IDatabaseProvider" /> instance.
        /// </summary>
        /// <value>
        /// The database provider associated.
        /// </value>
        IDatabaseProvider DatabaseProvider { get; }

        /// <summary>
        /// Gets the friendly name of the database provider.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        string DisplayName { get; }

        /// <summary>
        /// Gets the friendly name of the database provider, when used to run the OutSystems Plaftorm.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        string PlatformDisplayName { get; }

        /// <summary>
        /// Gets the friendly name of the object used to represent a database container (e.g. database, catalog, schema, ...), used
        /// for UI generation and messages displayed to the end-user.
        /// </summary>
        /// <value>
        /// The name of the database container.
        /// </value>
        string DatabaseContainerName { get; }

        /// <summary>
        /// Indicates if the provider's driver supports more than one active result set for a single connection.
        /// </summary>
        /// <value>
        /// True if it supports multiple active result sets for a single connection, False otherwise.
        /// </value>
        bool SupportsMultipleActiveResultSets { get; }
    }
}
