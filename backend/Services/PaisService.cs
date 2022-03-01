using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data.Models;
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

    public async Task<WebResultList<PaisDTO>> AllAsync(PaisFilter parameters)
    {
        try
        {
            PaginatedList<Pais> paises = await _paisRepository.GetAllAsync(parameters);

            var paisesDTO = new List<PaisDTO>();

            foreach (var pais in paises)
            {
                paisesDTO.Add(_mapper.Map<PaisDTO>(pais));
            }
            return List(paisesDTO, Pagination.Page(paises.TotalItems, parameters.Pagina, parameters.RecordsPorPagina));
        }
        catch (Exception ex)
        {
            return ErrorList<Parada, PaisDTO>(ErrorMessage.Generic, ex.Message);
        }
    }
}
