import { Component } from '@angular/core';
import { LogService } from '../log.service';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  logs: any[] = [];
  searchQuery: string = '';
  startDate: string = '';
  endDate: string = '';
  level: string = '';

  constructor(private logService: LogService) {}

  
  getLogLevelClass(level: string): string {
    switch (level) {
      case 'ERROR': return 'text-danger';
      case 'WARN': return 'text-warning';
      case 'INFO': return 'text-primary';
      default: return 'text-secondary';
    }
  }
  
}
