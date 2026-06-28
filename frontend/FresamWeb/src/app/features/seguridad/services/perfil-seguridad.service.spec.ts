import { TestBed } from '@angular/core/testing';

import { PerfilSeguridadService } from './perfil-seguridad.service';

describe('PerfilSeguridadService', () => {
  let service: PerfilSeguridadService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PerfilSeguridadService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
