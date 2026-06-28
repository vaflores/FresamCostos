import { inject, Component, Input } from '@angular/core';
import { Router} from '@angular/router';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule} from '@angular/material/button'
import { MatSidenavModule, MatSidenav } from '@angular/material/sidenav';

import { AppContextService } from '../../services/app-context.service';
import { TokenService } from '../../services/token.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})

export class HeaderComponent {

  private readonly router = inject(Router);
  private readonly ts = inject(TokenService)
  private readonly appContext = inject(AppContextService)

  readonly perfil = this.appContext.perfilSeguridad;

  @Input({ required: true }) drawer!: MatSidenav;  
  
  logout(): void {

    this.ts.removeToken();  

    this.router.navigate(['/login']);
  }
}
