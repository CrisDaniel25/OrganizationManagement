import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-employee-confirm-delete',
  templateUrl: './employee-confirm-delete.component.html',
  styleUrls: ['./employee-confirm-delete.component.css']
})
export class EmployeeConfirmDeleteComponent implements OnInit {
  progressBar: boolean = false;
  id: string | number = '';
  clientId: string | number = '';

  constructor(private router: Router, private route: ActivatedRoute, private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id') || '';
    this.clientId = this.route.snapshot.paramMap.get('clientId') || '';
  }

  proceed() {
    this.progressBar = true;
    this.employeeService.delete(this.id).subscribe(() => {
      this.progressBar = false;
      this.goBack();
    })
  }

  goBack(): void {
    this.router.navigate([`/home/client/${this.clientId}`]);
  }
}
