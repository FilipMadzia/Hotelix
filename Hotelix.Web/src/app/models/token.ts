export interface Token {
    sub: string;
    email: string;
    nbf: number;
    exp: number;
    iat: number;
    iss: string;
    aud: string;
}