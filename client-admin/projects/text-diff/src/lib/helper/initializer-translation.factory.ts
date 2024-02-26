import { TranslateService } from "@ngx-translate/core";

export function initializerTranslationFactoy(translate: TranslateService) {
    return () => {
        translate.setDefaultLang('en');
        return translate.use('en').toPromise();
    };
}