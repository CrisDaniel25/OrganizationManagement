import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-client-confirm-delete',
  templateUrl: './client-confirm-delete.component.html',
  styleUrls: ['./client-confirm-delete.component.css']
})
export class ClientConfirmDeleteComponent implements OnInit {
  progressBar: boolean = false;
  id: string | number = '';

  constructor(private router: Router, private route: ActivatedRoute, private clientService: ClientService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id') || '';
  }

  proceed() {
    this.progressBar = true;
    this.clientService.delete(this.id).subscribe(() => {
      this.progressBar = false;
      this.goBack();
    })
  }

  goBack(): void {
    this.router.navigate(['/home/client-list']);
  }
}
