using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TheGildedRose.ItemTypes.Interfaces;
using TheGildedRose.ItemTypes.Types;
using TheGildedRose.Repositories.Interfaces;
using Microsoft.Data.Sqlite;

namespace TheGildedRose.Repositories.SQLite
{
    public class SqLiteDbConnector : DbConnectorBase, IDbConnector
    {
        private const string SqLitePrefix = "Data Source=";
        private const string DataSource= "AppData\\Items.sqlite";
        private SqliteConnection Connection { get; set; }

        public static IDbConnector CreateDatabaseConnection()
        {
            return new SqLiteDbConnector(DataSource);
        }

        private SqLiteDbConnector(string dbFileName)
        {
            var connectionString = GetConnectionString(dbFileName);
            Connection = new SqliteConnection(connectionString);
        }

        private string GetConnectionString(string dbFileName)
        {
            var dirParts = CurrentWorkingDirectory.Split(Sep, StringSplitOptions.RemoveEmptyEntries);
            var connectionString = // not sure how else to configure this yet
                SqLitePrefix + string.Join(Sep, dirParts.Take(dirParts.Length - 3)) + Sep + dbFileName;
            return connectionString;
        }

        public IEnumerable<IUpdateableItem> RetrieveData()
        {
            var dataQuery = "SELECT * FROM Items";

            Connection.Open();
            using var cmd = new SqliteCommand(dataQuery, Connection);
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

        public IUpdateableItem RetrieveDataById(string id)
        {
            var dataQuery = $"SELECT * FROM Items WHERE Id={id}";
            Connection.Open();
            using var cmd = new SqliteCommand(dataQuery, Connection);
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
            if (items.Count() > 1)
            {
                throw new DataException("Duplicate Ids found in the database.");
            }

            return items[0];
        }
    }
}