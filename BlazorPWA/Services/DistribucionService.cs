using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BlazorPWA.Services;
public class DistribucionService : IDistribucionService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    private readonly string _url;
    public DistribucionService(HttpClient client)
    {
        _client = client;
        _url = "api/distribuciones";
        _options = new JsonSerializerOptions { PropertyNamingPolicy = new SnakeCaseNamingPolicy() };
    }

    public async Task<WebResult<DistribucionResponse>> AppendFilasAsync(long id, Planta planta)
    {
        var response = await _client.PostAsJsonAsync($"{_url}/{id}/filas/{(int)planta}", planta);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<DistribucionResponse>>(content, _options);
    }

    public async Task<WebResult<DistribucionResponse>> CreateDistribucionAsync(DistribucionRequest DistribucionDto)
    {
        var response = await _client.PostAsJsonAsync(_url, DistribucionDto);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<DistribucionResponse>>(content, _options);
    }

    public async Task<WebResult<DistribucionResponse>> DeleteDistribucionAsync(long id)
    {
        var response = await _client.DeleteAsync($"{_url}?id={id}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<DistribucionResponse>>(content, _options);
    }

    public async Task<WebResult<DistribucionResponse>> GetDistribucionAsync(long id)
    {
        var response = await _client.GetAsync($"{_url}/{id}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<DistribucionResponse>>(content, _options);
    }

    public async Task<WebResult<ICollection<DistribucionResponse>>> GetDistribucionesAsync()
    {
        try
        {
            var response = await _client.GetAsync(_url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<WebResult<ICollection<DistribucionResponse>>>(content, _options);
        }
        catch (Exception ex)
        {
            return WebResponse.Error<ICollection<DistribucionResponse>>(ex.Message);
        }
    }

    public async Task<WebResult<DistribucionResponse>> UpdateDistribucionAsync(DistribucionUpdateRequest request)
    {
        try
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(request, _options), Encoding.UTF8, "application/json-patch+json");
            var response = await _client.PatchAsync($"{_url}/{request.Id}", httpContent);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<WebResult<DistribucionResponse>>(content, _options);
        }
        catch (Exception ex)
        {
            return WebResponse.Error<DistribucionResponse>(ex.Message);
        }
    }
}
