import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperAlanDto, DevelopersServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DeveloperAlanEkleComponent } from './developer-alan-ekle/developer-alan-ekle.component';

@Component({
  selector: 'app-developer-alan',
  templateUrl: './developer-alan.component.html',
  styleUrls: ['./developer-alan.component.css']
})
export class DeveloperAlanComponent extends AppComponentBase implements OnInit {
   developerAlanlari :DeveloperAlanDto[]=[];
  constructor(
    injector: Injector,
    private _alanServiceProxy: DevelopersServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._alanServiceProxy.getDeveloperAlaniList()
    .subscribe((res) => {
      this.developerAlanlari = res;
    })
  }
  private showEkleOrDüzenleDeveloperAlan(id?: number): void {
    let ekleOrdüzenleGorev: BsModalRef;
    if (!id) {
      ekleOrdüzenleGorev = this._modalService.show(
        DeveloperAlanEkleComponent,
        {
          class: 'modal-lg',
        }
      );
      // } else {
      //   createOrEditUserDialog = this._modalService.show(
      //     EditUserDialogComponent,
      //     {
      //       class: 'modal-lg',
      //       initialState: {
      //         id: id,
      //       },
      //     }
      // );
    }

    ekleOrdüzenleGorev.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
  refresh() {
    window.location.reload();
  }
  createGorev(): void {
    this.showEkleOrDüzenleDeveloperAlan();
  }
  protected delete(developerAlan :DeveloperAlanDto): void {
    abp.message.confirm(
      this.l(developerAlan.developerAlani+' isimli alanınız silinecek! Onaylıyor musunuz?' ),
      undefined,
      (result: boolean) => {
        if (result) {
          this._alanServiceProxy.deleteDeveloperAlani(developerAlan.developerAlanId).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }
}
