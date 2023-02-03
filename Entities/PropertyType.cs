using RoyalEstateBackend.Enums;

namespace RoyalEstateBackend.Entities
{
    public class PropertyType
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public ICollection<Property> Properties{get; set;} = new HashSet<Property>();
        public PropertyStatus Status{get; set;}
    }
}