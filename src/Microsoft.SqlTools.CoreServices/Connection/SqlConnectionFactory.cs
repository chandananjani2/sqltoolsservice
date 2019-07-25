﻿//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System.Data.Common;
using Microsoft.SqlTools.CoreServices.Connection.ReliableConnection;

namespace Microsoft.SqlTools.CoreServices.Connection
{
    /// <summary>
    /// Factory class to create SqlClientConnections
    /// The purpose of the factory is to make it easier to mock out the database
    /// in 'offline' unit test scenarios.
    /// </summary>
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        /// <summary>
        /// Creates a new SqlConnection object
        /// </summary>
        public DbConnection CreateSqlConnection(string connectionString)
        {
            // Added some comment for demo1
            RetryPolicy connectionRetryPolicy = RetryPolicyFactory.CreateDefaultConnectionRetryPolicy();
            RetryPolicy commandRetryPolicy = RetryPolicyFactory.CreateDefaultConnectionRetryPolicy();
            return new ReliableSqlConnection(connectionString, connectionRetryPolicy, commandRetryPolicy);
        }
    }
}
