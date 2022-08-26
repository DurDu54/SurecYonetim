import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { YoneticiDto, YoneticiServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { YoneticiEkleComponent } from './yonetici-ekle/yonetici-ekle.component';

@Component({
  selector: 'app-yonetici',
  templateUrl: './yonetici.component.html',
  styleUrls: ['./yonetici.component.css']
})
export class YoneticiComponent extends AppComponentBase implements OnInit {

  yoneticiler : YoneticiDto []=[];
  out : number;

  constructor(
    injector: Injector,
    private _yoneticiServiceProxy: YoneticiServiceProxy,
    private _modalService: BsModalService
    ) {
    super(injector) }

  ngOnInit(): void {
    this.Listele()
  }
  
  public Listele(){
    this._yoneticiServiceProxy.getYoneticiList()
    .subscribe((res) => {
      this.yoneticiler = res;
    })
  }
  
  private showEkleOrDüzenleYonetici(id?: number): void {
    let ekleOrdüzenleYonetici: BsModalRef;
    if (!id) {
      ekleOrdüzenleYonetici = this._modalService.show(
        YoneticiEkleComponent,
        {
          class: 'modal-lg',
        }
      );
    }

    ekleOrdüzenleYonetici.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
  refresh() {
    this.Listele();
  }

  createYonetici(): void {
    this.showEkleOrDüzenleYonetici();
  }

  protected delete(yonetici :YoneticiDto): void {
    abp.message.confirm(
      this.l(yonetici.yoneticiName+' isimli yöneticinizi silinecek! Onaylıyor musunuz?' ),
      undefined,
      (result: boolean) => {
        if (result) {
          this._yoneticiServiceProxy.deleteYonetici(yonetici.yoneticiId).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }
}
