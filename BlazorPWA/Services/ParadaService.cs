using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BlazorPWA.Services;
public class ParadaService : IParadaService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    private readonly string _url;

    public ParadaService(HttpClient client)
    {
        _client = client;
        _url = "api/paradas";
        _options = new JsonSerializerOptions { PropertyNamingPolicy = new SnakeCaseNamingPolicy() };
    }

    public async Task<WebResult<ParadaDTO>> CreateAsync(ParadaDTO destinoDto)
    {
        var response = await _client.PostAsJsonAsync(_url, destinoDto);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<ParadaDTO>>(content, _options);
    }

    public async Task<WebResult<ParadaDTO>> DeleteAsync(long id)
    {
        var response = await _client.DeleteAsync($"{_url}?id={id}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<ParadaDTO>>(content, _options);
    }

    public async Task<WebResult<ParadaDTO>> GetAsync(long id)
    {
        var response = await _client.GetAsync($"{_url}/{id}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<ParadaDTO>>(content, _options);
    }

    public async Task<WebResult<PaginatedList<ParadaDTO>>> AllAsync(PaginationFilter parameters)
    {
        try
        {
            var response = await _client.GetAsync(_url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<WebResult<PaginatedList<ParadaDTO>>>(content, _options);
        }
        catch (Exception ex)
        {
            return WebResponse.Error<PaginatedList<ParadaDTO>>(ex.Message);
        }
    }

    public async Task<WebResult<ParadaDTO>> UpdateAsync(ParadaDTO request, long id)
    {
        HttpContent httpContent = new StringContent(JsonSerializer.Serialize(request, _options), Encoding.UTF8, "application/json-patch+json");
        var response = await _client.PatchAsync($"{_url}/{id}", httpContent);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<ParadaDTO>>(content, _options);
    }

    public Task<WebResultList<ParadaDTO>> AllAsync(ParadaFilter parameters)
    {
        throw new NotImplementedException();
    }

    public Task<WebResult<ParadaDTO>> GetAsync(ParadaFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<WebResult<ParadaDTO>> UpdateAsync(ParadaDTO request, ParadaFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<WebResult<ParadaDTO>> DeleteAsync(ParadaFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<WebResult<ParadaDTO>> ValidateAsync(ParadaDTO request)
    {
        throw new NotImplementedException();
    }
}
