﻿using AutoMapper;
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
        CreateMap<Cliente, ClienteDTO>()
            .ForMember(o => o.Dni, b => b.MapFrom(z => z.Id))
            .ReverseMap();
        CreateMap<Parada, ParadaDTO>()
            .ForMember(o => o.Descripcion, b => b.MapFrom(z => $"{z.Nombre}, {z.Provincia.Nombre}, {z.Pais.Nombre}"))
            .ReverseMap();
        CreateMap<Nodo, NodoDTO>()
            .ReverseMap();
        CreateMap<Nodo, NodoDTO>()
            .ReverseMap();
        CreateMap<Distribucion, DistribucionRequest>()
            .ReverseMap();
        CreateMap<Distribucion, DistribucionResponse>()
            .ReverseMap();
        CreateMap<Viaje, ViajeDTO>()
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
            .ForMember(h => h.Dias, opt => opt.MapFrom(new HorarioResolver()))
            .ForMember(h => h.Hora, opt => opt.MapFrom(d => d.Hora.ToString("HH:mm:ss")));
        CreateMap<HorarioDTO, Horario>()
            .ForMember(h => h.Lunes, opt => opt.MapFrom(d => d.Dias.Contains(DayOfWeek.Monday)))
            .ForMember(h => h.Martes, opt => opt.MapFrom(d => d.Dias.Contains(DayOfWeek.Tuesday)))
            .ForMember(h => h.Miercoles, opt => opt.MapFrom(d => d.Dias.Contains(DayOfWeek.Wednesday)))
            .ForMember(h => h.Jueves, opt => opt.MapFrom(d => d.Dias.Contains(DayOfWeek.Thursday)))
            .ForMember(h => h.Viernes, opt => opt.MapFrom(d => d.Dias.Contains(DayOfWeek.Friday)))
            .ForMember(h => h.Sabado, opt => opt.MapFrom(d => d.Dias.Contains(DayOfWeek.Saturday)))
            .ForMember(h => h.Domingo, opt => opt.MapFrom(d => d.Dias.Contains(DayOfWeek.Sunday)))
            .ForMember(h => h.Hora, opt => opt.MapFrom(d => DateTime.Parse(d.Hora)))
        ;
        CreateMap<Pais, PaisDTO>()
            .ReverseMap();
        CreateMap<Provincia, ProvinciaDTO>()
            .ReverseMap();
    }
}
