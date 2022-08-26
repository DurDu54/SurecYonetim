import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgSelectConfig } from '@ng-select/ng-select';

import { AppComponentBase } from '@shared/app-component-base';
import { DevelopersServiceProxy, DeveloperEkleDto, DeveloperDropDownDto, DeveloperAlanDto } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-developer-ekle',
  templateUrl: './developer-ekle.component.html',
  styleUrls: ['./developer-ekle.component.css']
})
export class DeveloperEkleComponent extends AppComponentBase implements OnInit {

  @Output() onSave = new EventEmitter<any>();
  saving = false;
  createDeveloper: NgForm;
  newDeveloper: DeveloperEkleDto;
  listDeveloper : Observable<DeveloperDropDownDto[]>;
  listAlan : Observable<DeveloperAlanDto[]>

  constructor(
    injector: Injector,
    private _developerServiceProxy: DevelopersServiceProxy,
    public bsModalRef: BsModalRef,
    private config: NgSelectConfig,
  ) {
    super(injector);
  }

  ngOnInit() {
    this.newDeveloper = new DeveloperEkleDto();
    this.listDeveloper = this._developerServiceProxy.getUserWithoutDeveloper();
    this.listAlan = this._developerServiceProxy.getDeveloperAlaniList();
  }
  save() {

    this.saving = true;
    let input = this.newDeveloper;
    this._developerServiceProxy.developerEkle(input).subscribe(
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
