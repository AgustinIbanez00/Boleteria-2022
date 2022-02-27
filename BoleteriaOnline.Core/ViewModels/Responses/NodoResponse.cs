namespace BoleteriaOnline.Core.ViewModels.Responses;
public class NodoResponse
{
    public int Id { get; set; }
    public ParadaDTO Origen { get; set; }
    public ParadaDTO Destino { get; set; }

    public string Demora { get; set; }
    public float Precio { get; set; }

}
