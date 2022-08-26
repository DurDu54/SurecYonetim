import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DeveloperGuncelleDto, DevelopersServiceProxy, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-yonetici-developer-proje',
  templateUrl: './yonetici-developer-proje.component.html',
  styleUrls: ['./yonetici-developer-proje.component.css']
})
export class YoneticiDeveloperProjeComponent extends AppComponentBase implements OnInit {

  @Output() onSave=new EventEmitter<any>();
  saving=false;
  yoneticiId:number;
  projeId:number;
  developerlar:DeveloperDto[]=[];
  newDev:DeveloperGuncelleDto;

  
  constructor(
    injector:Injector,
    private _projeServiceProxy:ProjeServiceProxy,
    private _developerServiceProxy:DevelopersServiceProxy,
    public bsModalRef:BsModalRef,
  ) { 
    super(injector)
  }

  ngOnInit(){
    this.newDev=new DeveloperGuncelleDto();
    console.log(this.yoneticiId);
    this._developerServiceProxy.getDeveloperWithoutProje(this.yoneticiId)
      .subscribe((res)=>{
        this.developerlar=res;
      })
  }

  save(){
    this.saving=true;
    let input=this.newDev;
    let devId=input.developerId;
    this._developerServiceProxy.developerProjeAtama(this.projeId,devId)
      .subscribe(
        ()=>{
          this.notify.info(this.l('Saved Succesful'));
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        ()=>{
          this.saving=false;
        }
      )
  }
}
