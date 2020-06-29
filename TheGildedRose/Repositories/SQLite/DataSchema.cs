using Microsoft.Data.Sqlite;
using TheGildedRose.ItemTypes.Interfaces;

namespace TheGildedRose.Repositories.SQLite
{
    public enum Columns
    {
        Name = 0,
        SellIn = 1,
        Quality = 2,
        Type = 3,
        Id = 4
    }

    public struct DataRow : IDataRow
    {
        public string Name { get; set; }
        public int Quality { get; set; }
        public int SellIn { get; set; }
        public string DataType { get; set; }
        public string Id { get; set; }
    }

    public static class DataSchema
    {
        public static DataRow ExtractProperties(SqliteDataReader reader)
        {
            var name = reader.GetString((int) Columns.Name);
            var quality = reader.GetInt32((int) Columns.Quality);
            var sellIn = reader.GetInt32((int) Columns.SellIn);
            var dataType = reader.GetString((int) Columns.Type);
            var Id = reader.GetString((int) Columns.Id);
            
            return new DataRow()
            {
                Name = name, Quality = quality, SellIn = sellIn, DataType = dataType, Id = Id
            };
        }
    }
}