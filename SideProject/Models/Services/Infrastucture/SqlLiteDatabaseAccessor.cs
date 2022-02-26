using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SideProject.Models.Services.Infrastucture
{
    public class SqlLiteDatabaseAccessor : IDatabaseAccessor
    {
        public async Task<DataSet> QueryAsync(FormattableString formattableQuery)
        {

            var queryArguments = formattableQuery.GetArguments();
            var sqlParamaters = new List<SqliteParameter>();
            for (int i = 0; i < queryArguments.Length; i++)
            {
                var parameter = new SqliteParameter(i.ToString(), queryArguments[i]);
                sqlParamaters.Add(parameter);
                queryArguments[i] = "@" + i;
            }

            string query = formattableQuery.ToString();


            using (SqliteConnection conn = new SqliteConnection("Data Source=Data/MyCourses.db"))
            {
                await conn.OpenAsync();
                using (SqliteCommand cmd = new SqliteCommand(query , conn))
                {
                    cmd.Parameters.AddRange(sqlParamaters);
                    using (SqliteDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        DataSet dataSet = new DataSet();

                        do
                        {
                            DataTable dataTable = new DataTable();
                            dataSet.Tables.Add(dataTable);
                            dataTable.Load(reader);
                        } while (!reader.IsClosed);
                       return dataSet;
                    }
                }
            }
        }
    }
}
