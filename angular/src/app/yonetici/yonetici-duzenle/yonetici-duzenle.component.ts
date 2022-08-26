import { Component, EventEmitter, inject, Inject, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DeveloperGuncelleDto, DevelopersServiceProxy, GorevDto, GorevServiceProxy, ProjeDto, ProjeGuncelleDto, ProjeServiceProxy, YoneticiDto, YoneticiGuncelleDto, YoneticiServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { YoneticiDeveloperAtaComponent } from '../yonetici-developer-ata/yonetici-developer-ata.component';
import { YoneticiDeveloperListComponent } from '../yonetici-developer-list/yonetici-developer-list.component';
import { YoneticiDeveloperProjeComponent } from '../yonetici-developer-proje/yonetici-developer-proje.component';
import { YoneticiGorevAtaComponent } from '../yonetici-gorev-ata/yonetici-gorev-ata.component';
import { YoneticiGorevEkleComponent } from '../yonetici-gorev-ekle/yonetici-gorev-ekle.component';
import { YoneticiProjeAtaComponent } from '../yonetici-proje-ata/yonetici-proje-ata.component';

@Component({
  selector: 'app-yonetici-duzenle',
  templateUrl: './yonetici-duzenle.component.html',
  styleUrls: ['./yonetici-duzenle.component.css']
})
export class YoneticiDuzenleComponent extends AppComponentBase implements OnInit {

  @Output() onSave=new EventEmitter<any>();
  saving=false;
  id:number;
  rolid:number;
  projeler: ProjeDto[] = [];
  gorevler:GorevDto[]=[];
  developerlar:DeveloperDto[]=[];
  developerGuncelle = new DeveloperGuncelleDto();
  updateYonetici:NgForm;
  yoneticiDetails=new YoneticiDto;
  yoneticiGuncelle:YoneticiGuncelleDto;
  constructor(
    injector:Injector,
    private _yoneticiServiceProxy:YoneticiServiceProxy,
    private _projeServiceProxy:ProjeServiceProxy,
    private _developerServiceProxy:DevelopersServiceProxy,
    private _gorevServiceProxy:GorevServiceProxy,
    private _modalService:BsModalService,
    private route:ActivatedRoute
  ) { 
    super(injector)
  }
  


  ngOnInit(){
    
    this.id=this.route.snapshot.params['id'];
    this.rolid=this.route.snapshot.params['rolid']
    console.log("sdgsdgsdgsdgsdg"+this.rolid)
    this.yoneticiGuncelle=new YoneticiGuncelleDto();
    this._yoneticiServiceProxy.getYoneticiByYoneticiId(this.id).subscribe((res)=>{
      this.yoneticiDetails=res;
    });
    this.ProjeListele();
    this.DeveloperListele();
    this.GorevListele();
  }
  // Profil Sayfası
  save(){
    this.saving=true;
    this.id=this.route.snapshot.params['id'];

    let input=this.yoneticiGuncelle;
    this._yoneticiServiceProxy.yoneticiGuncelle(this.id,input).subscribe(
      ()=>{
        this.notify.info(this.l('Saved Succesful'));
        this.onSave.emit();
      },
      ()=>{
        
        this.saving=false;
      }
    )
  }
    //Projelerim Sayfası
  ProjeListele(){
      this._projeServiceProxy.getProjeListForYonetici(this.id)
      .subscribe((res) => {
        this.projeler = res;
      });
    }

    GorevListele(){
      this._gorevServiceProxy.getGorevForYonetici(this.id).subscribe((res) => {
        this.gorevler = res;
      });
    }
   

  private showEkleOrDüzenleProje(id?: number): void {
    let ekleOrdüzenleProje: BsModalRef;
    if (!id) {
      ekleOrdüzenleProje = this._modalService.show(
        YoneticiProjeAtaComponent,
        {
          class: 'modal-lg',
        }
      );
    }

    ekleOrdüzenleProje.content.onSave.subscribe(() => {
      this.ProjeListele();
    });
  }createProje(): void {
    this.showEkleOrDüzenleProje();
  }

  ProjeBirak(proje : ProjeGuncelleDto) : void{
    
    abp.message.confirm(
      this.l(proje.projeAdi+' isimli projeniz yetkinizden çıkıcak! Onaylıyor musunuz?' ),
      undefined,
      (result: boolean) => {
        if (result) {
          proje.projeYoneticisiId=null;
          this._projeServiceProxy.projeBırak(proje.projeId).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.ProjeListele();
          });
        }
      }
    );

  }

  // Developerlarım Sayfası
  private showDeveloperAta(id:number):void{
    let developerAta:BsModalRef;
    if(id){
      developerAta=this._modalService.show(
        YoneticiDeveloperAtaComponent,{class:'modal-lg'}
      );     
    }
    developerAta.content.onSave.subscribe(()=>{
      this.DeveloperListele();
    });
  }

  developerAta():void{
    this.showDeveloperAta(this.id)
  }

  DeveloperBirak(developer : DeveloperDto) : void{
    abp.message.confirm(
      this.l(developer.developerName+' isimli developerınız yetkinizden çıkıcak! Onaylıyor musunuz?' ),
      undefined,
      (result: boolean) => {
        if (result) {
          developer.yoneticiId=null;
          this._developerServiceProxy.developerBirak(developer.developerId ).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.DeveloperListele();
          });
        }
      }
    );
  }

   DeveloperListele(){
      this._developerServiceProxy.getDeveloperByYoneticiId(this.id)
      .subscribe((res)=>{
        this.developerlar=res;
      });
    }

    developerSec(proje:ProjeDto){
      this.showDeveloperSec(proje.projeId);
    }

    private showDeveloperSec(projeId:number){
      let yoneticiId=this.id
      let devSec:BsModalRef;
      devSec=this._modalService.show(
        YoneticiDeveloperProjeComponent,{
          class:'modal-lg',
          initialState:{
            yoneticiId:yoneticiId,
            projeId:projeId,
          }
        }
      )
    }
    

    gorevEkle(developer:DeveloperDto){
      this.showGorevEkle(developer.developerId);
    }

    private showGorevEkle(devId:number){
      let yoneticiId=this.id;
      let gorevModal:BsModalRef;
      gorevModal=this._modalService.show(
        YoneticiGorevEkleComponent,{
          class:'modal-lg',
          initialState:{
            id:yoneticiId,
            devId:devId
          }
        }
      )
    }

}
