using Backend.Interface.Repositories;
using Mapster;
using RoyalEstateBackend.Dtos;
using RoyalEstateBackend.Entities;
using RoyalEstateBackend.Enums;
using RoyalEstateBackend.Interfaces.Services;
using RoyalEstateBackend.ResponseModels;

namespace RoyalEstateBackend.Implementations.Service
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepository<Property> _propertyRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<Image> _imageRepository;
        private readonly IRepository<Utility> _utilityRepository;
        public PropertyService(IRepository<Property> propertiesRepository, IRepository<Address> addressRepository, IRepository<Image> imageRepository, IRepository<Utility> utilityRepository) => (_propertyRepository, _addressRepository, _imageRepository, _utilityRepository) = (propertiesRepository, addressRepository, imageRepository, utilityRepository);
        public async Task<BaseResponse> Add(PropertyDto propertyDto)
        {
            var address = propertyDto.Address.Adapt<Address>();
            var addedAddress = await _addressRepository.Add(address);
            var property = new Property{
                Address = address,
                AddressId = addedAddress.Id,
                Description = propertyDto.Description,
                PropertyStatus = propertyDto.PropertyStatus,
                PropertyTypeId = propertyDto.PropertyTypeId,
                Price = propertyDto.Price,
                VideoPath = propertyDto.VideoPath
            };
            var addedProperty = await _propertyRepository.Add(property);
            foreach (var img in propertyDto.Images)
            {
                img.PropertyId = addedProperty.Id;
                var image = img.Adapt<Image>();
                await _imageRepository.Add(image);
            }
            
            foreach (var ut in propertyDto.Utilities)
            {
                ut.PropertyId = addedProperty.Id;
                var utility = ut.Adapt<Utility>();
                await _utilityRepository.Add(utility);
            }
            
            return new BaseResponse
            {
                Message = "Property created successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> AddUtility(int propertyId, UtilityDto utilityDto)
        {
            var property = await _propertyRepository.Get(x => x.Id == propertyId);
            if(property is null)
            {
                return new BaseResponse{
                    Message = "Property not found",
                    Status = false
                };
            }
            var utility = utilityDto.Adapt<Utility>();
            property.Utilities.Add(utility);
            await _propertyRepository.Update(property);
            return new BaseResponse{
                Message = "Utility added to property successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> Delete(int id)
        {
            var property = await _propertyRepository.Get(p => p.Id == id);
            if(property == null)
            {
                return new BaseResponse{
                    Message = "Property not found",
                    Status = false
                };
            }
            await _propertyRepository.Delete(property);
            return new BaseResponse{
                Message = "Property deleted successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> DeleteImage(int imageId)
        {
            var image = await _imageRepository.Get(p => p.Id == imageId);
            if(image == null)
            {
                return new BaseResponse{
                    Message = "image not found",
                    Status = false
                };
            }
            await _imageRepository.Delete(image);
            return new BaseResponse{
                Message = "image deleted successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> DeleteUtility(int id)
        {

            var utility = await _utilityRepository.Get(p => p.Id == id);
            if(utility == null)
            {
                return new BaseResponse{
                    Message = "utility not found",
                    Status = false
                };
            }
            await _utilityRepository.Delete(utility);
            return new BaseResponse{
                Message = "utility deleted successfully",
                Status = true
            };
        }

        public async Task<PropertyResponseModel> Get(int propertyId)
        {
            var property = await _propertyRepository.Get(p => p.Id == propertyId);
            if(property == null)
            {
                return new PropertyResponseModel{
                    Message = "Property not found",
                    Status = false
                };
            }
            return new PropertyResponseModel{
                Data = property.Adapt<PropertyDto>(),
                Message = "Property retrieved successfully",
                Status = true
            };
        }

        public async Task<PropertiesResponseModel> GetByPropertyType(int propertyTypeId)
        {
            var properties = await _propertyRepository.GetAll(x => x.PropertyTypeId == propertyTypeId);
            if(properties.Count == 0)
            {
                return new PropertiesResponseModel{
                Message = "No properties with the specified property type",
                Status = false
            };
            }
            return new PropertiesResponseModel{
                Data = properties.Adapt<List<PropertyDto>>(),
                Message = "Properties retrieved successfully",
                Status = true
            };
        }
        public async Task<PropertiesResponseModel> GetByPropertyStatus(PropertyStatus status)
        {
            var properties = await _propertyRepository.GetAll(x => x.PropertyStatus == status);
            if(properties.Count == 0)
            {
                return new PropertiesResponseModel{
                Message = "No properties with the specified property status",
                Status = false
            };
            }
            return new PropertiesResponseModel{
                Data = properties.Adapt<List<PropertyDto>>(),
                Message = "Properties retrieved successfully",
                Status = true
            };
        }

        public async Task<PropertiesResponseModel> Search(SearchPropertyModel searchPropertyModel)
        {
           var properties = await _propertyRepository.GetAll(x => searchPropertyModel.Location == x.Address.Country || searchPropertyModel.Location == x.Address.Description || searchPropertyModel.Location == x.Address.State || searchPropertyModel.Location == x.Address.LocalGovt || searchPropertyModel.Location == x.Address.Street || searchPropertyModel.PropertyStatus == x.PropertyStatus.ToString() || searchPropertyModel.PropertyType == x.PropertyType.Name || x.Utilities.Where(x => x.Name == searchPropertyModel.Utility).Count() > 0);
            if(properties.Count == 0)
            {
                return new PropertiesResponseModel{
                Message = "No properties with the specified property status",
                Status = false
            };
            }
            return new PropertiesResponseModel{
                Data = properties.Adapt<List<PropertyDto>>(),
                Message = "Properties retrieved successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> UpdateAddress(int propertyId, AddressDto addressDto)
        {
            var property = await _propertyRepository.Get(p => p.Id == propertyId);
            if(property == null)
            {
                return new BaseResponse{
                    Message = "Property not found",
                    Status = false
                };
            }
            var address = addressDto.Adapt<Address>();
            await _addressRepository.Update(address);
            return new BaseResponse{
                Message = "Address updated successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> UpdateDescription(int propertyId, string description)
        {
            var property = await _propertyRepository.Get(p => p.Id == propertyId);
            if(property == null)
            {
                return new PropertyResponseModel{
                    Message = "Property not found",
                    Status = false
                };
            }
            property.Description = description;
            await _propertyRepository.Update(property);
            return new PropertyResponseModel{
                Data = property.Adapt<PropertyDto>(),
                Message = "Property updated successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> UpdateImage(int imageId, string path)
        {
            var image = await _imageRepository.Get(p => p.Id == imageId);
            if(image == null)
            {
                return new BaseResponse{
                    Message = "Image not found",
                    Status = false
                };
            }
            image.Path = path;
            await _imageRepository.Update(image);
            return new BaseResponse{
                Message = "Image updated successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> UpdatePropertyStatus(int propertyId, PropertyStatus propertyStatus)
        {
            var property = await _propertyRepository.Get(p => p.Id == propertyId);
            if(property == null)
            {
                return new BaseResponse{
                    Message = "Property not found",
                    Status = false
                };
            }
            property.PropertyStatus = propertyStatus;
            await _propertyRepository.Update(property);
            return new BaseResponse{
                Message = "Property updated successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> UpdateUtility(UtilityDto utilityDto)
        {
            var utility = await _utilityRepository.Get(p => p.Id == utilityDto.Id);
            if(utility == null)
            {
                return new BaseResponse{
                    Message = "utility not found",
                    Status = false
                };
            }
            utility.Name = utilityDto.Name;
            await _utilityRepository.Update(utility);
            return new BaseResponse{
                Message = "utility updated successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> UpdateVideo(int propertyId, string VideoPath)
        {
            var property = await _propertyRepository.Get(p => p.Id == propertyId);
            if(property == null)
            {
                return new BaseResponse{
                    Message = "Property not found",
                    Status = false
                };
            }
            property.VideoPath = VideoPath;
            await _propertyRepository.Update(property);
            return new BaseResponse{
                Message = "Property updated successfully",
                Status = true
            };
        }
    }
}