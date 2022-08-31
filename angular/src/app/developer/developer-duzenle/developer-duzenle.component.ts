import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DeveloperGuncelleDto, DeveloperProjectsDto, DevelopersServiceProxy, GorevDto, GorevServiceProxy, ProjeDto, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DeveloperProjeAtaComponent } from '../developer-proje-ata/developer-proje-ata.component';


@Component({
  selector: 'app-developer-duzenle',
  templateUrl: './developer-duzenle.component.html',
  styleUrls: ['./developer-duzenle.component.css']
})
export class DeveloperDuzenleComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  saving=false;
  id:number;
  updateDeveloper:NgForm;
  projeler: ProjeDto[] = [];
  developerDetails=new DeveloperDto;
  developerGuncelle:DeveloperGuncelleDto;
  gorevler:GorevDto[]=[];
  projectByDeveloper : string;
  constructor(
    injector:Injector,
    private _developerServiceProxy:DevelopersServiceProxy,
    private _projeServiceProxy:ProjeServiceProxy,
    private _gorevServiceProxy:GorevServiceProxy,
    private _modalService:BsModalService,
    private route:ActivatedRoute
  ) { 
    super(injector)
  }

  ngOnInit(){
    this.id=this.route.snapshot.params['id'];
    this.developerGuncelle=new DeveloperGuncelleDto();
    this.BilgileriGetir();
    this.GorevleriGetir();
  }

  BilgileriGetir(){
    this._developerServiceProxy.getDeveloperByDeveloperId(this.id)
      .subscribe((res)=>{
        this.developerDetails=res;
        this.projectByDeveloper = this.developerDetails.projeAdiTest;
    });
  }

  GorevleriGetir(){
    this._gorevServiceProxy.getGorevByDeveloper(this.id)
      .subscribe((res)=>{
        this.gorevler=res;
      }
    )
  }

  save(){
    this.saving=true;
    this.id=this.route.snapshot.params['id'];

    let input=this.developerGuncelle;
    this._developerServiceProxy.developerGuncelle(this.id,input).subscribe(
      ()=>{
        this.notify.info(this.l('Saved Succesful'));
        this.onSave.emit();
      },
      ()=>{
        this.saving=false;
      }
    )
  }

  refresh(){
   
  }
}
