using RoyalEstateBackend.Dtos;

namespace RoyalEstateBackend.ResponseModels
{
    public class PropertyResponseModel : BaseResponse
    {
        public PropertyDto Data{get; set;}
    }
    public class PropertiesResponseModel : BaseResponse
    {
        public ICollection<PropertyDto> Data{get; set;} = new HashSet<PropertyDto>();
    }
}