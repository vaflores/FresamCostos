import { Injectable, signal } from '@angular/core';

import { PerfilSeguridad } from '../../features/seguridad/models/perfil-seguridad.model';

@Injectable({
  providedIn: 'root'
})
export class AppContextService {

  readonly perfilSeguridad = signal<PerfilSeguridad | null>(null);

  setPerfilSeguridad(perfil: PerfilSeguridad): void {
    this.perfilSeguridad.set(perfil);
  }

  clear(): void {
    this.perfilSeguridad.set(null);
  }

}
