using BoleteriaOnline.Core.Data.Enums;

namespace BoleteriaOnline.Core.ViewModels;
public class BoletoDTO
{
    public int Id { get; set; }
    public int RecorridoId { get; set; }
    public int OrigenId { get; set; }
    public int DestinoId { get; set; }
    public int PasajeroId { get; set; }
    public int PagoId { get; set; }
    public int Asiento { get; set; }
    public float Precio { get; set; }
    public string HoraSalida { get; set; }
    public string HoraSalidaAdicional { get; set; }
    public string HoraLlegada { get; set; }
    public BoletoEstado Estado { get; set; }
    public DateTime Fecha { get; set; }
}
