using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BlazorPWA.Services;
public class DestinoService : IParadaService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    private readonly string _url;

    public DestinoService(HttpClient client)
    {
        _client = client;
        _url = "api/paradas";
        _options = new JsonSerializerOptions { PropertyNamingPolicy = new SnakeCaseNamingPolicy() };
    }

    public async Task<WebResult<ParadaDTO>> CreateParadaAsync(ParadaDTO destinoDto)
    {
        var response = await _client.PostAsJsonAsync(_url, destinoDto);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<ParadaDTO>>(content, _options);
    }

    public async Task<WebResult<ParadaDTO>> DeleteParadaAsync(long id)
    {
        var response = await _client.DeleteAsync($"{_url}?id={id}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<ParadaDTO>>(content, _options);
    }

    public async Task<WebResult<ParadaDTO>> GetParadaAsync(long id)
    {
        var response = await _client.GetAsync($"{_url}/{id}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<ParadaDTO>>(content, _options);
    }

    public async Task<WebResult<PaginatedList<ParadaDTO>>> GetParadasAsync(Pagination parameters)
    {
        try
        {
            var response = await _client.GetAsync(_url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<WebResult<ICollection<ParadaDTO>>>(content, _options);
        }
        catch (Exception ex)
        {
            return WebResponse.Error<ICollection<ParadaDTO>>(ex.Message);
        }
    }

    public async Task<WebResult<ParadaDTO>> UpdateParadaAsync(ParadaDTO request, long id)
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
}
