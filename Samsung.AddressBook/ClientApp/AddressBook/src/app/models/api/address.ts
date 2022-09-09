import { AddressType } from "../addressType";

export interface AddAddressRequest {
    contactId: number,
    type: AddressType,
    value: string
}


export interface UpdateAddressRequest {
    id: number,
    type: AddressType,
    value: string
}