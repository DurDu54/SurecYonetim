import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { MusteriDto, MusteriGuncelleDto, MusteriIstekDto, MusteriServiceProxy, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { MusteriTalepDuzenleComponent } from '../musteri-talep/musteri-talep-duzenle/musteri-talep-duzenle.component';
import { MusteriTalepEkleComponent } from '../musteri-talep/musteri-talep-ekle/musteri-talep-ekle.component';

@Component({
  selector: 'app-musteri-duzenle',
  templateUrl: './musteri-duzenle.component.html',
  styleUrls: ['./musteri-duzenle.component.css']
})

export class MusteriDuzenleComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  saving=false;
  id:number;
  istekler:MusteriIstekDto[]=[];
  updateMusteri:NgForm;
  musteriDetails=new MusteriDto;
  musteriGuncelle:MusteriGuncelleDto;
  constructor(
    injector:Injector,
    private _musteriServiceProxy:MusteriServiceProxy,
    private _projeServiceProxy:ProjeServiceProxy,
    private _modalService:BsModalService,
    private route:ActivatedRoute
  ) { 
    super(injector)
  }

  ngOnInit(){
    this.id=this.route.snapshot.params['id'];
    this.musteriGuncelle=new MusteriGuncelleDto();
    this.IstekleriGetir();
    this.ProfiliGetir();    
  }

  ProfiliGetir(){
    this._musteriServiceProxy.getMusteriById(this.id)
    .subscribe((res)=>{
      this.musteriDetails=res;
    });
  }

  IstekleriGetir(){
    this._musteriServiceProxy.getMusteriIstekByMusteriId(this.id)
    .subscribe((res)=>{
      this.istekler=res;
    });
  }

  save(){
    this.saving=true;
    this.id=this.route.snapshot.params['id'];
    let input=this.musteriGuncelle;
    this._musteriServiceProxy.musteriGuncelle(this.id,input).subscribe(
      ()=>{
        this.notify.info(this.l('Saved Succesful'));
        this.onSave.emit();
      },
      ()=>{
        this.saving=false;
      }
    )
  }
  createIstek(){
      this.showEkle();
  }

  private showEkle():void{
    let ekle:BsModalRef;
    ekle=this._modalService.show(
      MusteriTalepEkleComponent,{
        class:'modal-lg',
      }
    );
    ekle.content.onSave.subscribe(()=>{
      this.refresh();
    });
  }

  editIstek(istek:MusteriIstekDto){
    console.log("Test "+istek.musteriIstekId);
    this.showDuzenle(istek.musteriIstekId);
  }

  private showDuzenle(id:number):void{
    let duzenle:BsModalRef;
    duzenle = this._modalService.show(
      MusteriTalepDuzenleComponent,
      {
        class: 'modal-lg',
        initialState: {
          id: id,
        },
      }
    );
  }
 
  refresh(){
    this.IstekleriGetir();
  }
}
