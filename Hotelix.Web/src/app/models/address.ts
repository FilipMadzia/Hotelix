import { City } from "./city";

export interface Address {
    id: number;
    street: string;
    houseNumber: number;
    postalCode: string;
    city: City;
}
