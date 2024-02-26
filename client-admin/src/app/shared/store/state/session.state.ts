import { Injectable } from '@angular/core';
import { SessionStateModel } from '../../interfaces';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { AuthService } from 'src/app/core/services/auth.service';
import { SessionAction } from '../action/session.action';
import { catchError, map, of } from 'rxjs';
import { Router } from '@angular/router';
import { DEFAUL_SESSION_STATE } from '../../constants/session.constant';
import { UserService } from 'src/app/features/administration/services/user.service';
import { MessengerService } from 'src/app/core/services/messenger.service';

@State<SessionStateModel>({
    name: 'SessionState',
    defaults: DEFAUL_SESSION_STATE
})
@Injectable()
export class SessionState {
    constructor(private router: Router, private authService: AuthService, private userService: UserService, private messengerService: MessengerService) { }

    @Action(SessionAction.Login)
    login(ctx: StateContext<SessionStateModel>, { payload }: SessionAction.Login) {
        const state = ctx.getState();
        return this.authService.login(payload).pipe(map((session: any) => {
            if (session.Token.length > 0 && !!session) {
                ctx.patchState({ ...state, ...session });
                this.router.navigate(['/home']);
            }

            return session;
        }), catchError(err => {
            this.messengerService.addMessage(err);
            return of()
        }));
    }

    @Action(SessionAction.ChangePassword)
    changePassword(ctx: StateContext<SessionStateModel>, { payload }: SessionAction.ChangePassword) {
        return this.userService.changePassword(payload).pipe(map((session: any) => {

            if (session.HashPassword.length > 0 && !!session) {
                ctx.patchState({ UserPasswordHasBeenReset: session.UserPasswordHasBeenReset });
                this.router.navigate(['/home']);
            }
            return session;
        }), catchError(err => {
            this.messengerService.addMessage(err);
            return of()
        }));
    }

    @Action(SessionAction.Logout)
    logout(ctx: StateContext<SessionStateModel>) {
        ctx.setState(DEFAUL_SESSION_STATE);
        this.router.navigate(['/login']);
    }

    @Selector()
    static getSession(state: SessionStateModel): SessionStateModel {
        return state;
    }

    @Selector()
    static getToken(state: SessionStateModel): string {
        return state.Token;
    }

    @Selector()
    static getUserLoginName(state: SessionStateModel): string {
        return state.UserLogin;
    }

    @Selector()
    static getUserFullName(state: SessionStateModel): string {
        return state.FullName;
    }

    @Selector()
    static getUserId(state: SessionStateModel): number {
        return state.UserId;
    }

    @Selector()
    static getUserRoles(state: SessionStateModel): string[] {
        return state.Claims;
    }
}