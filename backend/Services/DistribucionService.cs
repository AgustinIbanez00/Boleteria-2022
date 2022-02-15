using AutoMapper;
using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Extensions;
using BoleteriaOnline.Web.Repositories;
using EntityFramework.Exceptions.Common;

namespace BoleteriaOnline.Web.Services;
using static WebResponse;
public class DistribucionService : IDistribucionService
{
    private readonly IMapper _mapper;
    private readonly IDistribucionRepository _distribucionRepository;
    private const int MAX_ITEMS_PER_PLANTA = 25;

    public DistribucionService(IMapper mapper, IDistribucionRepository distribucionRepository)
    {
        _mapper = mapper;
        _distribucionRepository = distribucionRepository;
    }

    public async Task<WebResult<DistribucionResponse>> CreateDistribucionAsync(DistribucionRequest distribucionDto)
    {
        try
        {
            var distribucion = _mapper.Map<Distribucion>(distribucionDto);

            if(distribucion.Filas.Count == 0)
                return Error<Distribucion, DistribucionResponse>(ErrorMessage.EmptyList);
            else
            {
                foreach (var fila in distribucion.Filas)
                {
                    if(fila.Cells.Count == 0)
                        return Error<DistribucionResponse>($"Se encontró una fila sin celdas.");
                }
            }

            if(distribucion.UnPiso && distribucion.Filas.Where(f => f.Planta == Planta.ALTA).Count() > 0)
            {
                return Error<DistribucionResponse>($"Se encontró una fila sin celdas.");
            }

            if (distribucion.Filas.Where(f => f.Planta == Planta.BAJA).Count() >= MAX_ITEMS_PER_PLANTA)
                return Error<DistribucionResponse>($"La cantidad de filas para la planta baja excede el límite permitido ({MAX_ITEMS_PER_PLANTA}).");

            if (distribucion.Filas.Where(f => f.Planta == Planta.ALTA).Count() >= MAX_ITEMS_PER_PLANTA)
                return Error<DistribucionResponse>($"La cantidad de filas para la planta alta excede el límite permitido ({MAX_ITEMS_PER_PLANTA}).");

            if (!await _distribucionRepository.CreateDistribucionAsync(distribucion))
                return Error<Distribucion, DistribucionResponse>(ErrorMessage.CouldNotCreate);

            var dto = _mapper.Map<DistribucionResponse>(distribucion);
            return Ok<Distribucion, DistribucionResponse>(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<Distribucion, DistribucionResponse>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Distribucion, DistribucionResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<DistribucionResponse>> DeleteDistribucionAsync(long id)
    {
        try
        {
            var distribucion = await _distribucionRepository.GetDistribucionAsync(id);
            if (distribucion == null)
                return Error<Distribucion, DistribucionResponse>(ErrorMessage.NotFound);

            if (!await _distribucionRepository.DeleteDistribucionAsync(distribucion))
                return Error<Distribucion, DistribucionResponse>(ErrorMessage.CouldNotDelete);

            return Ok<Distribucion, DistribucionResponse>(_mapper.Map<DistribucionResponse>(distribucion), SuccessMessage.Deleted);
        }
        catch (Exception ex)
        {
            return Error<Distribucion, DistribucionResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<DistribucionResponse>> GetDistribucionAsync(long id)
    {
        try
        {
            var distribucion = await _distribucionRepository.GetDistribucionAsync(id);

            if (distribucion == null)
                return Error<Distribucion, DistribucionResponse>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<DistribucionResponse>(distribucion));
        }
        catch (Exception ex)
        {
            return Error<Distribucion, DistribucionResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ICollection<DistribucionResponse>>> GetDistribucionesAsync()
    {
        try
        {
            var distribucions = await _distribucionRepository.GetDistribucionesAsync();

            var distribucionsDto = new List<DistribucionResponse>();

            foreach (var Distribucion in distribucions)
            {
                distribucionsDto.Add(_mapper.Map<DistribucionResponse>(Distribucion));
            }
            return Ok<ICollection<DistribucionResponse>>(distribucionsDto);
        }
        catch (Exception ex)
        {
            return Error<Distribucion, ICollection<DistribucionResponse>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<DistribucionResponse>> UpdateDistribucionAsync(DistribucionUpdateRequest distribucionDto)
    {
        try
        {
            if (distribucionDto.Id <= 0)
                return Error<Distribucion, DistribucionResponse>(ErrorMessage.InvalidId);

            var distribucion = await _distribucionRepository.GetDistribucionAsync(distribucionDto.Id);

            if (distribucion == null)
                return Error<Distribucion, DistribucionResponse>(ErrorMessage.NotFound);

            if(distribucion.Filas.Where(f => f.Planta == Planta.BAJA).Count() >= MAX_ITEMS_PER_PLANTA)
                return Error<DistribucionResponse>($"La cantidad de filas para la planta baja excede el límite permitido ({MAX_ITEMS_PER_PLANTA}).");

            if (distribucion.Filas.Where(f => f.Planta == Planta.ALTA).Count() >= MAX_ITEMS_PER_PLANTA)
                return Error<DistribucionResponse>($"La cantidad de filas para la planta alta excede el límite permitido ({MAX_ITEMS_PER_PLANTA}).");

            foreach (var fila in distribucionDto.Filas)
            {
                if(distribucion.Filas.Any(f => f.DistribucionId == distribucionDto.Id && f.Id == fila.Id))
                {
                    foreach (var celda in fila.Cells)
                    {
                        if (distribucion.Filas.Any(f => f.DistribucionId == distribucionDto.Id && f.Id == fila.Id && f.Cells.Any(c => c.Id == celda.Id)))
                        {
                            var filaDistri = distribucion.Filas
                                .FirstOrDefault(f => f.Id == fila.Id);

                            if(filaDistri != null)
                            {
                                var celdaDistri = filaDistri.Cells.FirstOrDefault(c => c.Id == celda.Id);

                                celdaDistri.Value = celda.Value;
                            }
                        }
                        else
                            return Error<DistribucionResponse>("No se encontró la celda.");
                    }
                }
                else
                    return Error<DistribucionResponse>("No se encontró la fila.");
                
            }

            distribucion.Filas = _mapper.Map<List<Fila>>(distribucionDto.Filas);

            if (distribucion.Nota != distribucionDto.Nota)
                distribucion.Nota = distribucionDto.Nota;
             
            if(distribucion.UnPiso != distribucionDto.UnPiso)
                distribucion.UnPiso = distribucionDto.UnPiso;

            if (!await _distribucionRepository.UpdateDistribucionAsync(distribucion))
                return Error<Distribucion, DistribucionResponse>(ErrorMessage.CouldNotUpdate);

            return Ok<Distribucion, DistribucionResponse>(_mapper.Map<DistribucionResponse>(distribucion), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<Distribucion, DistribucionResponse>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Distribucion, DistribucionResponse>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<DistribucionResponse>> AppendFilasAsync(long id, Planta planta)
    {
        try
        {
            if (id <= 0)
                return Error<Distribucion, DistribucionResponse>(ErrorMessage.InvalidId);

            var distribucion = await _distribucionRepository.GetDistribucionAsync(id);

            if (distribucion == null)
                return Error<Distribucion, DistribucionResponse>(ErrorMessage.NotFound);

            distribucion.AddRowCells(planta, 1);

            if (!await _distribucionRepository.UpdateDistribucionAsync(distribucion))
                return Error<Distribucion, DistribucionResponse>(ErrorMessage.CouldNotUpdate);

            return Ok<Distribucion, DistribucionResponse>(_mapper.Map<DistribucionResponse>(distribucion), SuccessMessage.Modified);
        }
        catch(Exception ex)
        {
            return Error<Distribucion, DistribucionResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
}
