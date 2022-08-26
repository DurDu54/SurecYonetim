import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DevelopersServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-yonetici-developer-list',
  templateUrl: './yonetici-developer-list.component.html',
  styleUrls: ['./yonetici-developer-list.component.css']
})
export class YoneticiDeveloperListComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  id:number;
  developerlar:DeveloperDto[]=[];
  constructor(
    injector:Injector,
    private _developerServiceProxy:DevelopersServiceProxy,
    public bsModalRef:BsModalRef,
    private route:ActivatedRoute,
  ) { 
    super(injector)
  }

  ngOnInit(): void {
    this.id=this.route.snapshot.params['id'];
    this._developerServiceProxy.getDeveloperByYoneticiId(this.id).subscribe((res)=>{
      this.developerlar=res;
    })
  }

}
