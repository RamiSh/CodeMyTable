using CMT.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMT.Dto;
using Oracle.ManagedDataAccess.Client;

namespace CMT.Repository
{
    public class TableRepository : BaseRepository, ITableInterface
    {
        public TableRepository(string connection)
        {
            base.ConnectionString = connection;
        }

        public IEnumerable<TableInfo> GetTables()
        {
            using (var connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new OracleCommand())
                {
                    var query = $@"SELECT * FROM ALL_TABLES";

                    command.Connection = connection;
                    command.CommandText = query;

                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        var tables = new List<TableInfo>();

                        while (reader.Read())
                        {
                            tables.Add(new TableInfo
                            {
                                Name = reader["TABLE_NAME"].ToString()
                            });
                        }

                        return tables;
                    }
                    
                }
            }
        }
    }
}
