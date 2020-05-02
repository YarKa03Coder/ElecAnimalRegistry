using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    /// <summary>
    /// Stores all connection strings.
    /// </summary>
    static class DataConnections
    {
        private static string ownerUAconnectionString = "Data Source=DESKTOP-0DQ4NVO;Initial Catalog=OwnersUADB;Integrated Security=True";

        /// <summary>
        /// Connections string for database, that stores information about owners and their pets in Ukraine.
        /// </summary>
        public static string OwnerUAconnectionString { get => ownerUAconnectionString; }
    }
}
