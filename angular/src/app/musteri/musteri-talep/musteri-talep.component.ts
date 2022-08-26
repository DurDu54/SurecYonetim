import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MusteriIstekDto, MusteriServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { MusteriTalepEkleComponent } from './musteri-talep-ekle/musteri-talep-ekle.component';

@Component({
  selector: 'app-musteri-talep',
  templateUrl: './musteri-talep.component.html',
  styleUrls: ['./musteri-talep.component.css']
})
export class MusteriTalepComponent extends AppComponentBase implements OnInit {

  istekler:MusteriIstekDto[]=[];
  constructor(
    injector:Injector,
    private _musteriServiceProxy:MusteriServiceProxy,
    private _modalService:BsModalService
  ) { 
    super(injector)
  }

  ngOnInit(): void {
    this._musteriServiceProxy.getMusteriIstekList()
      .subscribe((res)=>{
        this.istekler=res;
      })
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
  createIstek(){
    this.showEkle();
  }
  
  refresh(){
    window.location.reload();
  }

}
