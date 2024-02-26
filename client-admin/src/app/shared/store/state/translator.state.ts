import { Injectable } from "@angular/core";
import { Action, Selector, State, StateContext } from "@ngxs/store";
import { tap } from 'rxjs/operators';
import { TranslatorAction } from "../action/translator.action";
import { TranslatorStateModel } from "../../interfaces/state/translator.interface";
import { TranslatorService } from "src/app/core/services/translator.service";

@State<TranslatorStateModel>({
    name: 'TranslatorState',
    defaults: {
        id: 'en',
        name: 'English',
    }
})
@Injectable()
export class TranslatorState {
    constructor(private translator: TranslatorService) { }

    @Action(TranslatorAction.Setup)
    setup(ctx: StateContext<TranslatorStateModel>) {
        const state = ctx.getState();
        return this.translator.setup().pipe(tap((translator) => {
            ctx.patchState({
                ...state,
                id: 'en',
                name: 'English'
            });
        }))
    }

    @Action(TranslatorAction.UseLang)
    useLang(ctx: StateContext<TranslatorStateModel>, { language }: TranslatorAction.UseLang) {
        const state = ctx.getState();
        return this.translator.useLang(language).pipe(tap((translator) => {
            ctx.patchState({ ...state, id: language });
        }))
    }

    @Selector()
    static getLanguage(state: TranslatorStateModel): string {
        return state.id
    }
}