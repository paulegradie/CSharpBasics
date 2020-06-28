namespace ItemTypes.Interface
{
    public interface ICreatable<out T>
    {
        public static T CreateType(IDataRow data)
        {
            return default;
        }
    }
}