import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { ProjeDto, ProjeDurumDto, ProjeGuncelleDto, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { Action } from 'rxjs/internal/scheduler/Action';

@Component({
  selector: 'app-proje-duzenle',
  templateUrl: './proje-duzenle.component.html',
  styleUrls: ['./proje-duzenle.component.css']
})
export class ProjeDuzenleComponent extends AppComponentBase implements OnInit {

@Output() onSave=new EventEmitter<any>();
  saving=false;
  id:number;
  updateProje:NgForm;
  projeDetails=new ProjeDto;
  projeGuncelle:ProjeGuncelleDto;
  listDurum : Observable<ProjeDurumDto[]>
  constructor(
    injector:Injector,
    private _projeServiceProxy:ProjeServiceProxy,
    private _modalService:BsModalService,
    private route:ActivatedRoute
  ) {
    super(injector)
   }

  ngOnInit(){
    this.id=this.route.snapshot.params['id'];
    this.projeGuncelle=new ProjeGuncelleDto();
    this.listDurum = this._projeServiceProxy.getProjeDurumuList();
    this._projeServiceProxy.getProjeById(this.id).subscribe(
      (res)=>{
        this.projeDetails=res;
      }
    )
  }

  save(){
    this.saving=true;
    this.id=this.route.snapshot.params['id'];
    let input=this.projeGuncelle;
    input.projeId = this.id;
    
    this._projeServiceProxy.projeGuncelle(this.id,input).subscribe(
      ()=>{
        this.notify.info(this.l('Saved Succesful'));
        this.onSave.emit();
      },
      ()=>{
        this.saving=false;
      }
    )
  }
}
