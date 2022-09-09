import { PhoneType } from "./phoneType";

export interface ContactPhone {
    id: number;
    type: PhoneType;
    value: string;
}