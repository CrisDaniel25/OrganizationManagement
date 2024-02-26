import { Component, Input, OnInit, } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Select, Store } from '@ngxs/store';
import { Observable } from 'rxjs';
import { AppService } from 'src/app/core/services/app.service';
import { CustomValidationsService } from 'src/app/core/services/custom-validations.service';
import { Message, NavItem } from 'src/app/shared/interfaces';
import { MessengerState, SessionState, TranslatorAction } from 'src/app/shared/store';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  @Input() navItems: NavItem[] = [];
  @Input() showNotifications: boolean = false;
  @Input() showMessage: boolean = false;
  @Input() showFullScreenButton: boolean = false;
  @Input() showTranslateButton: boolean = true;

  @Input() sidenav!: MatSidenav;

  @Select(SessionState.getUserFullName) userFullName$!: Observable<string>;
  @Select(MessengerState.getMessages) messages$!: Observable<Message[]>;

  name: string = environment.name;
  color: ThemePalette = 'accent';

  constructor(public store: Store, public appService: AppService, public validate: CustomValidationsService) { }

  ngOnInit(): void { }

  useLang(language: string) {
    this.store.dispatch(new TranslatorAction.UseLang(language));
  }
}
