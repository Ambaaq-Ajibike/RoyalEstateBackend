using Microsoft.AspNetCore.Mvc;
using RoyalEstateBackend.Dtos;
using RoyalEstateBackend.Interfaces.Services;

namespace RoyalEstateBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertyTypeController : ControllerBase
{
    private readonly IPropertyTypeService _propertyTypeService;
    public PropertyTypeController(IPropertyTypeService propertyTypeService) => (_propertyTypeService) = (propertyTypeService);
    [HttpPost("propertyType/add")]
    public async Task<IActionResult> Add(PropertyTypeDto propertyType)
    {
        var response = await _propertyTypeService.Add(propertyType);
        return (response.Status) ? Ok(response) : BadRequest(response);
    }
}
