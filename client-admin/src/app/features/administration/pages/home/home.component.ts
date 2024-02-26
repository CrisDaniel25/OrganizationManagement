import { Component, OnInit, ViewChild, HostListener, ElementRef, Renderer2 } from '@angular/core';
import { MenuRoles } from 'src/app/core/constants/menu-roles.constant';
import { MatSidenav } from '@angular/material/sidenav';
import { AppService } from 'src/app/core/services/app.service';
import { NavItem } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  @ViewChild('sidenav', { static: true })
  sidenav!: MatSidenav;

  showNotifications: boolean = false;
  showMessage: boolean = false;

  disableClose: boolean = true;

  sideBarItems: Array<NavItem> = [
    {
      displayName: 'administration.home',
      iconName: 'fa-solid fa-house',
      route: '/home',
      visible: true,
      hasBadge: false,
      isOpen: false,
      badgeColor: 'primary',
      badgeContent: 0
    },
    {
      displayName: 'administration.administration',
      iconName: 'fas fa-copy',
      visible:
        this.appService.checkMenuRoleAccess(MenuRoles.USERS) ||
        this.appService.checkMenuRoleAccess(MenuRoles.ROLES) ||
        this.appService.checkMenuRoleAccess(MenuRoles.AUDITS),
      children: [
        {
          displayName: 'administration.groups',
          iconName: 'fa-solid fa-users',
          route: '/home/role-list',
          visible: this.appService.checkMenuRoleAccess(MenuRoles.ROLES),
          hasBadge: false,
          badgeColor: 'primary',
          isOpen: false,
          badgeContent: 0
        },
        {
          displayName: 'administration.users',
          iconName: 'fa-solid fa-user',
          route: '/home/user-list',
          visible: this.appService.checkMenuRoleAccess(MenuRoles.USERS),
          badgeColor: 'warn',
          hasBadge: false,
          isOpen: false,
          badgeContent: 0
        },
        {
          displayName: 'administration.register',
          iconName: 'fa-solid fa-file-contract',
          route: '/home/audit-list',
          visible: this.appService.checkMenuRoleAccess(MenuRoles.AUDITS),
          hasBadge: false,
          badgeColor: 'accent',
          isOpen: false,
          badgeContent: 0
        },
      ],
      isOpen: true,
      badgeColor: 'accent',
      hasBadge: true,
      badgeContent: 0
    },
    {
      displayName: 'administration.maintenance',
      iconName: 'fa-solid fa-gear',
      route: '/maintenance',
      visible: false,
      isOpen: false,
      hasBadge: false,
      badgeColor: 'accent',
      badgeContent: 0
    }
  ];

  opened = true;

  constructor(public appService: AppService) { }

  ngOnInit(): void {
    if (window.innerWidth < 768) {
      this.sidenav.fixedTopGap = 55;
      this.opened = false;
    } else {
      this.sidenav.fixedTopGap = 55;
      this.opened = true;
    }
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any): void {
    if (event.target.innerWidth < 768) {
      this.sidenav.fixedTopGap = 55;
      this.opened = false;
    } else {
      this.sidenav.fixedTopGap = 55;
      this.opened = true;
    }
  }

  isBiggerScreen(): boolean {
    const width =
      window.innerWidth ||
      document.documentElement.clientWidth ||
      document.body.clientWidth;
    if (width < 768) {
      return true;
    } else {
      return false;
    }
  }

  animateSidenav() {

  }
}
