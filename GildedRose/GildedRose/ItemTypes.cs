namespace GildedRose
{

    public class BaseType
    {
        protected BaseType(string itemType)
        {
            ItemType = itemType;
        }

        private string ItemType { get; }
        public override string ToString()
        {
            return ItemType;
        }
    }
    
    public class ConjureType : BaseType
    {
        private ConjureType() : base("Conjure") { }
    }

    public class LegendaryType : BaseType
    {
        private LegendaryType() : base("Legendary") { }
    }

    public class AppreciateType : BaseType
    {
        private AppreciateType() : base("Appreciate") { }
    }

    public class ConcertType : BaseType
    {
        private ConcertType() : base("Concert") {}
    }

    public class DeprecatingType : BaseType
    {
        private DeprecatingType() : base("Depreciate")
        { }
    }
}