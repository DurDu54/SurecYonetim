import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DevelopersServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-developers',
  templateUrl: './developers.component.html',
  styleUrls: ['./developers.component.css']
})
export class DevelopersComponent extends AppComponentBase implements OnInit {

  developerlar : DeveloperDto[]=[];
  id: number;
  constructor(
    injector: Injector,
    private route: ActivatedRoute,
    private _developerServiceProxy :DevelopersServiceProxy,
    private _modalService : BsModalService
  ) {
    super( injector)
   }

  ngOnInit(): void {    
    this.id = this.route.snapshot.params['id']
    this.DeveloeprLİstele();
  }
  DeveloeprLİstele(){
    this._developerServiceProxy.getDeveloperByYoneticiId(this.id)
    .subscribe((res)=>{
      this.developerlar = res;
    })
  }
}
