using Backend.Interface.Repositories;
using Mapster;
using RoyalEstateBackend.Dtos;
using RoyalEstateBackend.Entities;
using RoyalEstateBackend.Interfaces.Services;
using RoyalEstateBackend.ResponseModels;

namespace RoyalEstateBackend.Implementations.Service
{
    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly IRepository<PropertyType> _propertyTypeRepository;
        public PropertyTypeService(IRepository<PropertyType> propertyTypeRepository) => (_propertyTypeRepository) = (propertyTypeRepository);
        public async Task<BaseResponse> Add(PropertyTypeDto propertyTypeDto)
        {
            var adaptPropertyType = propertyTypeDto.Adapt<PropertyType>();
            await _propertyTypeRepository.Add(adaptPropertyType);
            return new BaseResponse
            {
                Message = "Property type Successfully created",
                Status = true
            };
        }
        public async Task<BaseResponse> GetAll()
        {
            var propertyTypes = await _propertyTypeRepository.GetAll(x => true);
            var adaptPropertyTypes = propertyTypes.Adapt<List<PropertyDto>>();
            return new 
        }
    }
}