import { ContactAddress } from "./address";
import { ContactPhone } from "./phone";

export interface Contact {
    id: number,
    name: string,
    isFavorite: boolean,

    phones: ContactPhone[] | undefined,
    addresses: ContactAddress[] | undefined
}