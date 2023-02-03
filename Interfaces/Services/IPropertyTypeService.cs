using RoyalEstateBackend.Dtos;
using RoyalEstateBackend.ResponseModels;

namespace RoyalEstateBackend.Interfaces.Services
{
    public interface IPropertyTypeService
    {
        Task<BaseResponse> Add(PropertyTypeDto property);
        
    }
}