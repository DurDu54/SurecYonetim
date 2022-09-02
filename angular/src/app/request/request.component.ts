import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { MusteriIstekDto, MusteriServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  saving=false;

  id:number;
  rolid:number;

  requests : MusteriIstekDto[]=[];
  constructor(
    injector : Injector,
    private route: ActivatedRoute,
    private requestServiceProxy : MusteriServiceProxy
  ) {
    super(injector)
   }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.rolid = this.route.snapshot.params['rolid']
    if(this.rolid == 1){
      this.getRequestYonetici(this.id);
    }
    if(this.rolid == 2){
      this.getRequestMusteri(this.id);
    }
  }
  getRequestMusteri(id: number) {
    this.requestServiceProxy.getMusteriIstekByMusteriId(id).subscribe((res)=>{
      this.requests=res;
    })
  }
  getRequestYonetici(id: number) {
    this.requestServiceProxy.getMusteriIstekByMusteriId(id).subscribe((res)=>{
      this.requests=res;
    })
  }

}
