import { Component, Injector, OnInit, Output,EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AppComponentBase } from '@shared/app-component-base';
import { MusteriIstekEkleDto, MusteriServiceProxy, ProjeDto, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-musteri-talep-ekle',
  templateUrl: './musteri-talep-ekle.component.html',
  styleUrls: ['./musteri-talep-ekle.component.css']
})
export class MusteriTalepEkleComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  saving=false;
  createIstek:NgForm;
  newIstek:MusteriIstekEkleDto;
  listProje:Observable<ProjeDto[]>;
  id:number;
  constructor(
    injector:Injector,
    private _musteriServiceProxy:MusteriServiceProxy,
    private _projeServiceProxy:ProjeServiceProxy,
    public bsModalRef:BsModalRef,
    
  ) {
    super(injector);
   }

  ngOnInit(){
    this.newIstek=new MusteriIstekEkleDto();
    var url = window.location.pathname;
    this.id = parseInt(url.substring(url.lastIndexOf('/') + 1));
    this.listProje=this._projeServiceProxy.getProjeListMusteri(this.id);
  }

  save(){
    this.saving=true;
    let input=this.newIstek;
    input.musteriId=this.id;
    this._musteriServiceProxy.musteriIstekEkle(input).subscribe(
      ()=>{
        this.notify.info(this.l('Saved Succesful'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      ()=>{
        this.saving=false;
      }
    );
  }
}
