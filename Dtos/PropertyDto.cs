using RoyalEstateBackend.Enums;

namespace RoyalEstateBackend.Dtos
{
    public class PropertyDto
    {
        public int? PropertyId{get; set;}
        public string Description{get; set;}
        public AddressDto Address{get; set;}
        public decimal Price{get; set;}
        public int PropertyTypeId{get; set;}
        public PropertyStatus PropertyStatus{get; set;}
        public ICollection<UtilityDto> Utilities{get; set;} = new HashSet<UtilityDto>();
        public ICollection<ImageDto> Images{get; set;} = new HashSet<ImageDto>();
        public string VideoPath{get; set;}
    }
}