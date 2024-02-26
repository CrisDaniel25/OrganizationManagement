import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class TranslatorService {

  constructor(public translate: TranslateService) { }

  setup(): Observable<string[]> {
    const languages = ['en', 'es'];
    this.translate.addLangs(languages);
    this.translate.setDefaultLang('en');
    return of(languages)
  }

  useLang(language: string): Observable<string> {
    this.translate.use(language);
    return of(language);
  }
}
