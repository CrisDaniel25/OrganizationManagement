import { Employee } from "./employee";

export interface Client {
    ClientId: number;
    Name: string;
    Email: string;
    Industry: string;
    Headquarters: string;
    Phone: string
    CompanySize: number;
    Website: string;
    Founded: Date;
    CreatedUser?: number;
    CreatedDate?: Date;
    UpdatedUser?: number;
    UpdatedDate?: Date;

    Employees?: Employee[];
}