using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Extensions;
public static class DistribucionExtensions
{
    public static void InicializarListaCeldas(this Distribucion distribucion, Planta planta, int rows, int columns)
    {
        distribucion.Filas ??= new List<Fila>();

        for (int i = 0; i < rows; i++)
        {
            Fila fila = new() { Planta = planta };
            fila.Cells = new List<Celda>();

            for (int j = 0; j < columns; j++)
            {
                Celda celda = new()
                {
                    Value = 0,
                };
                fila.Cells.Add(celda);
            }
            distribucion.Filas.Add(fila);
        }
    }

    public static void AddRowCells(this Distribucion distribucion, Planta planta, int maxRows)
    {
        if (distribucion?.Filas != null && distribucion?.Filas?.Count != -1)
        {
            for (int indexRow = 0; indexRow < maxRows; indexRow++)
            {
                Fila row = new()
                {
                    Planta = planta,
                    Cells = new List<Celda>()
                };
                for (int indexCell = 0; indexCell < 5; indexCell++)
                {
                    Celda cell = new()
                    {
                        Value = DistribucionEspacio.ESPACIO_NULL
                    };
                    row.Cells.Add(cell);
                }
                distribucion?.Filas.Add(row);
            }
        }
    }

    public static List<Fila> GetPlantaBaja(this Distribucion distribucion) => distribucion.Filas.Where(f => f.Planta == Planta.BAJA).OrderBy(f => f.Id).ToList();
    public static List<Fila> GetPlantaAlta(this Distribucion distribucion) => distribucion.Filas.Where(f => f.Planta == Planta.ALTA).OrderBy(f => f.Id).ToList();


    public static IList<Fila> GetFilas(this Distribucion distribucion, Planta planta)
    {
        return planta switch
        {
            Planta.BAJA => distribucion.GetPlantaBaja(),
            Planta.ALTA => distribucion.GetPlantaAlta(),
            _ => throw new NotSupportedException()
        };
    }

    public static void RemoveRowCells(this Distribucion distribucion, Planta matriz, int rows)
    {
        if (distribucion?.Filas?.Count > 0)
        {
            for (int i = 0; i < rows; i++)
            {
                Fila lastItem = distribucion?.GetFilas(matriz).Last();
                if (lastItem != null)
                {
                    distribucion?.Filas?.Remove(lastItem);
                }
            }
        }
    }
    public static void SetCellContent(this Distribucion distribucion, Planta planta, int indexRow, int indexColumn, DistribucionEspacio value)
    {
        IList<Fila> filas = GetFilas(distribucion, planta);
        if (distribucion != null && indexRow > 0 && indexRow < filas.Count)
        {
            Fila row = distribucion.GetFilas(planta)[indexRow];
            if (indexColumn > 0 && indexColumn < row.Cells?.Count)
            {
                row.Cells[indexColumn].Value = value;
            }
        }
    }

    public static DistribucionEspacio? GetCellContent(this Distribucion distribucion, Planta planta, int indexRow, int indexColumn)
    {
        IList<Fila> filas = GetFilas(distribucion, planta);
        if (distribucion != null && indexRow > 0 && indexRow < filas.Count)
        {
            Fila row = distribucion.GetFilas(planta)[indexRow];
            if (indexColumn > 0 && indexColumn < row.Cells?.Count)
            {
                return row.Cells[indexColumn].Value;
            }
        }
        return null;
    }

    public static void AgregarPasilloPB(this Distribucion distribucion, int x, int y)
    {
        distribucion.SetCellContent(Planta.BAJA, x, y, DistribucionEspacio.ESPACIO_PASILLO);
    }

    public static void AgregarButacaPB(this Distribucion distribucion, int x, int y)
    {
        distribucion.SetCellContent(Planta.BAJA, x, y, DistribucionEspacio.ESPACIO_BUTACA);
    }

    public static void AgregarTVPB(this Distribucion distribucion, int x, int y)
    {
        distribucion.SetCellContent(Planta.BAJA, x, y, DistribucionEspacio.ESPACIO_TV);
    }

    public static void RemoverPB(this Distribucion distribucion, int x, int y)
    {
        distribucion.SetCellContent(Planta.BAJA, x, y, DistribucionEspacio.ESPACIO_NULL);
    }

    public static void AgregarPasilloPA(this Distribucion distribucion, int x, int y)
    {
        distribucion.SetCellContent(Planta.ALTA, x, y, DistribucionEspacio.ESPACIO_PASILLO);
    }

    public static void AgregarButacaPA(this Distribucion distribucion, int x, int y)
    {
        distribucion.SetCellContent(Planta.ALTA, x, y, DistribucionEspacio.ESPACIO_BUTACA);
    }

    public static void AgregarTVPA(this Distribucion distribucion, int x, int y)
    {
        distribucion.SetCellContent(Planta.ALTA, x, y, DistribucionEspacio.ESPACIO_TV);
    }

    public static void RemoverPA(this Distribucion distribucion, int x, int y)
    {
        distribucion.SetCellContent(Planta.ALTA, x, y, DistribucionEspacio.ESPACIO_NULL);
    }

    public static int ContarAsientos(this Distribucion distribucion)
    {
        int c = 0;
        for (int indexRow = 0; indexRow < distribucion.Filas.Count; indexRow++)
        {
            for (int indexCell = 0; indexCell < 5; indexCell++)
            {
                if (distribucion.Filas[indexRow]?.Cells[indexCell].Value == DistribucionEspacio.ESPACIO_BUTACA)
                {
                    c++;
                }
            }
        }
        return c;
    }

}
