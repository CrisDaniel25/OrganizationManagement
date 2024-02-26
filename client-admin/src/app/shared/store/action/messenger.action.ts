import { Message } from "../../interfaces";

export namespace MessengerAction {
    export class AddMessage {
        static readonly type = '[Messenger] Adding new message';
        constructor(public payload: Message) { }
    }
}