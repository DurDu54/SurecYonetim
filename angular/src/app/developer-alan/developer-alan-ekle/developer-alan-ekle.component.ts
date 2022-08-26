import { Component, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperAlanDto, DevelopersServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { EventEmitter } from 'stream';

@Component({
  selector: 'app-developer-alan-ekle',
  templateUrl: './developer-alan-ekle.component.html',
  styleUrls: ['./developer-alan-ekle.component.css']
})
export class DeveloperAlanEkleComponent extends AppComponentBase implements OnInit {
  @Output() onSave 
  saving = false;
  alan = DeveloperAlanDto;
  newAlan = new DeveloperAlanDto();
  constructor(
    injector :Injector,
    private _alanServiceProxy : DevelopersServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    
  }
  refresh() {
  }

  save() {
    this.saving = true;
    let input = this.newAlan;
    this._alanServiceProxy.developerAlaniEkle(input).subscribe(
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
