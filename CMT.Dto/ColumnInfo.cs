using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMT.Dto
{
    public class ColumnInfo
    {
        public string Name { get; set; }
        public string TableName { get; set; }
        public string Owner { get; set; }
        public string DataType { get; set; }
    }
}
