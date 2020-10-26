using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReadAndWriteFileExcel
{
    public class DataProvider
    {
        public static MySql.Data.MySqlClient.MySqlConnection connection = GetDBConnection();
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            String connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
        public static MySqlConnection GetDBConnection()
        {
            return GetDBConnection(Config.host, Config.port, Config.database, Config.username, Config.password);
        }
        public static Hashtable ExecuteQuery(string query, string param, string value)
        {
            return ExecuteQuery(query, new Hashtable() { { param, value } });
        }
        public static Hashtable ExecuteQuery(string query, Hashtable table)
        {
            return ExecuteQueryMutil(query, table)[0];
        }
        public static List<Hashtable> ExecuteQueryMutil(string query, string param, string value)
        {
            return ExecuteQueryMutil(query, new Hashtable() { { param, value } });
        }
        public static List<Hashtable> ExecuteQueryMutil(string query, Hashtable table)
        {
            try
            {
                List<Hashtable> list = new List<Hashtable>();
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);

                if (table != null)
                {
                    foreach (DictionaryEntry item in table)
                        command.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                DataTable data = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(data);

                foreach (DataRow row in data.Rows)
                {
                    Hashtable ht = new Hashtable();
                    foreach (DataColumn col in data.Columns)
                    {
                        ht.Add(col.ColumnName, row[col.ColumnName]);
                    }
                    list.Add(ht);
                }

                return list;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            try
            {
                int data = 0;
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                return data;
            }
            catch (Exception ex)
            { }
            finally
            {
                connection.Close();
            }
            return -1;
        }
    }
}
