import { Component, inject } from '@angular/core';
import { RouterOutlet} from '@angular/router'

import { HeaderComponent } from '../header/header.component';
import { SidenavComponent } from '../sidenav/sidenav.component';

import { MatToolbarModule} from '@angular/material/toolbar'
import { MatSidenavModule} from '@angular/material/sidenav'
import { MatListModule} from '@angular/material/list'
import { MatButtonModule} from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon';
import { TokenService } from '../../services/token.service';

import { PerfilSeguridadService } from '../../../features/seguridad/services/perfil-seguridad.service';

import { AppContextService } from '../../services/app-context.service';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [
    RouterOutlet,
    HeaderComponent,
    SidenavComponent,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.scss'
})
export class MainLayoutComponent {
  private readonly ts = inject(TokenService)
  private readonly pss = inject(PerfilSeguridadService);
  private readonly appContext = inject(AppContextService);


  ngOnInit(): void {

    const usuarioId = this.ts.getUserIdAsNumber();

    this.pss
        .obtenerPerfil(usuarioId)
        .subscribe({
            next: perfil => {
                this.appContext.setPerfilSeguridad(perfil);
                
                console.log(this.appContext.perfilSeguridad());
            }
        });
  }
}
