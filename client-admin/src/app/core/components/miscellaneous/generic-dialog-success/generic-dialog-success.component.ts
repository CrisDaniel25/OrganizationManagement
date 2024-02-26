import { Component } from '@angular/core';
import { Toast, ToastPackage, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-generic-dialog-success',
  templateUrl: './generic-dialog-success.component.html',
  styleUrls: ['./generic-dialog-success.component.css']
})
export class GenericDialogSuccessComponent extends Toast {
  // constructor is only necessary when not using AoT
  constructor(
    protected override toastrService: ToastrService,
    public override toastPackage: ToastPackage,
  ) {
    super(toastrService, toastPackage);
  }

}
