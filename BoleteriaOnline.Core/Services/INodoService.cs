﻿using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BoleteriaOnline.Core.Services;
public interface INodoService : IGenericService<int, NodoDTO, NodoFilter>
{
}
