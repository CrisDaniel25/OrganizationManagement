import { Component } from '@angular/core';
import { Toast, ToastPackage, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-generic-dialog-info',
  templateUrl: './generic-dialog-info.component.html',
  styleUrls: ['./generic-dialog-info.component.css']
})
export class GenericDialogInfoComponent extends Toast {
  // constructor is only necessary when not using AoT
  constructor(
    protected override toastrService: ToastrService,
    public override toastPackage: ToastPackage,
  ) {
    super(toastrService, toastPackage);
  }
}
