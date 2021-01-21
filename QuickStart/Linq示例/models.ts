export interface Province {
    name: string;
    city: City[];
}

export interface City {
    name: string;
    area: string[];
}