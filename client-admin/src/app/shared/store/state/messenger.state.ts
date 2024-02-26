import { Injectable } from "@angular/core";
import { Action, Selector, State, StateContext } from "@ngxs/store";
import { Message, MessengerStateModel } from "../../interfaces";
import { DEFAUL_MESSAGES_STATE } from "../../constants/messenger.constant";
import { MessengerAction } from "../action/messenger.action";
import { append, patch } from "@ngxs/store/operators";

@State<MessengerStateModel>({
    name: 'MessengerState',
    defaults: DEFAUL_MESSAGES_STATE
})
@Injectable()
export class MessengerState {
    constructor() { }

    @Action(MessengerAction.AddMessage)
    addMessage(ctx: StateContext<MessengerStateModel>, { payload }: MessengerAction.AddMessage) {
        ctx.setState(patch({ Messages: append([payload]) }));
    }

    @Selector()
    static getMessages(state: MessengerStateModel): Message[] {
        return state.Messages;
    }
}