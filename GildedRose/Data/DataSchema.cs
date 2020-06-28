using System.Data.SQLite;

namespace GildedRose.Data
{
    public enum Columns
    {
        Name = 0,
        SellIn = 1,
        Quality = 2,
        Type = 3
    }

    public struct DataRow
    {
        public string Name { get; set; }
        public int Quality { get; set; }
        public int SellIn { get; set; }
        public string DataType { get; set; }
    }

    public static class DataSchema
    {
        public static DataRow ExtractProperties(SQLiteDataReader reader)
        {
            var name = reader.GetString((int) Columns.Name);
            var quality = reader.GetInt32((int) Columns.Quality);
            var sellIn = reader.GetInt32((int) Columns.SellIn);
            var dataType = reader.GetString((int) Columns.Type);

            return new DataRow()
            {
                Name = name, Quality = quality, SellIn = sellIn, DataType = dataType
            };
        }
    }
}