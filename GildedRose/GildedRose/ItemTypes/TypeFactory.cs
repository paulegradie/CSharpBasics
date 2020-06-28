using System.IO;
using GildedRose.Data;

namespace GildedRose.ItemTypes
{
    public static class TypeFactory
    {
        public static IUpdateableItem BindType(DataRow data)
        {
            IUpdateableItem returnType;
            switch (data.DataType)
            {
                case "Conjure":
                    returnType = ConjureType.CreateType(data);
                    break;
                case "Legendary":
                    returnType = LegendaryType.CreateType(data);
                    break;
                case "Appreciate":
                    returnType = AppreciateType.CreateType(data);
                    break;
                case "Concert":
                    returnType = ConcertType.CreateType(data);
                    break;
                case "Depreciate":
                    returnType = DeprecatingType.CreateType(data);
                    break;
                default:
                    throw new IOException($"Type {data.DataType} not supported.");
            }

            return returnType;
        }
    }
}