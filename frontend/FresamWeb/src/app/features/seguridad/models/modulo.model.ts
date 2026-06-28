import { Pantalla } from './pantalla.model';

export interface Modulo {
  moduloId: number;
  nombre: string;
  orden: number;
  icono: string;
  pantallas: Pantalla[];
}