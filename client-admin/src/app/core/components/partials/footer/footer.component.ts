import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  name: string = 'SIDE Dominicana';
  route: string = '/';
  version: string = '1.0.0';
  year: number = new Date().getFullYear();

  constructor() { }

  ngOnInit(): void { }
}
