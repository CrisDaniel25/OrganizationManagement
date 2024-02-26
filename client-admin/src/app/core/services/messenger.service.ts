import { HttpErrorResponse } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Store } from '@ngxs/store';
import { Message } from 'src/app/shared/interfaces';
import { MessengerAction } from 'src/app/shared/store';
import swal, { SweetAlertOptions } from 'sweetalert2';
import { HttpResponseEnum } from '../enums/http-response.enum';
import { ToastrService } from 'ngx-toastr';
import { GenericDialogErrorComponent } from '../components/miscellaneous/generic-dialog-error/generic-dialog-error.component';
import { GenericDialogInfoComponent } from '../components/miscellaneous/generic-dialog-info/generic-dialog-info.component';
import { GenericDialogWarningComponent } from '../components/miscellaneous/generic-dialog-warning/generic-dialog-warning.component';
import { GenericDialogSuccessComponent } from '../components/miscellaneous/generic-dialog-success/generic-dialog-success.component';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class MessengerService implements OnInit {

  options: SweetAlertOptions = {};

  constructor(private store: Store, private toastrService: ToastrService, private readonly translate: TranslateService) { }

  ngOnInit(): void {
    this.options = {
      timer: 2000,
      showCloseButton: false,
    }
  }

  addMessage(response: any, isOnToastr: boolean = true, isOnSweetAlert: boolean = false): void {
    var message;
    const type = this.getCodeTypeByRange(response.status, response.error);
    this.getGenericComponent(type);

    if (isOnToastr) {
      message = this.showToastrMessage(response);
    } else if (isOnSweetAlert) {
      message = this.showSweetAlert(response);
    }

    this.store.dispatch(new MessengerAction.AddMessage({ message: message, ...response }))
  }

  showToastrMessage(response: Message) {
    const message = this.getMessage(response);
    this.toastrService.show(message, response.statusText);
    return message;
  }

  showSweetAlert(response: Message) {
    const message = this.getMessage(response);
    swal.fire({ ...this.options });
    return message;
  }

  getMessage(data: any) {
    var message = '';
    const status = data.status;

    switch (status) {
      case HttpResponseEnum.InternalServerError:
        message = this.translate.instant('messenger.internal-server-error');
        break;
      case HttpResponseEnum.BadRequest:
        message = this.translate.instant('messenger.bad-request');
        break;
      case HttpResponseEnum.Forbidden:
        message = this.translate.instant('messenger.forbidden');
        break;
      case HttpResponseEnum.NotFound:
        message = this.translate.instant('messenger.not-found');
        break;
      case HttpResponseEnum.NoContent:
        message = this.translate.instant('messenger.no-content');
        break;
      case HttpResponseEnum.Locked:
        message = this.translate.instant('messenger.locked');
        break;
      default:
        message = this.translate.instant('messenger.communicate-suppot');
        break;
    }

    return message;
  }

  getGenericComponent(type: string) {
    switch (type) {
      case 'error':
        this.toastrService.toastrConfig.toastComponent = GenericDialogErrorComponent;
        break;
      case 'success':
        this.toastrService.toastrConfig.toastComponent = GenericDialogSuccessComponent;
        break;
      case 'info':
        this.toastrService.toastrConfig.toastComponent = GenericDialogInfoComponent;
        break;
      default:
        this.toastrService.toastrConfig.toastComponent = GenericDialogWarningComponent
        break;
    }
  }

  getCodeTypeByRange(code: number, error: any) {
    if (code == 0 && error) return error.type;

    return code >= 100 && code < 200 ? 'info' : code >= 200 && code < 300 ? 'success' : code >= 400 && code < 600 ? 'error' : 'warning';
  }
}


/** dynamic grid */
/**
 * 
        // if (error.status != 401) {
        //   if (error.error.errorMessage)
        //     this.appService.showErrorMessage(error.error.errorMessage);
        //   else this.appService.showErrorMessage('Error interno');
        // }
 */


/** change password */
/**
 *       // if (error.status == HttpResponseEnum.BadRequest)
      //   this.appService.showErrorMessage('Parametros invalidos.');
      // else if (error.status == HttpResponseEnum.Forbidden)
      //   this.appService.showErrorMessage(
      //     'Contraseña actual inválida, intente nuevamente'
      //   );
      // else if (error.status == HttpResponseEnum.NotFound)
      //   this.appService.showErrorMessage('Usuario inválido');
      // else this.appService.showErrorMessage(error.error);
 */

/** login */
/**
 *       // switch (error.status) {
      //   case HttpResponseEnum.Forbidden:
      //     this.appService.showInfoMessage('Contraseña invalida');
      //     break;
      //   case HttpResponseEnum.NotFound:
      //     this.appService.showInfoMessage('Usuario no encontrado');
      //     break;
      //   case HttpResponseEnum.Locked:
      //     this.appService.showInfoMessage('Usuario ha sido bloqueado. Favor de comunicarse con Administrador.');
      //     break;
      //   default:
      //     this.appService.showErrorMessage('Se ha producido un error, intente nuevamente más tarde.');
      //     break;
      // }
 */
