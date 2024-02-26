import { DateFormat } from "../utils/date-format.util";

export const MY_FORMATS = {
    parse: {
        dateInput: DateFormat.DATE_FMT.toUpperCase(),
    },
    display: {
        dateInput: DateFormat.DATE_FMT.toUpperCase(),
        monthYearLabel: 'MMM YYYY',
        dateA11yLabel: 'LL',
        monthYearA11yLabel: 'MMMM YYYY',
    },
};
