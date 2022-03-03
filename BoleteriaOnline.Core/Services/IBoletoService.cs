using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;

namespace BoleteriaOnline.Core.Services
{
    public interface IBoletoService : IGenericService<int, BoletoDTO, BoletoFilter> 
    {
    }
}
