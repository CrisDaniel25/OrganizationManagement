export namespace TranslatorAction {
    export class Setup {
        static readonly type = '[Translator] Method to setup a translator state';
        constructor() { }
    }

    export class UseLang {
        static readonly type = '[Translator] Method to use change the language';
        constructor(public language: string) { }
    }
}