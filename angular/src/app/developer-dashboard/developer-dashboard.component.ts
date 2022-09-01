import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDashboardServiceProxy, DeveloperDashDto, DeveloperDto, DeveloperGuncelleDto, DevelopersServiceProxy, GorevDto, ProjeDto } from '@shared/service-proxies/service-proxies';
import { Subscriber } from 'rxjs';

@Component({
  selector: 'app-developer-dashboard',
  templateUrl: './developer-dashboard.component.html',
  styleUrls: ['./developer-dashboard.component.css']
})
export class DeveloperDashboardComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  projeler : ProjeDto[]=[];
  gorevler : GorevDto[]=[];
  developerDetails = new DeveloperDto();
  developerGuncelle : DeveloperGuncelleDto;
  developer  = new DeveloperDashDto;
  countProje : number;
  countGorev : number;
  Id:number;

  constructor(
    injector:Injector,
    private router: Router,
    private _developerServiceProxy : DevelopersServiceProxy,
    private _dashboardServiceProxy : DeveloperDashboardServiceProxy,
    ) {
      super(injector)
     }

  ngOnInit(): void {

    this._dashboardServiceProxy.getDeveloperDashboardId().subscribe(
      (res)=>{
        this.developer=res;
        console.log(res);
        console.log(this.developer);
        const id = this.developer.developerId;
        this.Id = this.developer.developerId;
        this.getMiniProfile(this.Id);
        
      }
    )
        this.getProjeler();
        this.getGorevler();
  }

  getMiniProfile(id : number){
    this.developerGuncelle=new DeveloperGuncelleDto();
    this._developerServiceProxy.getDeveloperByDeveloperId(id).subscribe((res)=>{
      this.developerDetails=res;
    });
  }

  getProjeler(){
    this._dashboardServiceProxy.getDeveloperDashboardProjeler().subscribe(
      (res)=>{
        this.projeler=res;
        this.countProje=this.projeler.length;
      }
    )
  }

  getGorevler(){
    this._dashboardServiceProxy.getDeveloperDashboardGorevler().subscribe(
      (res)=>{
        this.gorevler=res;
        this.countGorev=this.gorevler.length;
      }
    )
  }
  goMyProfile(){
    this.router.navigateByUrl('app/profile/'+this.Id+'/2');
  }
  goMyProject(){
    this.router.navigateByUrl('app/project/'+this.Id+'/2');
  }
  goMyDeveloper(){
    console.log("Projeye Gidildi")
  }
  goMyTasks(){
    console.log("Projeye Gidildi")
  }
  goMyCustomerTasks(){
    console.log("Projeye Gidildi")
  }


}
