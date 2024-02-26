import { HttpHeaders } from "@angular/common/http";
import { HttpResponseEnum } from "src/app/core/enums/http-response.enum";

export interface Message {
    title: string;
    titleText?: string;
    html?: string;
    text?: string;
    error: any;
    headers?: HttpHeaders;
    message: string
    name: string;
    ok: boolean
    status: HttpResponseEnum;
    statusText: string;
    url: string;
    type?: 'warning' | 'error' | 'success' | 'info' | undefined;
    icon?: 'warning' | 'error' | 'success' | 'info' | 'question' | undefined;
}

export interface MessengerStateModel {
    Messages: Message[];
}