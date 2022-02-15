namespace BoleteriaOnline.Core.ViewModels.Responses;
public class NodoResponse
{
    public int Id { get; set; }
    public DestinoResponse Origen { get; set; }
    public DestinoResponse Destino { get; set; }

    public string Demora { get; set; }
    public float Precio { get; set; }

}
