import { ButtonComponent } from "src/app/shared/components/fields/button/button.component";
import { CheckBoxComponent } from "src/app/shared/components/fields/check-box/check-box.component";
import { DateComponent } from "src/app/shared/components/fields/date/date.component";
import { InputComponent } from "src/app/shared/components/fields/input/input.component";
import { RadioButtonComponent } from "src/app/shared/components/fields/radio-button/radio-button.component";
import { SelectComponent } from "src/app/shared/components/fields/select/select.component";
import { SelectWithApiResultComponent } from "src/app/shared/components/fields/select-with-api-result/select-with-api-result.component";
import { TextAreaComponent } from "src/app/shared/components/fields/text-area/text-area.component";
import { FieldType } from "../enums/field-type.enum";

export const fieldComponents = [
    { type: FieldType.INPUT, component: InputComponent, },
    { type: FieldType.BUTTON, component: ButtonComponent, },
    { type: FieldType.SELECT, component: SelectComponent, },
    { type: FieldType.SELECT_WITH_API_RESULT, component: SelectWithApiResultComponent, },
    { type: FieldType.DATE, component: DateComponent, },
    { type: FieldType.RADI_OBUTTON, component: RadioButtonComponent, },
    { type: FieldType.CHECK_BOX, component: CheckBoxComponent, },
    { type: FieldType.TEXTAREA, component: TextAreaComponent }
]
