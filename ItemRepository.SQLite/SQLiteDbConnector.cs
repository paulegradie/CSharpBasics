using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using ItemRepository.Interface;
using ItemTypes.Interface;
using ItemTypes.Types;

namespace ItemRepository.SQLite
{
    public class SqLiteDbConnector : DbConnectorBase, IDbConnector
    {
        private const string SqLitePrefix = "Data Source=";
        private SQLiteConnection Connection { get; set; }

        public static IDbConnector CreateDatabaseConnection()
        {
            const string defaultDbName = "Items.sqlite";
            return new SqLiteDbConnector(defaultDbName);
        }

        public static IDbConnector CreateDatabaseConnection(string dbFileName)
        {
            return new SqLiteDbConnector(dbFileName);
        }

        private SqLiteDbConnector(string dbFileName)
        {
            var connectionString = GetConnectionString(dbFileName);
            Connection = new SQLiteConnection(connectionString);
        }

        protected sealed override string GetConnectionString(string dbFileName)
        {
            var dirParts = CurrentWorkingDirectory.Split(Sep, StringSplitOptions.RemoveEmptyEntries);
            var connectionString =
                SqLitePrefix + string.Join(Sep, dirParts.Take(dirParts.Length - 3)) + Sep + dbFileName;
            return connectionString;
        }

        public IEnumerable<IUpdateableItem> RetrieveData()
        {
            var dataQuery = $"SELECT * FROM Items";

            Connection.Open();
            using var cmd = new SQLiteCommand(dataQuery, Connection);
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
            using var cmd = new SQLiteCommand(dataQuery, Connection);
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