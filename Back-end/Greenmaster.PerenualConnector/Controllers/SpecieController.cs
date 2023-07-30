using System.Net;
using Greenmaster.PerenualConnector.Base;
using Greenmaster.PerenualConnector.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Greenmaster.PerenualConnector.Controllers;

[ApiController]
[Route("specie")]
public class SpecieController : Controller
{
    private readonly HttpClient _client = new ();
    private const string ApiKey = "sk-SS9S64071821bec84175";
    
    [HttpGet("/all")]
    public async Task<JsonResult> Species(int pageNumber)
    {
        if (pageNumber<=0)
        {
            return new JsonResult(HttpStatusCode.BadRequest);
        }
        var path = "https://perenual.com/api/species-list?key=" + ApiKey + "&page=" + pageNumber;

        var response = await _client.GetAsync(path);
        switch (response.IsSuccessStatusCode)
        {
            case true:
                // Read response content as a string
                var responseContent = await response.Content.ReadAsStringAsync();
            
                // Deserialize response content into a model and return list
                var result = JsonConvert.DeserializeObject<ApiResponse<PerenualSpecie>>(responseContent);
                
                //TODO: needs to be converted to List<Specie> from Greenmaster.Core
                return new JsonResult(result);
            default:
                return new JsonResult(HttpStatusCode.BadRequest);
        }
    }
    
    
}