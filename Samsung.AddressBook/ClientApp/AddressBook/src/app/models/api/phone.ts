import { PhoneType } from "../phoneType";

export interface AddPhoneRequest {
    contactId: number,
    type: PhoneType,
    value: string
}

export interface UpdatePhoneRequest {
    id: number,
    type: PhoneType,
    value: string
}