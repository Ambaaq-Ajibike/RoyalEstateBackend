using RoyalEstateBackend.Enums;

namespace RoyalEstateBackend.Entities
{
    public class Property
    {
        public int Id{get; set;}
        public string Description{get; set;}
        public int AddressId{get; set;}
        public Address Address{get; set;}
        public decimal Price{get; set;}
        public int PropertyTypeId{get; set;}
        public PropertyStatus PropertyStatus{get; set;}
        public PropertyType PropertyType{get; set;}
        public ICollection<Utility> Utilities{get; set;} = new HashSet<Utility>();
        public ICollection<Image> Images{get; set;} = new HashSet<Image>();
        public string VideoPath{get; set;}
    }
}