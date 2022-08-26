import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgSelectConfig } from '@ng-select/ng-select';
import { AppComponentBase } from '@shared/app-component-base';
import { MusteriDto, MusteriServiceProxy, ProjeEkleDto, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-proje-ekle',
  templateUrl: './proje-ekle.component.html',
  styleUrls: ['./proje-ekle.component.css']
})
export class ProjeEkleComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  saving = false;
  newProje: ProjeEkleDto;
  createProje: NgForm;
  listMusteri: Observable<MusteriDto[]>

  constructor(
    injector: Injector,
    private _projeServiceProxy: ProjeServiceProxy,
    private _musteriServiceProxy: MusteriServiceProxy,
    public bsModalRef: BsModalRef,
    private config: NgSelectConfig

  ) {
    super(injector);
    this.config.appendTo = 'body';
    this.config.notFoundText = 'Custom not found '
    this.config.bindValue = 'value';
  }

  ngOnInit() {
    this.newProje = new ProjeEkleDto();
    this.listMusteri = this._musteriServiceProxy.getMusteriList();
  }
  save() {

    this.saving = true;
    let input = this.newProje;
    this._projeServiceProxy
      .projeEkle(input).subscribe(
        () => {
          this.notify.info(this.l('SavedSuccessfully'));
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        () => {
          this.saving = false;
        }
      );
  }
}
