namespace TheGildedRose.ItemTypes.Interfaces
{
    public interface ICreatable<out T>
    {
        public static T CreateType(IDataRow data)
        {
            return default;
        }
    }
}