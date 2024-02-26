import { Component, OnInit } from '@angular/core';
import { AppService } from './core/services/app.service';
import { SessionTimeoutService } from './core/services/session-timeout.service';
import { Store } from '@ngxs/store';
import { TranslateService } from '@ngx-translate/core';
import { SessionState, TranslatorAction } from './shared/store';
import { environment } from 'src/environments/environment';
import { Session } from './shared/interfaces';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(public appService: AppService, private store: Store, public translate: TranslateService, private sessionTimeOut: SessionTimeoutService) {
    appService.loading = true;
    store.dispatch(new TranslatorAction.Setup()).subscribe(() => appService.loading = false);
  }

  ngOnInit() {
    this.sessionTimeOut
      .startWatching(environment.idleTimeout)
      .subscribe(() => {
        this.store.select(SessionState.getSession).subscribe((session: Session) => {
          if (!!session && session.Token.length > 0) {
            console.log('Expired Session');
            this.appService.logout();
          }
        })
      });
  }
}
