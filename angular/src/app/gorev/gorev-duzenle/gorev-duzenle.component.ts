import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DurumEnum, GorevDto, GorevDurumDto, GorevGuncelleDto, GorevServiceProxy, ProjeDto } from '@shared/service-proxies/service-proxies';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-gorev-duzenle',
  templateUrl: './gorev-duzenle.component.html',
  styleUrls: ['./gorev-duzenle.component.css']
})
export class GorevDuzenleComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  saving=false;
  id:number;
  updateGorev:NgForm;
  gorevDetails=new GorevDto;
  gorevGuncelle:GorevGuncelleDto;
  listDurum : Observable<GorevDurumDto[]>
  
  constructor(
    injector : Injector,
    private _gorevServiceProxy:GorevServiceProxy,
    private _modalService : BsModalService,
    private route : ActivatedRoute
    ) {
    super(injector);
  }

  ngOnInit() {
    this.id=this.route.snapshot.params['id'];
    this.gorevGuncelle=new GorevGuncelleDto();
    this.BilgileriGetir();
    this.listDurum = this._gorevServiceProxy.getGorevDurumuList();
  }

  BilgileriGetir(){
    this._gorevServiceProxy.getGorevByGorevId(this.id).subscribe((res)=>{
      this.gorevDetails=res;
    })
  }

  save(){
    this.saving=true;
    this.id=this.route.snapshot.params['id'];
    let input = this.gorevGuncelle;
    input.gorevId= this.id;

    this._gorevServiceProxy.gorevGuncelle(input).subscribe(
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
