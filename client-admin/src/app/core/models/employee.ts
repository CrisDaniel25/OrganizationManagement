import { Client } from "./client";

export interface Employee {
    EmployeeId: number;
    IdentityDocument: string;
    FirstName: string;
    MiddleName: string;
    LastName: string;
    Email: string;
    Phone: string;
    Gender: string;
    BirthDate: Date;
    StartDate: Date;
    EndDate?: Date;
    Department: string;
    Position: string;
    IsActive: boolean;
    ClientId: number;
    CreatedUser?: number;
    CreatedDate?: Date;
    UpdatedUser?: number;
    UpdatedDate?: Date;
    Client?: Client
}