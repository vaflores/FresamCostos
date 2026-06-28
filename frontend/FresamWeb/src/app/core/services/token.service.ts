import { Injectable } from '@angular/core';
import { JwtPayload } from '../models/auth/jwt-payload';

@Injectable({
  providedIn: 'root'
})

export class TokenService {

  private readonly TOKEN_KEY = 'access_token';

  setToken(token: string): void {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  removeToken(): void {
    localStorage.removeItem(this.TOKEN_KEY);
  }

  hasToken(): boolean {
    return this.getToken() !== null
        && !this.isTokenExpired();
  }

  private decodePayload(): JwtPayload | null {
    try{
      const token = this.getToken();

      if(!token)
        return null;

      const payload = token.split('.')[1];

      const base64 = payload
        .replace(/-/g, '+')
        .replace(/_/g, '/');

      const json = decodeURIComponent(
        atob(base64)
          .split('')
          .map(c =>
            '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2))
          .join('')
      );

      return JSON.parse(json) as JwtPayload;

    }
    catch {
      return null;
    }
  }

  isTokenExpired(): boolean {

    const payload = this.decodePayload();

    if (!payload) {
        return true;
    }

    const expiration = payload.exp * 1000;

    return Date.now() > expiration;

  }

  getUserId(): string | null {
    return this.decodePayload()?.sub ?? null;
  }

  getUserIdAsNumber(): number {
    return Number(this.getUserId());
  }

  getUserName(): string | null {
    return this.decodePayload()?.unique_name ?? null;
  }

  getPermissions(): string[] {
    return this.decodePayload()?.permission ?? [];
  }

  hasPermission(permission: string): boolean {
    return this.getPermissions().includes(permission);
  }

}