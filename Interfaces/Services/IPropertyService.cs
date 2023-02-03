using RoyalEstateBackend.Dtos;
using RoyalEstateBackend.Enums;
using RoyalEstateBackend.ResponseModels;

namespace RoyalEstateBackend.Interfaces.Services
{
    public interface IPropertyService
    {
        Task<BaseResponse> Add(PropertyDto property);
        Task<BaseResponse> AddUtility(int propertyId, UtilityDto utilityDto);
        Task<BaseResponse> UpdateUtility(UtilityDto utilityDto);
        Task<BaseResponse> UpdateAddress(int propertyId, AddressDto addressDto);
        Task<BaseResponse> UpdateDescription(int propertyId, string description);
        Task<BaseResponse> UpdateImage(int imageId, string path);
        Task<BaseResponse> UpdateVideo(int propertyId, string VideoPath);
        Task<BaseResponse> DeleteImage(int imageId);
        Task<BaseResponse> DeleteUtility(int id);
        Task<BaseResponse> UpdatePropertyStatus(int propertyId, PropertyStatus propertyStatus);
        Task<PropertyResponseModel> Get(int propertyId);
        Task<PropertiesResponseModel> GetByPropertyType(int propertyTypeId);
        Task<PropertiesResponseModel> GetByPropertyStatus(PropertyStatus status);
        Task<PropertiesResponseModel> Search(SearchPropertyModel searchPropertyModel);
        Task<BaseResponse> Delete(int id);
    }
}