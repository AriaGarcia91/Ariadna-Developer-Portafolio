using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Dummy.DataLayer
{
    public class ApiConnection
    {
        public string UrlBase { get; set; }
        public string Conexion { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }

        private readonly string _connectionString;
        Tuple<string, string, string, string> _connection;
        public ApiConnection( string connection)
        {
            _connectionString = connection;
            _connection = RecuperarConexion(_connectionString);
            UrlBase = _connection.Item1;
            UserName = _connection.Item2;
            Password = _connection.Item3;
            Domain = _connection.Item4;
        }
        private Tuple<string, string, string, string> RecuperarConexion(string connection)
        {
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
            builder.ConnectionString = connection;
            return new Tuple<string, string, string, string>(
                (string)builder["Url"],
                (string)builder["Username"],
                (string)builder["Password"],
                (string)builder["Domain"]
            );
        }
    }
}
