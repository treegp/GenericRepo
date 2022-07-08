using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToDB
{
    public class GenericRepository<TEntity>
    {
        string conStr;
        string tblSchema;
        string tblName;


        public GenericRepository(string connection)
        {
            conStr = connection;
            var entityType = typeof(TEntity);





        }

    }
}
