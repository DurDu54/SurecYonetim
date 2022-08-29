import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { User, UserDto, UserServiceProxy, YoneticiDashboardServiceProxy, YoneticiDto, YoneticiGuncelleDto, YoneticiServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppSessionService } from '@shared/session/app-session.service';
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
  userid:number;
  updateYonetici:NgForm;
  yoneticiDetails=new YoneticiDto;
  yoneticiGuncelle:YoneticiGuncelleDto;
  userDetails:User;
  userUpdate : UserDto;

  constructor
  (
    injector:Injector,
    private _yoneticiServiceProxy:YoneticiServiceProxy,
    private _yoneticiDashService:YoneticiDashboardServiceProxy,
    private _userServiceProxy:UserServiceProxy,
    private _modalService:BsModalService,
    private route:ActivatedRoute
    
  ) {
    super(injector);
  }

  ngOnInit(): void {
    
    this.userDetails=new User();
    this.userUpdate=new UserDto();
    this.yoneticiGuncelle=new YoneticiGuncelleDto();
    this.id=this.route.snapshot.params['id'];
    this.rolid=this.route.snapshot.params['rolid']
    if(this.rolid==1){
      this.getMyProfile(this.id)
    }

  }
  getMyProfile(id:number){
    this._yoneticiServiceProxy.getYoneticiByYoneticiId(id).subscribe((res)=>{
      this.yoneticiDetails=res;
      this.userid=this.yoneticiDetails.userId;
      this.userBilgileriGetir(this.userid);
    });
    
  }
  userBilgileriGetir(userId:number){
    this._yoneticiDashService.getUserID(userId).subscribe((res)=>{
      this.userDetails=res;
    });
  }

 save(){
  if(this.rolid==1){
    this.saveyonetici()
  }
  if(this.rolid==2){
    this.saveDeveloper()
  }
  if(this.rolid==3){
    this.saveMusteri()
  }

 }
  saveMusteri() {
    throw new Error('musteri Save yazılacak');
  }
  saveDeveloper() {
    throw new Error('developer save eklenecek');
  }

  saveyonetici(){
    // save metotdu çalışmıyor çünkü user update 400 dönüyor yonetici guncelle çalışıyor

    this.saving=true;
    let inputYonetici=this.yoneticiGuncelle;
    let inputUser = this.userUpdate;
    this._yoneticiServiceProxy.yoneticiGuncelle(this.id,inputYonetici).subscribe(
      ()=>{
        this.notify.info(this.l('Saved Succesful'));
        this.onSave.emit();
      },
      ()=>{
        
        this.saving=false;
      }
    )

    this._yoneticiDashService.userGuncelle(inputUser).subscribe(
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
function elseif() {
  throw new Error('Function not implemented.');
}

