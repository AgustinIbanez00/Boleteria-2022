namespace BoleteriaOnline.Core.ViewModels.Responses;
public class DistribucionResponse
{
    public int Id { get; set; }
    public List<FilaResponse> Filas { get; set; }
    public string Nota { get; set; }
    public bool UnPiso { get; set; }
}