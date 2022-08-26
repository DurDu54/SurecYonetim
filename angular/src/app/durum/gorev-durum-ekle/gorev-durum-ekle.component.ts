
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { GorevDurumDto, GorevServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-gorev-durum-ekle',
  templateUrl: './gorev-durum-ekle.component.html',
})
export class GorevDurumEkleComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  saving = false;
  gorevdurum = GorevDurumDto;
  newgorevdurum = new GorevDurumDto();
  constructor(
    injector:Injector,
    private _gorevdurumServiceProxy : GorevServiceProxy,
    public bsModalRef: BsModalRef
  ) { 
    super(injector);
  }

  ngOnInit(): void {
  }

save() {
  this.saving = true;
  let input = this.newgorevdurum;
  this._gorevdurumServiceProxy.gorevDurumuEkle(input).subscribe(
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