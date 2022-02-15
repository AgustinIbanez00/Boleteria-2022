using BoleteriaOnline.Core.Extensions.Response;

namespace BoleteriaOnline.Core.Utils;
public class WebResult<T> where T : class
{
    public T Result { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = null;
    public IDictionary<string, string[]> ErrorMessages { get; set; } = null;
    public ErrorMessage ErrorCode { get; set; }
    public string Error { get; set; }
}
