import { inject, Component } from '@angular/core';

import { RouterLink} from '@angular/router';

import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';

import { AppContextService } from '../../services/app-context.service';

@Component({
  selector: 'app-side-nav',
  imports: [
    MatIconModule,
    MatListModule,
    MatExpansionModule,
    RouterLink
  ],
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.scss'
})
export class SidenavComponent {
  private readonly appContext = inject(AppContextService);

  readonly perfil = this.appContext.perfilSeguridad;
  
}
