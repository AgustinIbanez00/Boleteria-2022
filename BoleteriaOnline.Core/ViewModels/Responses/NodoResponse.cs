namespace BoleteriaOnline.Core.ViewModels.Responses;
public class NodoResponse
{
    public int Id { get; set; }
    public ParadaResponse Origen { get; set; }
    public ParadaResponse Destino { get; set; }

    public string Demora { get; set; }
    public float Precio { get; set; }

}
