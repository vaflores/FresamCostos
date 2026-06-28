import { Permiso } from './permiso.model';

export interface Pantalla {
  pantallaId: number;
  nombre: string;
  orden: number;
  icono: string;
  ruta: string;
  permisos: Permiso[];
}