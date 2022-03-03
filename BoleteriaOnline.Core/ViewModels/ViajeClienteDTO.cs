namespace BoleteriaOnline.Core.ViewModels;

public class ViajeClienteDTO
{
    public string Empresa { get; set; }
    public string HorarioSalida { get; set; }
    public string HorarioLlegada { get; set; }
    public List<int> AsientosDisponibles { get; set; }
    public float Precio { get; set; }

}
