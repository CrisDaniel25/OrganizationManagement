import { SessionStateModel } from "../interfaces";

export const DEFAUL_SESSION_STATE: SessionStateModel = {
    UserId: 0,
    UserLogin: '',
    UserPassword: '',
    UserName: '',
    UserPhone: '',
    UserEmail: '',
    UserStatus: '',
    UserSecretQuestion: '',
    UserSecretAnswer: '',
    UserPasswordHasBeenReset: false,
    IsPasswordExpires: null,
    PasswordExpiresDate: null,
    ActiveDateBegin: null,
    ActiveDateEnd: null,
    CreatedUser: null,
    CreatedDate: null,
    UpdatedUser: null,
    UpdatedDate: null,
    TypeAutentication: '',
    HashPassword: '',
    Accounts: null,
    GroupUsers: [],
    FullName: '',
    Token: '',
    GroupsAlt: [],
    OfficesAlt: [],
    Claims: [],
    PasswordFailedQuantity: 0
}