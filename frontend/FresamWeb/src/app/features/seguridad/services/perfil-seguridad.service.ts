import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { PerfilSeguridad } from '../models/perfil-seguridad.model';

@Injectable({
  providedIn: 'root'
})

export class PerfilSeguridadService {
  
  private readonly http = inject(HttpClient);

  private readonly endpoint = `http://localhost:5001/api/v1/PerfilSeguridadUsuario`;

  obtenerPerfil(usuarioId: number): Observable<PerfilSeguridad> {
    return this.http.get<PerfilSeguridad>(
        `${this.endpoint}/${usuarioId}`
    );

  }
}
