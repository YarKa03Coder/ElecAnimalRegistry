using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    static class DataConnections
    {
        private static string ownerUAconnectionString = "Data Source=DESKTOP-0DQ4NVO;Initial Catalog=OwnersUADB;Integrated Security=True";
        public static string OwnerUAconnectionString { get => ownerUAconnectionString; }
    }
}
