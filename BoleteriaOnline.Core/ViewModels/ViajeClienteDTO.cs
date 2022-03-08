namespace BoleteriaOnline.Core.ViewModels;

public class ViajeClienteDTO
{
    public int ViajeId { get; set; }
    public string Empresa { get; set; }
    public string HorarioSalida { get; set; }
    public string HorarioLlegada { get; set; }
    public int AsientosDisponibles { get; set; }
    public int Precio { get; set; }

}
