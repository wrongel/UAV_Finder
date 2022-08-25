using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

class Query
{
    //public static string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UAV_Base;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    public static string connect = "Data Source = UAV.db; Version = 3";


    public static bool TryConnect()
    {
        try
        {
            using (SQLiteConnection Connection = new SQLiteConnection(connect))
            {
                SQLiteCommand Command = new SQLiteCommand("SELECT * FROM Human_V", Connection);    // Любой запрос для проверки подключения
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
                Connection.Dispose();
            }
        }
        catch(Exception e)
        {
            MessageBox.Show("Ошибка подключения к базе данных\n" + e.Message, "Ошибка");
            return false;
        }
        return true;
    }

    public static void InUpDel(string query, ref bool rez)
    {
        using (SQLiteConnection Connection = new SQLiteConnection(connect))
        {
            SQLiteCommand Command = new SQLiteCommand(query, Connection);
            Connection.Open();
            try
            {
                if (Command.ExecuteNonQuery() == 1) // если 1 то добавлено
                    rez = true;
                else
                    rez = false;
            }
            catch (Exception e)
            {
                if (!e.Message.Contains("UNIQUE"))      // Если исключение не об ункальности записи
                    MessageBox.Show(e.Message);
            }
            Connection.Close();
            Connection.Dispose();
        }
    }

    public static List<string[]> Select(string query)
    {
        List<string[]> List_db = new List<string[]>();
        string[] str_bd;

        using (SQLiteConnection Connection = new SQLiteConnection(connect))
        {
            SQLiteCommand Command = new SQLiteCommand(query, Connection);
            Connection.Open();
            try
            {
                SQLiteDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    str_bd = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        str_bd[i] = reader[i].ToString();
                    }
                    List_db.Add(str_bd);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            Connection.Close();
            Connection.Dispose();
        }

        return List_db;
    }
}
