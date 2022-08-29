import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DevelopersServiceProxy, GorevDto, MusteriIstekDto, ProjeDto, YoneticiDashboardServiceProxy, YoneticiDashDto, YoneticiDto, YoneticiGuncelleDto, YoneticiServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalService } from 'ngx-bootstrap/modal';
import { windowTime } from 'rxjs/operators';

@Component({
  selector: 'app-yonetici-dashboard',
  templateUrl: './yonetici-dashboard.component.html',
  styleUrls: ['./yonetici-dashboard.component.css']
})
export class YoneticiDashboardComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  
  projeler:ProjeDto[]=[];
  gorevler:GorevDto[]=[];
  developerlar:DeveloperDto[]=[];
  musteriIstekleri:MusteriIstekDto[]=[];
  yonetici=new YoneticiDashDto;
  yoneticiGuncelle:YoneticiGuncelleDto;
  yoneticiDetails=new YoneticiDto;
  countProject : number;
  countDeveloper: number;
  countTask : number;
  countMusteriIstek: number;
  Id :number;
  tabid:any;
  constructor(
    injector:Injector,
    private router: Router,
    private _yoneticiServiceProxy:YoneticiServiceProxy,
    private _dashboardServiceProxy:YoneticiDashboardServiceProxy,
    private _developerServiceProxy:DevelopersServiceProxy,
    private _modalService:BsModalService,
  ) { 
    super(injector)
  }
  
  ngOnInit(){
    
    this._dashboardServiceProxy.getYoneticiDashboardId().subscribe(
      (res)=>{
        this.yonetici=res;
        console.log(res);
        console.log(this.yonetici);
        const id=this.yonetici.yoneticiId;
        this.Id=this.yonetici.yoneticiId;
        this.getProjeler();
        this.getGorevler();
        this.getMusteriTalep();
        this.getDeveloper(id);
        this.getMiniProfile(id);
      }
    )
  }
  getMiniProfile( id : number){
    this.yoneticiGuncelle=new YoneticiGuncelleDto();
    this._yoneticiServiceProxy.getYoneticiByYoneticiId(id).subscribe((res)=>{
      this.yoneticiDetails=res;
    });
  }
  getDeveloper(yonId:number){
    this._developerServiceProxy.getDeveloperByYoneticiId(yonId)
      .subscribe((res)=>{        
        this.developerlar=res;
        this.countDeveloper=this.developerlar.length;
        console.log(yonId);
        console.log(res);
      });
  }
  getProjeler(){
    this._dashboardServiceProxy.getYoneticiDashboardProjeler().subscribe(      
      (res)=>{
        this.projeler=res;
        this.countProject=this.projeler.length;
      }
    )
  }
  getGorevler(){
    this._dashboardServiceProxy.getYoneticiDashboardGorevler().subscribe(
      (res)=>{
        this.gorevler=res;
        this.countTask=this.gorevler.length;
      }
    )
  }
  getMusteriTalep(){
    this._dashboardServiceProxy.getYoneticiDashboardMusteriTalepler().subscribe(
      (res)=>{
        this.musteriIstekleri=res;
        this.countMusteriIstek=this.musteriIstekleri.length;
      }
    )
  }

  // sayfa yönlendirme metotları
  goMyProfile(){
    this.router.navigateByUrl('app/profile/'+this.Id+'/1');
  }
  goMyProject(){
    this.router.navigateByUrl('app/yonetici/yonetici-duzenle/'+this.Id);
  }
  goMyDeveloper(){
    this.router.navigateByUrl('app/yonetici/yonetici-duzenle/'+this.Id);
  }
  goMyTasks(){
    this.router.navigateByUrl('app/yonetici/yonetici-duzenle/'+this.Id);
  }
  goMyCustomerTasks(){
    this.router.navigateByUrl('app/yonetici/yonetici-duzenle/'+this.Id);
  }
}
