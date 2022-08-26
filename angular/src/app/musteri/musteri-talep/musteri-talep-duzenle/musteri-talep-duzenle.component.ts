import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AppComponentBase } from '@shared/app-component-base';
import { MusteriIstekDto, MusteriIstekDuzenleDto, MusteriServiceProxy, ProjeDto, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-musteri-talep-duzenle',
  templateUrl: './musteri-talep-duzenle.component.html',
  styleUrls: ['./musteri-talep-duzenle.component.css']
})
export class MusteriTalepDuzenleComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  saving=false;
  editIstek:NgForm;
  istek=new MusteriIstekDto;
  newIstek:MusteriIstekDuzenleDto;
  id:number;
  urlId:number;
  constructor(
    injector:Injector,
    private _musteriServiceProxy:MusteriServiceProxy,   
    private _projeServiceProxy:ProjeServiceProxy, 
    public bsModalRef:BsModalRef,
  ) { 
    super(injector)
  }

  ngOnInit(){
    
    var url = window.location.pathname;
    this.urlId = parseInt(url.substring(url.lastIndexOf('/') + 1));
    
    this.newIstek=new MusteriIstekDuzenleDto();
    
    this._musteriServiceProxy.getMusteriIstekById(this.id).subscribe(
      (res)=>{
        this.istek=res;
      }
    )
  }
  save(){
    this.saving=true;
    let input=this.newIstek;
    this._musteriServiceProxy.musteriIstekUpdate(this.id,input)
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
