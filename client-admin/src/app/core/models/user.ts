export interface User {
    UserId?: number;
    UserLogin?: string;
    UserName?: string;
    FullName?: string;
    Token?: string;
    UserEmail?: string;
    Password?: string;
    Claims?: [];
    UserPasswordHasBeenReset?: boolean;
    UserPhone?: string;
    UserStatus?: string;
    TypeAutentication?: string;
}

