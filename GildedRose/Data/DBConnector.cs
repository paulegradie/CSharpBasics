using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using GildedRose.ItemTypes;

namespace GildedRose.Data
{
    /// <summary>
    /// A thing to connect to the sqlite file for development
    /// Later to be replaced with repository using repository pattern
    /// </summary>
    public class DbConnector
    {
        private const string SqlitePrefix = "Data Source=";
        private const char Sep = '\\';
        private static string CurrentWorkingDirectory => Directory.GetCurrentDirectory();
        private SQLiteConnection Connection { get; set; }
        private const string DataQuery = "SELECT * FROM Items";


        private DbConnector(string dbFileName = "Items.sqlite")
        {
            var connectionString = GetSqliteConnectionString(dbFileName);
            Connection = new SQLiteConnection(connectionString);
        }

        private string GetSqliteConnectionString(string dbFileName)
        {
            var dirParts = CurrentWorkingDirectory.Split(Sep, StringSplitOptions.RemoveEmptyEntries);
            var connectionString =
                SqlitePrefix + string.Join(Sep, dirParts.Take(dirParts.Length - 3)) + Sep + dbFileName;
            return connectionString;
        }

        public static DbConnector CreateDatabaseConnection(string dbFileName = "Items.sqlite")
        {
            return new DbConnector(dbFileName);
        }

        public List<IUpdateableItem> RetrieveData()
        {
            Connection.Open();
            using var cmd = new SQLiteCommand(DataQuery, Connection);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) throw new IOException("No data available");

            var items = new List<IUpdateableItem>();
            while (reader.Read())
            {
                var dataRow = DataSchema.ExtractProperties(reader);
                var item = TypeFactory.BindType(dataRow);
                items.Add(item);
            }

            Connection.Close();
            return items;
        }
    }
}