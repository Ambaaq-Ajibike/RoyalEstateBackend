using Microsoft.AspNetCore.Mvc;
using RoyalEstateBackend.Dtos;
using RoyalEstateBackend.Enums;
using RoyalEstateBackend.Interfaces.Services;

namespace RoyalEstateBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IPropertyService _propertyService;
    public PropertyController(IPropertyService propertyService) => (_propertyService) = (propertyService);
    [HttpPost("property/add")]
    public async Task<IActionResult> Add(PropertyDto property)
    {
        var response = await _propertyService.Add(property);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpPatch("property/addUtility/{propertyId}")]
    public async Task<IActionResult> AddUtility([FromRoute]int propertyId, UtilityDto utilityDto)
    {
        var response = await _propertyService.AddUtility(propertyId, utilityDto);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpPatch("property/updateAddress/{propertyId}")]
    public async Task<IActionResult> UpdateAddress([FromRoute]int propertyId, AddressDto addressDto)
    {
        var response = await _propertyService.UpdateAddress(propertyId, addressDto);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpPatch("property/updateDescription/{propertyId}")]
    public async Task<IActionResult> UpdateDescription([FromRoute]int propertyId, string description)
    {
        var response = await _propertyService.UpdateDescription(propertyId, description);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpPatch("property/updateImage/{imageId}/{path}")]
    public async Task<IActionResult> UpdateImage([FromRoute]int imageId, [FromRoute]string path)
    {
        var response = await _propertyService.UpdateImage(imageId, path);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpPatch("property/updateVideo/{propertyId}/{VideoPath}")]
    public async Task<IActionResult> UpdateVideo(int propertyId, string VideoPath)
    {
        var response = await _propertyService.UpdateVideo(propertyId, VideoPath);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpPatch("property/updatePropertyStatus/{propertyId}")]
    public async Task<IActionResult> UpdatePropertyStatus([FromRoute]int propertyId, PropertyStatus propertyStatus)
    {
        var response = await _propertyService.UpdatePropertyStatus(propertyId, propertyStatus);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpDelete("property/deleteImage/{imageId}")]
    public async Task<IActionResult> DeleteImage(int imageId)
    {
        var response = await _propertyService.DeleteImage(imageId);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpDelete("property/deleteUtility/{imageId}")]
    public async Task<IActionResult> DeleteUtility(int utilityId)
    {
        var response = await _propertyService.DeleteUtility(utilityId);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpDelete("property/deleteProperty/{imageId}")]
    public async Task<IActionResult> DeleteProperty(int propertyId)
    {
        var response = await _propertyService.Delete(propertyId);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpGet("property/getProperty/{propertyId}")]
    public async Task<IActionResult> GetProperty(int propertyId)
    {
        var response = await _propertyService.Get(propertyId);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpGet("property/getByPropertyType/{propertyTypeId}")]
    public async Task<IActionResult> GetByPropertyType(int propertyTypeId)
    {
        var response = await _propertyService.GetByPropertyType(propertyTypeId);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpGet("property/getByPropertyStatus/{propertyTypeId}")]
    public async Task<IActionResult> GetByPropertyStatus(PropertyStatus status)
    {
        var response = await _propertyService.GetByPropertyStatus(status);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
    [HttpGet("property/search/{propertyTypeId}")]
    public async Task<IActionResult> Search(SearchPropertyModel searchPropertyModel)
    {
        var response = await _propertyService.Search(searchPropertyModel);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
}
