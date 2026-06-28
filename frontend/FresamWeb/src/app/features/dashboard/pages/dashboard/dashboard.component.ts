import { Component, inject } from '@angular/core';
import { DatePipe } from '@angular/common';

import { AppContextService } from '../../../../core/services/app-context.service';

import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-dashboard',
  imports: [
    MatCardModule,
    MatDividerModule,
    MatIconModule,
    DatePipe
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {  
  private readonly appContext = inject(AppContextService);

  readonly perfil = this.appContext.perfilSeguridad;

  hoy: Date = new Date();

}
