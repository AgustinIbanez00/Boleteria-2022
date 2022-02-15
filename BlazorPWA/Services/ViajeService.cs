using System.Net.Http.Json;
using System.Text.Json;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BlazorPWA.Services;
public class ViajeService : IViajeService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    private readonly string _url;

    public ViajeService(HttpClient client)
    {
        _client = client;
        _url = "api/viajes";
        _options = new JsonSerializerOptions { PropertyNamingPolicy = new SnakeCaseNamingPolicy() };
    }

    public async Task<WebResult<ViajeResponse>> CreateViajeAsync(ViajeRequest viajeDto)
    {
        var response = await _client.PostAsJsonAsync(_url, viajeDto, _options);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<ViajeResponse>>(content, _options);
    }

    public async Task<WebResult<ViajeResponse>> DeleteViajeAsync(long id)
    {
        var response = await _client.DeleteAsync($"{_url}?id={id}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        Console.WriteLine("Delete viaje " + id);
        Console.WriteLine(content);

        return JsonSerializer.Deserialize<WebResult<ViajeResponse>>(content, _options);
    }

    public Task<WebResult<ViajeResponse>> GetViajeAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<WebResult<ICollection<ViajeResponse>>> GetViajesAsync()
    {
        try
        {
            var response = await _client.GetAsync(_url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<WebResult<ICollection<ViajeResponse>>>(content, _options);
        }
        catch (Exception ex)
        {
            return WebResponse.Error<ICollection<ViajeResponse>>(ex.Message);
        }
    }

    public Task<WebResult<ViajeResponse>> UpdateViajeAsync(ViajeUpdateRequest viajeDto)
    {
        throw new NotImplementedException();
    }
}
