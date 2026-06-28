export interface JwtPayload {
    sub: string;
    unique_name: string;
    permission: string[];
    exp: number;
    iss: number;
    aud: string;
}