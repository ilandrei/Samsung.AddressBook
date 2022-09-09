import { AddressType } from "../addressType"
import { PhoneType } from "../phoneType"

export interface UpdateContactRequest {
    id: number,
    name: string,
    isFavorite: boolean
}
export interface CreateContactRequest {
    name: string,
    isFavorite: boolean,
    phones: NewContactPhone | undefined,
    addresses: NewContactAddress | undefined
}

export interface NewContactPhone {
    type: PhoneType,
    value: string
}

export interface NewContactAddress {
    type: AddressType,
    value: string
}