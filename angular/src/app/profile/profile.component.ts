import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { YoneticiDto, YoneticiGuncelleDto, YoneticiServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent extends AppComponentBase implements OnInit {

  @Output() onSave=new EventEmitter<any>();
  saving=false;
  id:number;
  rolid:number;
  updateYonetici:NgForm;
  yoneticiDetails=new YoneticiDto;
  yoneticiGuncelle:YoneticiGuncelleDto;

  constructor
  (
    injector:Injector,
    private _yoneticiServiceProxy:YoneticiServiceProxy,
    private _modalService:BsModalService,
    private route:ActivatedRoute
    
  ) {
    super(injector);
  }

  ngOnInit(): void {

    this.id=this.route.snapshot.params['id'];
    this.rolid=this.route.snapshot.params['rolid']
    if(this.rolid==1){
      this.getMyProfile(this.id)
    }

  }
  getMyProfile(id:number){
    this.yoneticiGuncelle=new YoneticiGuncelleDto();
    this._yoneticiServiceProxy.getYoneticiByYoneticiId(id).subscribe((res)=>{
      this.yoneticiDetails=res;
    });
  }





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

}
