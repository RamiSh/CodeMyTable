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
    public class TableRepository : BaseRepository, ITableRepository
    {
        public TableRepository(string connection)
        {
            base.ConnectionString = connection;
        }

        public IEnumerable<ColumnInfo> GetColumns(string tableName, string tableOwner)
        {
            using (var connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new OracleCommand())
                {
                    var query = $@" SELECT *
                                    FROM ALL_TAB_COLUMNS
                                   WHERE lower(table_name) = {tableName.ToLower()} AND lower(OWNER) = {tableOwner.ToLower()}";

                    command.Connection = connection;
                    command.CommandText = query;

                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        var tables = new List<ColumnInfo>();

                        while (reader.Read())
                        {
                            tables.Add(new ColumnInfo
                            {
                                Name=reader["COLUMN_NAME"].ToString(),
                                TableName = reader["TABLE_NAME"].ToString(),
                                Owner = reader["OWNER"].ToString(),
                                DataType = reader["DATA_TYPE"].ToString()
                            });
                        }

                        return tables.Take(100);
                    }

                }
            }

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
                                Name = reader["TABLE_NAME"].ToString(),
                                Owner = reader["OWNER"].ToString()
                            });
                        }

                        return tables.Take(100);
                    }
                    
                }
            }
        }
    }
}
