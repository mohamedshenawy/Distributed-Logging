import { Component } from '@angular/core';
import { LogService } from '../log.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [FormsModule , CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  logs: any[] = [];
  startDate: string = '';
  endDate: string = '';
  level: string = '';
  filterObj = {
    startDate: "",
    endDate: "",
    level: ""
  }
  constructor(private logService: LogService) {}

  ngOnInit(){
    this.getLogs();
  }
  onSubmit(){
    this.filterObj.startDate = this.startDate;
    this.filterObj.endDate = this.endDate;
    this.filterObj.level = this.level;
    this.getLogs()
  }
  getLogs(){
    this.logService.getLogs(this.filterObj).subscribe((res:any)=>{
      console.log(res);
      
      this.logs = res;

    })
  }
  getLogLevelClass(level: string): string {
    switch (level) {
      case 'ERROR': return 'text-danger';
      case 'WARN': return 'text-warning';
      case 'INFO': return 'text-primary';
      default: return 'text-secondary';
    }
  }
  
}
