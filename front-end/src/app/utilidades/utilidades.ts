export interface DialogData {
  mensaje: string;
}

export function parserarErroresAPI(response: any): string[] {
  const resultado: string[] = [];

  if (response.status != 200) {
    resultado.push(`${response.statusText}: ${response.message}`);
  }
  if (response.error) {
    if (typeof response.error === 'string') {
      resultado.push(response.error);
    } else if (Array.isArray(response.error)) {
      response.error.forEach((valor) => resultado.push(valor.description));
    } else {
      const mapaErrores = response.error.errors;
      const entradas = Object.entries(mapaErrores);
      entradas.forEach((arreglo: any[]) => {
        const campo = arreglo[0];
        arreglo[1].forEach((mensajeError) => {
          resultado.push(`${campo}: ${mensajeError}`);
        });
      });
    }
  }
  return resultado;
}

export function formatearFecha(date: Date) {
  date = new Date(date);
  const formato = new Intl.DateTimeFormat('en', {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit'
  })
  const [
    { value: month }, ,
    { value: day }, ,
    { value: year }
  ] = formato.formatToParts(date)
  return `${year}-${month}-${day}`
}
