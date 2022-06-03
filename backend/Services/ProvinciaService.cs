using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Services;

using static WebResponse;
public class ProvinciaService : IProvinciaService
{
    private readonly IMapper _mapper;
    private readonly IProvinciaRepository _provinciaRepository;

    public ProvinciaService(IMapper mapper, IProvinciaRepository provinciaRepository)
    {
        _mapper = mapper;
        _provinciaRepository = provinciaRepository;
    }

    public async Task<WebResult<List<ProvinciaDTO>>> AllAsync(ProvinciaFilter parameters)
    {
        try
        {
            ICollection<Data.Models.Provincia> provincias = await _provinciaRepository.GetAllAsync(parameters);

            List<ProvinciaDTO> provinciasDTO = new();

            foreach (Data.Models.Provincia provincia in provincias)
            {
                provinciasDTO.Add(_mapper.Map<ProvinciaDTO>(provincia));
            }
            return Ok(provinciasDTO);
        }
        catch (Exception ex)
        {
            return Error<List<ProvinciaDTO>>(ErrorMessage.Generic, ex.Message);
        }
    }
}
