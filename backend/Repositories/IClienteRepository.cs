﻿using BoleteriaOnline.Web.Data.Filters;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IClienteRepository : IGenericRepository<long, Cliente, ClienteFilter>
{
}
