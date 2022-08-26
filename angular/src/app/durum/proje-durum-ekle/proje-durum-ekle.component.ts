
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ProjeDurumDto, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-proje-durum-ekle',
  templateUrl: './proje-durum-ekle.component.html',
})
export class ProjeDurumEkleComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  saving = false;
  projedurum = ProjeDurumDto;
  newprojedurum = new ProjeDurumDto();
  constructor(
    injector:Injector,
    private _projedurumServiceProxy : ProjeServiceProxy,
    public bsModalRef: BsModalRef
  ) { 
    super(injector);
  }

  ngOnInit(): void {
  }

save() {
  this.saving = true;
  let input = this.newprojedurum;
  this._projedurumServiceProxy.projeDurumuEkle(input).subscribe(
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
