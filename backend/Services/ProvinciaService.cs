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
public class ProvinciaService : IProvinciaService
{
    private readonly IMapper _mapper;
    private readonly IProvinciaRepository _provinciaRepository;

    public ProvinciaService(IMapper mapper, IProvinciaRepository provinciaRepository)
    {
        _mapper = mapper;
        _provinciaRepository = provinciaRepository;
    }

    public async Task<WebResultList<ProvinciaDTO>> AllAsync(ProvinciaFilter parameters)
    {
        try
        {
            PaginatedList<Provincia> provincias = await _provinciaRepository.GetAllAsync(parameters);

            var provinciasDTO = new List<ProvinciaDTO>();

            foreach (var provincia in provincias)
            {
                provinciasDTO.Add(_mapper.Map<ProvinciaDTO>(provincia));
            }
            return List(provinciasDTO, Pagination.Page(provincias.TotalItems, parameters.Pagina, parameters.RecordsPorPagina));
        }
        catch (Exception ex)
        {
            return ErrorList<ProvinciaDTO>(ErrorMessage.Generic, ex.Message);
        }
    }
}
