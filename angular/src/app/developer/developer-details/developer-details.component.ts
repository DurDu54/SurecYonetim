import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DevelopersServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-developer-details',
  templateUrl: './developer-details.component.html',
  styleUrls: ['./developer-details.component.css']
})
export class DeveloperDetailsComponent extends AppComponentBase implements OnInit {
  developerlar:DeveloperDto[]=[];
  private routeSub: Subscription;
  constructor(
    injector:Injector,
    private _developerServiceProxy:DevelopersServiceProxy,
    private _modalService:BsModalService,
    private route: ActivatedRoute
  ) { 
    super(injector)
  }

  ngOnInit(): void {
    // this.routeSub = this.route.params.subscribe(params => {
    //   console.log(params) //log the entire params object
    //   console.log(params['id']) //log the value of id
    // });
    this._developerServiceProxy.getDeveloperList()
    .subscribe((res)=>{
      this.developerlar = res;
      
    })
  }

  private showekleorDüzenleDeveloper(id?: number):void{
    let ekleOrDüzenleDeveloper :BsModalRef;    
    ekleOrDüzenleDeveloper.content.onSave.subscribe(()=>{
      this.refresh();
    });
  }
  refresh() {
    throw new Error('Method not implemented.');
  }

}
