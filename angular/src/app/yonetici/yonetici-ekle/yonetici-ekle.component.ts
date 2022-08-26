import { Component,EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AppComponent } from '@app/app.component';
import { NgSelectConfig } from '@ng-select/ng-select';
import { AppComponentBase } from '@shared/app-component-base';
import { YoneticiDropDownDto, YoneticiEkleDto, YoneticiServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-yonetici-ekle',
  templateUrl: './yonetici-ekle.component.html',
  styleUrls: ['./yonetici-ekle.component.css']
})
export class YoneticiEkleComponent extends AppComponentBase implements OnInit {

  @Output() onSave=new EventEmitter<any>();
  saving=false;
  newYonetici: YoneticiEkleDto;
  createYonetici:NgForm;
  listUser : Observable<YoneticiDropDownDto[]>;

  constructor(
    injector:Injector,
    private _yoneticiServiceProxy:YoneticiServiceProxy,
    public bsModalRef:BsModalRef,
    private config : NgSelectConfig,
  ) { 
    super(injector);
    this.config.notFoundText = 'Custom not found';
    this.config.appendTo = 'body';
    this.config.bindValue = 'value';
  }

  ngOnInit(){
    this.newYonetici= new YoneticiEkleDto();
    this.listUser=this._yoneticiServiceProxy.getUserWithoutYonetici();
  }

  save(){
    this.saving=true;
    let input = this.newYonetici;
    this._yoneticiServiceProxy.yoneticiEkle(input).subscribe(
      ()=>{
        this.notify.info(this.l('Saved Succesful'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      ()=>{
        this.saving=false;
      }
    );

  }
}
