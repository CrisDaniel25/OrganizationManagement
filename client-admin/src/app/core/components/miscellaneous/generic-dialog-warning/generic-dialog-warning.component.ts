import { Component } from '@angular/core';
import { Toast, ToastPackage, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-generic-dialog-warning',
  templateUrl: './generic-dialog-warning.component.html',
  styleUrls: ['./generic-dialog-warning.component.css']
})
export class GenericDialogWarningComponent extends Toast {
  // constructor is only necessary when not using AoT
  constructor(
    protected override toastrService: ToastrService,
    public override toastPackage: ToastPackage,
  ) {
    super(toastrService, toastPackage);
  }

}
