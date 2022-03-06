using BoleteriaOnline.Core.Data.Enums;

namespace BoleteriaOnline.Web.Data.Models;
public class Boleto : AuditoryDates
{
    public int Id { get; set; }
    public Viaje Recorrido { get; set; }
    public int RecorridoId { get; set; }
    public Parada Origen { get; set; }
    public int OrigenId { get; set; }
    public Parada Destino { get; set; }
    public int DestinoId { get; set; }
    public Cliente Pasajero { get; set; }
    public int PasajeroId { get; set; }
    public Pago Pago { get; set; }
    public int PagoId { get; set; }
    public int Asiento { get; set; }
    public float Precio { get; set; }
    public string HoraSalida { get; set; }
    public string HoraSalidaAdicional { get; set; }
    public string HoraLlegada { get; set; }
    public BoletoEstado Estado { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime FechaEmision { get; set; } = DateTime.Now;
}
