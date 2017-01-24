using CMT.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMT.Repository.Interfaces
{
    public interface ITableRepository
    {
        IEnumerable<TableInfo> GetTables();
        IEnumerable<ColumnInfo> GetColumns(string tableName, string tableOwner);
    }
}
