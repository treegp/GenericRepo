using System.Collections.Generic;
using System.Linq;

namespace ConnectToDB
{
    public class GenericRepository<TEntity>
    {
        string conStr;
        string tblSchema;
        string tblName = typeof(TEntity).Name;
        List<ColumnSpecifics> ColumnsSpecifics = new List<ColumnSpecifics>();

        public GenericRepository(string connection)
        {
            conStr = connection;
            var entityType = typeof(TEntity);


            var tableInfo = entityType.GetCustomAttributes(typeof(Table), false).OfType<Table>().FirstOrDefault();
            if (tableInfo != null)
            {
                tblSchema = tableInfo.Schema;
            }
            else
            {
                tblSchema = "dbo";
            }

            foreach (var column in entityType.GetProperties())
            {
                ColumnSpecifics spec = new ColumnSpecifics
                {
                    ColumnName = column.Name,
                    PropertyName = column.Name,
                    ColumnType = column
                };
                var Ises = column.GetCustomAttributes(typeof(Column), false).OfType<Column>().FirstOrDefault();
                if (Ises != null)
                {
                    spec.PrimaryKey = Ises.PrimaryKey;
                    spec.Required = Ises.Required;
                    spec.Computed = Ises.Computed;
                }
                else
                {
                    spec.PrimaryKey = false;
                    spec.Required = false;
                    spec.Computed = false;
                }
                ColumnsSpecifics.Add(spec);
            }
        }

    }
}
