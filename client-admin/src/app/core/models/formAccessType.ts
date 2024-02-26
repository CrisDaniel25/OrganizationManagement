export interface Form {
    FormId?: number;
    FormModule?: string;
    FormName?: string;
    FormDescription?: string;
}

export interface AccessType {
    AccessTypeId?: number;
    AccessTypeDescription?: string;
    Checked?: boolean;
    FormAccessTypeId?: number;
}

export interface FormAccess {
    Form?: Form;
    AccessTypes?: AccessType[];
}

