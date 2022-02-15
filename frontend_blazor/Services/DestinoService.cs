using System.Text.Json;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace frontend_blazor.Services;
public class DestinoService : IDestinoService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    private readonly string _url;

    public DestinoService(HttpClient client)
    {
        _client = client;
        _url = "destinos";
        _options = new JsonSerializerOptions { PropertyNamingPolicy = new SnakeCaseNamingPolicy() };
    }

    public async Task<WebResult<DestinoResponse>> CreateDestinoAsync(DestinoRequest destinoDto)
    {
        var response = await _client.PostAsJsonAsync(_url, destinoDto);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<WebResult<DestinoResponse>>(content, _options);
    }

    public Task<WebResult<DestinoResponse>> DeleteDestinoAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<WebResult<DestinoResponse>> GetDestinoAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<WebResult<ICollection<DestinoResponse>>> GetDestinosAsync()
    {
        try
        {
            var response = await _client.GetAsync(_url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<WebResult<ICollection<DestinoResponse>>>(content, _options);
        }
        catch (Exception ex)
        {
            return WebResponse.Error<ICollection<DestinoResponse>>(ex.Message);
        }
    }

    public Task<WebResult<DestinoResponse>> UpdateDestinoAsync(DestinoRequest destinoDto, long id)
    {
        throw new NotImplementedException();
    }
}
