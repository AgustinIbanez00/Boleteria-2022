import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NotificacionesComponent } from './notificaciones/notificaciones.component';

@Injectable({
  providedIn: 'root',
})
export class NotificacionesService {
  constructor(private snackBar: MatSnackBar) {}

  showNotifacacion(
    result_message: string,
    buttonText: string,
    messageType: 'error' | 'success'
  ) {
    this.snackBar.openFromComponent(NotificacionesComponent, {
      data: {
        messaje: result_message,
        buttonText: buttonText,
        type: messageType,
      },
      duration: 5000,
      horizontalPosition: 'center',
      verticalPosition: 'bottom',
      panelClass: messageType,
    });
  }
}
