import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgSelectConfig } from '@ng-select/ng-select';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DevelopersServiceProxy, GorevEkleDto, GorevServiceProxy, ProjeDto, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-yonetici-gorev-ekle',
  templateUrl: './yonetici-gorev-ekle.component.html',
  styleUrls: ['./yonetici-gorev-ekle.component.css']
})
export class YoneticiGorevEkleComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  saving = false;
  gorev: GorevEkleDto;
  id:number;
  devId:number;
  newGorev: GorevEkleDto;
  listProje:Observable<ProjeDto[]>;
  listDeveloper : Observable<DeveloperDto[]>;

  constructor(
    injector: Injector,
    private _gorevServiceProxy: GorevServiceProxy,
    private _projeServiceProxy : ProjeServiceProxy,
    private _developerServiceProxy : DevelopersServiceProxy,
    public bsModalRef: BsModalRef,
    private config :NgSelectConfig
  ) {
    super(injector);
    this.config.notFoundText ='Custom not found ';
    this.config.appendTo='body';
    this.config.bindValue = 'value';
  }

  ngOnInit(): void {
    this.newGorev = new GorevEkleDto();
    this.listProje = this._projeServiceProxy.getProjeListForYonetici(this.id);
  }
  save() {
    this.saving = true;
    let input = this.newGorev;
    input.developerId=this.devId;
    this._gorevServiceProxy.gorevEkle(input).subscribe(
      () => {
        this.notify.info(this.l('Saved Succesful'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
