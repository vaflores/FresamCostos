import { Modulo } from './modulo.model';

export interface PerfilSeguridad {
  usuarioId: number;
  usuarioNombre: string;
  modulos: Modulo[];
}