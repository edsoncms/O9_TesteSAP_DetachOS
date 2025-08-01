/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data.DMLService.DMLPlaceholders;
using System.Collections.Generic;

namespace OutSystems.HubEdition.Extensibility.Data.DMLService {
    
    /// <summary>
    /// Defines a contract for generating DML fragments required by applications to perform specific queries (e.g. count query)
    /// </summary>
    public interface IDMLQueries {

        /// <summary>
        /// Gets the associated <see cref="IDMLService" />.
        /// </summary>
        /// <value>
        /// The DML service associated.
        /// </value>
        IDMLService DMLService { get; }

        /// <summary>
        /// Returns the DML expressions to be inserted in a query statement,
        /// to make it count the number of records returned by the original query.
        /// </summary>
        /// <returns>An <see cref="IDictionary{TKey,TValue}"/> with the DML expressions.</returns>
        IDictionary<StatementPlaceholder, string> SQLPlaceholderValuesForCountQuery();

        /// <summary>
        /// Returns the DML expressions to be inserted in the <code>SELECT</code> statement of a query
        /// to limit the number of records returned.
        /// </summary>
        /// <param name="maxRecordsParam">Number of records to return.</param>
        /// <returns>An <see cref="IDictionary{TKey,TValue}"/> with the DML expressions.</returns>
        IDictionary<SelectPlaceholder, string> SQLPlaceholderValuesForMaxRecords(string maxRecordsParam);
    }
}
