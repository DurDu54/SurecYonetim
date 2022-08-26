import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgSelectConfig } from '@ng-select/ng-select';
import { AppComponentBase } from '@shared/app-component-base';
import { MusteriDropDownDto, MusteriEkleDto, MusteriServiceProxy, User, UserDto } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-musteri-ekle',
  templateUrl: './musteri-ekle.component.html',
  styleUrls: ['./musteri-ekle.component.css']
})
export class MusteriEkleComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  saving = false;
  newMusteri: MusteriEkleDto;
  listMusteri: Observable<MusteriDropDownDto[]>;

  constructor(
    injector: Injector,
    private _musteriServiceProxy: MusteriServiceProxy,
    private config: NgSelectConfig,
    public bsModalRef: BsModalRef
  ) {
    super(injector)
    this.config.notFoundText = 'Custom not found';
    this.config.appendTo = 'body';
    this.config.bindValue = 'value';
  }

  ngOnInit() {
    this.newMusteri = new MusteriEkleDto();
    this.listMusteri = this._musteriServiceProxy.getUserWithoutMusteri();
  }

  save() {
    this.saving = true;

    let input = this.newMusteri;
    this._musteriServiceProxy
      .musteriEkle(input).subscribe(
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
