import { Component, OnInit, Input } from '@angular/core';
import { NavItem } from 'src/app/shared/interfaces';
import { AppService } from 'src/app/core/services/app.service';
import { MatSidenav } from '@angular/material/sidenav';
import { Select } from '@ngxs/store';
import { SessionState } from 'src/app/shared/store';
import { Observable } from 'rxjs';
import { DomSanitizer, SafeStyle } from '@angular/platform-browser';

@Component({
  selector: 'app-side-nav-content',
  templateUrl: './side-nav-content.component.html',
  styleUrls: ['./side-nav-content.component.css']
})
export class SideNavContentComponent implements OnInit {
  @Input() navItems: NavItem[] = [];
  @Input() sidenav!: MatSidenav;

  @Select(SessionState.getUserFullName) userFullName$!: Observable<string>;
  @Select(SessionState.getUserLoginName) userLoginName$!: Observable<string>;

  profileImg: SafeStyle;

  constructor(public appService: AppService, sanitizer: DomSanitizer) {
    this.profileImg = sanitizer.bypassSecurityTrustStyle('url(https://material.angular.io/assets/img/examples/shiba1.jpg)');
  }

  ngOnInit(): void { }
}
