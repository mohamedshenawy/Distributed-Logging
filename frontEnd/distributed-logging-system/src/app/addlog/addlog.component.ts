import { Component } from '@angular/core';
import { LogService } from '../log.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-addlog',
  imports: [FormsModule],
  templateUrl: './addlog.component.html',
  styleUrl: './addlog.component.scss'
})
export class AddlogComponent {
  constructor(private logService: LogService) {}
  serviceName:string = ''
  level:string = ''
  message : string = ''
  addLog(){
    this.logService.addLog({ServiceName:this.serviceName , LogLevel:this.level , Message :this.message }).subscribe((res)=>{
      document.querySelectorAll<HTMLInputElement>("form input").forEach(input =>{
        input.value = '';
      })
      document.querySelectorAll<HTMLInputElement>("form select").forEach(select =>{
        select.value = '';
      })
    })
  }
}
