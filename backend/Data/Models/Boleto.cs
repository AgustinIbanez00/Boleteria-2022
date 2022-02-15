namespace BoleteriaOnline.Web.Data.Models;
public class Boleto
{
    public int Id { get; set; }
    public Viaje Recorrido { get; set; }
    public Destino Origen { get; set; }
    public Destino Destino { get; set; }
    public Cliente Pasajero { get; set; }
    public Pago Pago { get; set; }
    public int Asiento { get; set; }
    public string Precio { get; set; }
    public string HoraSalida { get; set; }
    public string HoraSalidaAdicional { get; set; }
    public string HoraLlegada { get; set; }
    public string Estado { get; set; } = "PENDIENTE";
    public DateTime Fecha { get; set; }
    public DateTime FechaEmision { get; set; } = DateTime.Now;
    public Usuario Vendedor { get; set; }
}
