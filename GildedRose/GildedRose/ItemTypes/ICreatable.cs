using GildedRose.Data;

namespace GildedRose.ItemTypes
{
    public interface ICreatable<out T>
    {
        public static T CreateType(DataRow data)
        {
            return default;
        }
    }
}