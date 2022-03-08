using AutoMapper;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.AutoMapper;
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Usuario, RegistroRequest>()
            .ForMember(o => o.Dni, b => b.MapFrom(z => z.Id))
            .ReverseMap();
        CreateMap<Usuario, UsuarioResponse>()
            .ForMember(o => o.Dni, b => b.MapFrom(z => z.Id))
            .ReverseMap();
        CreateMap<ClienteDTO, Cliente>()
            .ForMember(o => o.Id, b => b.MapFrom(z => z.Dni))
            .ForMember(o => o.FechaNac, opt => opt.MapFrom(d => DateTime.Parse(d.FechaNacimiento)));
        CreateMap<Cliente, ClienteDTO>()
            .ForMember(o => o.Dni, b => b.MapFrom(z => z.Id))
            .ForMember(o => o.FechaNacimiento, opt => opt.MapFrom(d => d.FechaNac.ToString("yyyy-MM-dd")));
        CreateMap<Parada, ParadaDTO>()
            .ForMember(o => o.Descripcion, b => b.MapFrom(z => $"{z.Nombre}, {z.Provincia.Nombre}, {z.Pais.Nombre}"))
            .ReverseMap();
        CreateMap<Nodo, NodoDTO>()
            .ReverseMap();
        CreateMap<Distribucion, DistribucionRequest>()
            .ReverseMap();
        CreateMap<Distribucion, DistribucionResponse>()
            .ReverseMap();
        CreateMap<Viaje, ViajeDTO>()
            .ForMember(o => o.Conexiones, b => b.MapFrom(z => z.Nodos))
            .ReverseMap();
        CreateMap<Fila, FilaRequest>()
            .ReverseMap();
        CreateMap<Fila, FilaUpdateRequest>()
            .ReverseMap();
        CreateMap<Fila, FilaResponse>()
            .ReverseMap();
        CreateMap<Celda, CeldaRequest>()
            .ReverseMap();
        CreateMap<Celda, CeldaResponse>()
            .ReverseMap();
        CreateMap<Horario, HorarioDTO>()
            .ForMember(h => h.Dias, opt => opt.MapFrom(d => d.Dias.ToCharArray().Select(v => (DayOfWeek)int.Parse(v.ToString()))))
            .ForMember(h => h.Hora, opt => opt.MapFrom(d => d.Hora.ToString("HH:mm:ss")));
        CreateMap<HorarioDTO, Horario>()
            .ForMember(h => h.Dias, opt => opt.MapFrom(d => string.Join<string>("", d.Dias.Select(v => ((int)v).ToString()))))
            .ForMember(h => h.Hora, opt => opt.MapFrom(d => DateTime.Parse(d.Hora)))
        ;
        CreateMap<Pais, PaisDTO>()
            .ReverseMap();
        CreateMap<Provincia, ProvinciaDTO>()
            .ReverseMap();
    }
}
