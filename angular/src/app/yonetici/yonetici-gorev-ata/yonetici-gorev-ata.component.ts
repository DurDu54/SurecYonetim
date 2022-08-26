import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DevelopersServiceProxy, GorevDto, GorevEkleDto, GorevGuncelleDto, GorevServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-yonetici-gorev-ata',
  templateUrl: './yonetici-gorev-ata.component.html',
  styleUrls: ['./yonetici-gorev-ata.component.css']
})
export class YoneticiGorevAtaComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  id:number
  developerlar:DeveloperDto[]=[];
  gorevler:GorevDto[]=[];
  gorevEkle:GorevGuncelleDto;
  saving=false;
  constructor(
    injector:Injector,
    private _gorevServiceProxy:GorevServiceProxy,
    private _developerServiceProxy:DevelopersServiceProxy,
    public bsModalRef:BsModalRef,
    private route:ActivatedRoute
  ) { 
    super(injector)
  }

  ngOnInit(): void {
    this.gorevEkle=new GorevGuncelleDto();

    this.id=this.route.snapshot.params['id'];
    this._developerServiceProxy.getDeveloperByYoneticiId(this.id)
      .subscribe((res)=>{
        this.developerlar=res;
      });
    this._gorevServiceProxy.getGorevWithoutDeveloper().subscribe((res)=>{
      this.gorevler=res;
    })    
  }
  save(){
    this.saving=true;
    let input=this.gorevEkle;
    this._gorevServiceProxy.gorevToDeveloper(this.id,input).subscribe(
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
