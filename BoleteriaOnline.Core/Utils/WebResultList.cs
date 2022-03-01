using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Core.Utils;

public class WebResultList<T> : WebResult<List<T>> where T : class
{
    public Pagination Pagination { get; set; }
}
