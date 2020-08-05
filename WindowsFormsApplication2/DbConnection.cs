using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devart.Data.PostgreSql;


namespace MyConnection
{
    partial class DbConnection : IDisposable
    {
        private PgSqlConnection conn;
            
        public DbConnection(bool autoconnect = false)
        {
            conn = new PgSqlConnection();
            conn.Host = "localhost";
            conn.Port = 5432;
            conn.Database = "DataBase";
            conn.UserId = "postgres";
            conn.Password = "pasword";
            if (autoconnect == true)
            {
                conn.Open();
            }
        }

        public void Open()
        {
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
        }

        public void Dispose()
        {
            conn.Dispose();
        }

        public bool GetInt32(string query, string field, out int value)
        {
            bool found = false;
            value = 0;

            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = query;

                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read() == true)
                    {
                        value = dr.GetInt32(field);
                        found = true;
                    }

                    dr.Close();
                }
            }

            return found;
        }

        public bool GetDecimal(string query, string field, out decimal value)
        {
            bool found = false;
            value = 0;

            using (PgSqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = query;

                using (PgSqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read() == true)
                    {
                        value = dr.GetDecimal(field);
                        found = true;
                    }

                    dr.Close();
                }
            }

            return found;
        }
    }
}