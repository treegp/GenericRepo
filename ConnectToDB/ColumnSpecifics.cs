using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToDB
{
    public class ColumnSpecifics

    {
        public PropertyInfo ColumnType { get; set; }
        public string ColumnName { get; set; }
        public string PropertyName { get; set; }
        public bool Required { get; set; }
        public bool PrimaryKey { get; set; }
        public bool Computed { get; set; }
    }
}
