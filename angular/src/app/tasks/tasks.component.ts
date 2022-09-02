import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { GorevDto, GorevServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  saving=false;

  id:number;
  rolid:number;

  tasks : GorevDto[]=[];
  constructor(
    injector:Injector,
    private route: ActivatedRoute,
    private taskServiceProxy : GorevServiceProxy,
  ) { 
    super(injector);
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.rolid = this.route.snapshot.params['rolid']
    if(this.rolid == 1){
      this.getTasksYonetici(this.id);
    }
    if(this.rolid == 3){
      this.getTasksDeveloper();
    }
  }


  getTasksYonetici(id : number){
    this.taskServiceProxy.getGorevForYonetici(id).
    subscribe((res)=>{
      this.tasks = res;
    })
  }
  getTasksDeveloper(){
    this.taskServiceProxy.getGorevByDeveloper(this.id)
    .subscribe(
      (res)=>{
        this.tasks=res;
      }
    )
  }
}
