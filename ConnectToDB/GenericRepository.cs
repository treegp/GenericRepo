using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        //INSERT INTO [dbo].[****] (Id,...) VALUES (@param1,...)
        public int Insert(TEntity entity)
        {
            List<string> columnList = new List<string>();
            List<string> paramList = new List<string>();
            List<SqlParameter> parametersList = new List<SqlParameter>();

            int i = 1;
            foreach (var spec in ColumnsSpecifics)
            {
                if (spec.Computed | spec.ColumnType.GetValue(entity) == null)
                    continue;

                columnList.Add(spec.ColumnName);
                paramList.Add("param" + i);
                parametersList.Add(new SqlParameter("param" + i, spec.ColumnType.GetValue(entity)));
                i++;
            }

            string insertPart = "INSERT INTO [" + tblSchema + "].[" + tblName + "]";
            string columnPart = "(" + string.Join(",", columnList) + ")";
            string paramPart = "VALUES (" + string.Join(",", paramList.Select(c => "@" + c)) + ")";

            string command = string.Join(" ", insertPart, columnPart, paramPart);


            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand(command, con);
                foreach (SqlParameter p in parametersList)
                    com.Parameters.Add(p);

                return com.ExecuteNonQuery();
            }

        }


        //DELETE FROM [dbo].[****] WHERE [Id]=1 , ...
        public int Delete(TEntity entity)
        {
            List<string> conditionList = new List<string>();
            List<SqlParameter> parametersList = new List<SqlParameter>();

            int i = 1;
            foreach (var spec in ColumnsSpecifics)
            {
                if (!spec.PrimaryKey)
                    continue;

                conditionList.Add("[" + spec.ColumnName + "] = @param" + i);
                parametersList.Add(new SqlParameter("param" + i, spec.ColumnType.GetValue(entity)));
                i++;
            }

            string deletePart = "DELETE FROM [" + tblSchema + "].[" + tblName + "]";
            string wherePart = "WHERE (" + string.Join(",", conditionList) + ")";

            string command = string.Join(" ", deletePart, wherePart);


            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand(command, con);
                foreach (SqlParameter p in parametersList)
                    com.Parameters.Add(p);

                return com.ExecuteNonQuery();
            }

        }




        List<TEntity> SelectByPrimaryKeys(string selectPart, bool hasWhere, params int[] keys)
        {
            List<SqlParameter> parametersList = new List<SqlParameter>();
            List<string> conditionList = new List<string>();

            int i = 0;
            foreach (var spec in ColumnsSpecifics)
            {
                if (!spec.PrimaryKey)
                    continue;

                conditionList.Add("[" + spec.ColumnName + "] = @param" + i);
                parametersList.Add(new SqlParameter("param" + i, keys[i]));
                i++;
            }

            string wherePart = "";
            if (hasWhere)
                wherePart = "WHERE (" + string.Join(",", conditionList) + ")";
            


            string command = string.Join(" ", selectPart, wherePart);

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand(command, con);
                foreach (SqlParameter p in parametersList)
                    com.Parameters.Add(p);
                SqlDataReader reader = com.ExecuteReader();

                List<TEntity> entities = new List<TEntity>();
                while (reader.Read())
                {
                    TEntity entity = Activator.CreateInstance<TEntity>();
                    foreach (var spec in ColumnsSpecifics)
                    {
                        spec.ColumnType.SetValue(entity, reader[reader.GetOrdinal(spec.ColumnName)]);
                    }
                    entities.Add(entity);
                }
                return entities;
            }
        }


        //SELECT * FROM [dbo].[****] WHERE [Id]=1 , ....
        public TEntity Find(params int[] keys)
        {
            string selectPart = "SELECT TOP(1) * FROM [" + tblSchema + "].[" + tblName + "]";
            return SelectByPrimaryKeys(selectPart, true, keys).FirstOrDefault();
        }


        public List<TEntity> FindAll(params int[] keys)
        {
            string selectPart = "SELECT * FROM [" + tblSchema + "].[" + tblName + "]";
            return SelectByPrimaryKeys(selectPart, true, keys);
        }


        public List<TEntity> GetAll()
        {
            string selectPart = "SELECT * FROM [" + tblSchema + "].[" + tblName + "]";
            return SelectByPrimaryKeys(selectPart, false, 0);
        }

        public List<TEntity> Top()
        {
            string selectPart = "SELECT TOP(1) * FROM [" + tblSchema + "].[" + tblName + "]";
            return SelectByPrimaryKeys(selectPart, false, 0);
        }

    }
}