import { Component, InjectDecorator, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MusteriDto, MusteriGuncelleDto, MusteriServiceProxy, UserDto } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { MusteriEkleComponent } from './musteri-ekle/musteri-ekle.component';

@Component({
  selector: 'app-musteri',
  templateUrl: './musteri.component.html',
  styleUrls: ['./musteri.component.css']
})
export class MusteriComponent extends AppComponentBase implements OnInit {

  musteriler: MusteriGuncelleDto []= [];
  users : UserDto[]=[];

  constructor(
    injector: Injector,
    private _musteriServiceProxy: MusteriServiceProxy,
    private _modalService: BsModalService
    ) {
    super(injector)
   }

  ngOnInit(): void {
    this.MusteriList();
  }

  MusteriList(){
    this._musteriServiceProxy.getMusteriList()
    .subscribe((res) => {
      this.musteriler = res;
    })
  }
  private showEkleOrDüzenleMusteri(id?: number): void {
    let ekleOrdüzenleMusteri: BsModalRef;
    if (!id) {
      ekleOrdüzenleMusteri = this._modalService.show(
        MusteriEkleComponent,
        {
          class: 'modal-lg',
        }
      );
    }

    ekleOrdüzenleMusteri.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  createMusteri(): void {
    this.showEkleOrDüzenleMusteri();
  }

  protected delete(musteri :MusteriDto): void {
    abp.message.confirm(
      this.l(musteri.musteriAdi+' isimli müşteriniz silinecek! Onaylıyor musunuz?' ),
      undefined,
      (result: boolean) => {
        if (result) {
          this._musteriServiceProxy.deleteMusteri(musteri.musteriId).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  refresh() {
    this.MusteriList();
  }
}
