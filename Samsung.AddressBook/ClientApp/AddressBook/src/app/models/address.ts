import { AddressType } from "./addressType";

export interface ContactAddress {
    id: number;
    type: AddressType;
    value: string;
}
