using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Services;

using static WebResponse;
public class PaisService : IPaisService
{
    private readonly IMapper _mapper;
    private readonly IPaisRepository _paisRepository;

    public PaisService(IMapper mapper, IPaisRepository paisRepository)
    {
        _mapper = mapper;
        _paisRepository = paisRepository;
    }

    public async Task<WebResult<List<PaisDTO>>> AllAsync(PaisFilter parameters)
    {
        try
        {
            ICollection<Data.Models.Pais> paises = await _paisRepository.GetAllAsync(parameters);

            List<PaisDTO> paisesDTO = new();

            foreach (Data.Models.Pais pais in paises)
            {
                paisesDTO.Add(_mapper.Map<PaisDTO>(pais));
            }
            return Ok(paisesDTO);
        }
        catch (Exception ex)
        {
            return Error<List<PaisDTO>>(ErrorMessage.Generic, ex.Message);
        }
    }
}
