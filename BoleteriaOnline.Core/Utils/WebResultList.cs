using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Core.Utils;

public class WebResultList<T> : WebResult<T> where T : class
{
    public Pagination Pagging { get; set; }

}
