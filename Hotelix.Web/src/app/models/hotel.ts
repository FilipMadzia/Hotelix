import { Address } from "./address";
import { Contact } from "./contact";

export interface Hotel {
    id: number;
    name: string;
    description: string;
    pricePerNight: number;
    hasInternet: boolean;
    hasTelevision: boolean;
    hasParking: boolean;
    hasCafeteria: boolean;
    coverImage: string;
    address: Address;
    contact: Contact;
}
