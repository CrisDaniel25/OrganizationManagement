import { loginForm } from "../../interfaces";

export namespace SessionAction {
    export class Login {
        static readonly type = '[Session] Method to check and get the login to session';
        constructor(public payload: loginForm) { }
    }

    export class ChangePassword {
        static readonly type = '[Sessions] Method too change the password';
        constructor(public payload: any) { }
    }

    export class Logout {
        static readonly type = '[Session] Method to logout the session';
    }
}