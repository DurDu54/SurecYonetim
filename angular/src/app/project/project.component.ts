import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DevelopersServiceProxy, MusteriServiceProxy, ProjeDto, ProjeServiceProxy, YoneticiServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent extends AppComponentBase implements OnInit {

  @Output() onSave=new EventEmitter<any>();
  saving=false;

  id:number;
  rolid:number;
  userid:number;

  projeler:ProjeDto[]=[];

  constructor(
    injector:Injector,
    private route: ActivatedRoute,
    private _yoneticiServiceProxy : YoneticiServiceProxy,
    private _musteriServiceProxy : MusteriServiceProxy,
    private _developerServiceProxy : DevelopersServiceProxy,
    private _projeServiceProxy : ProjeServiceProxy,
  ) {
    super(injector);
  }

  ngOnInit(): void {

    this.id = this.route.snapshot.params['id'];
    this.rolid = this.route.snapshot.params['rolid']
    if(this.rolid==1){
      this.getMyProjectYonetici(this.id);
    }
    if (this.rolid==2){
      this.getMyProjectMusteri(this.id);
    }
    if(this.rolid==3){
      this.getMyProjectDeveloper(this.id);
    }

  }
  getMyProjectDeveloper(id: number) {
    
  }
  getMyProjectMusteri(id: number) {
    throw new Error('Method not implemented.');
  }
  getMyProjectYonetici(id: number) {
    this._projeServiceProxy.getProjeListForYonetici(id).
    subscribe((res)=>{
      this.projeler = res;
    })
  }

}
