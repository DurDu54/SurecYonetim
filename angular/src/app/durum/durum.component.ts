
import { Component, Injector, INJECTOR, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { GorevDurumDto, GorevServiceProxy, ProjeDurumDto, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { GorevDurumEkleComponent } from './gorev-durum-ekle/gorev-durum-ekle.component';
import { ProjeDurumEkleComponent } from './proje-durum-ekle/proje-durum-ekle.component';

@Component({
  selector: 'app-durum',
  templateUrl: './durum.component.html',
})
export class DurumComponent extends AppComponentBase implements OnInit {
  gorevDurum: GorevDurumDto[] = [];
  projeDurum: ProjeDurumDto[] = [];
 

  constructor(
    injector: Injector,
    private _modalService: BsModalService,
    private _gorevDurumProxy: GorevServiceProxy,
    private _projeDurumProxy: ProjeServiceProxy,
  ) {
    super(injector)
  }

  ngOnInit(): void {
    this.DurumGorevListele();
    this.DurumProjeListele();
  }

  DurumGorevListele() {
    this._gorevDurumProxy.getGorevDurumuList()
      .subscribe((res) => {
        this.gorevDurum = res;
      });
  }

  DurumProjeListele() {
    this._projeDurumProxy.getProjeDurumuList()
      .subscribe((res) => {
        this.projeDurum = res;
      });
  }

  refreshGorev() {
    this.DurumGorevListele() ;
  }

  refreshProje() {
    this.DurumProjeListele() ;
  }

  protected deleteGorevDurum(gorevDurum: GorevDurumDto): void {
    abp.message.confirm(
      this.l(gorevDurum.gorevDurumu + ' isimli alanınız silinecek! Onaylıyor musunuz?'),
      undefined,
      (result: boolean) => {
        if (result) {
          this._gorevDurumProxy.deleteGorevDurum(gorevDurum.gorevDurumId).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refreshGorev();
          });
        }
      }
    );
  }

  private showEkleOrDüzenleGorevDurum(id?: number): void {
    let ekleOrdüzenleGorev: BsModalRef;
    if (!id) {
      ekleOrdüzenleGorev = this._modalService.show(
        GorevDurumEkleComponent,
        {
          class: 'modal-lg',
        }
      );
    }
    ekleOrdüzenleGorev.content.onSave.subscribe(()=>{
      this.refreshGorev();
    });
  }

   private showEkleOrDüzenleProjeDurum(id?: number): void {
    let ekleOrdüzenleProje: BsModalRef;
    if (!id) {
      ekleOrdüzenleProje = this._modalService.show(
        ProjeDurumEkleComponent,
        {
          class: 'modal-lg',
        }
      );
    }
    ekleOrdüzenleProje.content.onSave.subscribe(()=>{
      this.refreshProje();
    });
  }
  createProjeDurum(): void {
    this.showEkleOrDüzenleProjeDurum();
  }
  createGorevDurum(): void {
    this.showEkleOrDüzenleGorevDurum();
  }

  protected deleteProjeDurum(projeDurum: ProjeDurumDto): void {
    abp.message.confirm(
      this.l(projeDurum.projeDurumu + ' isimli alanınız silinecek! Onaylıyor musunuz?'),
      undefined,
      (result: boolean) => {
        if (result) {
          this._projeDurumProxy.deleteProjeDurum(projeDurum.projeDurumId).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refreshProje();
          });
        }
      }
    );
  }
}