export interface loginForm {
    userName: string;
    password: string;
}

export interface Session {
    UserId: number
    UserLogin: string
    UserPassword: string
    UserName: string
    UserPhone: string
    UserEmail: string
    UserStatus: string
    UserSecretQuestion: string
    UserSecretAnswer: string
    UserPasswordHasBeenReset: boolean
    IsPasswordExpires: any
    PasswordExpiresDate: any
    ActiveDateBegin: any
    ActiveDateEnd: any
    CreatedUser: any
    CreatedDate: any
    UpdatedUser: any
    UpdatedDate: any
    TypeAutentication: string
    HashPassword: string
    Accounts: any
    GroupUsers: any[]
    FullName: string
    Token: string
    GroupsAlt: any[]
    OfficesAlt: any[]
    Claims: string[]
    PasswordFailedQuantity: number
}

export interface SessionStateModel extends Session { }
