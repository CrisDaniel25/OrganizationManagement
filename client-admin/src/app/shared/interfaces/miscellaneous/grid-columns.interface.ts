import { FieldConfig } from "./field-config.interface";

export interface GridColumns {
  name: string;
  label: string;
  isId?: boolean;
  searchFields?: FieldConfig[];
  hasChip?: boolean;
  isDate?: boolean;
  isTime?: boolean;
  isMoney?: boolean;
}
