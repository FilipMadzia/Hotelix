export interface HotelAdd {
    name: string;
    description?: string;
    pricePerNight: number;
    hasInternet: boolean;
    hasTelevision: boolean;
    hasParking: boolean;
    hasCafeteria: boolean;
    coverImage: string;
    address: {
        street: string;
        houseNumber: number;
        postalCode: string;
        cityId: number;
    };
    contact: {
        phoneNumber?: string;
        email?: string;
    };
}