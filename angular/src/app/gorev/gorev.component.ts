import { Component, InjectDecorator, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, GorevDto, GorevServiceProxy, ProjeDto } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { EkleGorevComponent } from './ekle-gorev/ekle-gorev.component';

@Component({
  selector: 'app-gorev',
  templateUrl: './gorev.component.html',
  styleUrls: ['./gorev.component.css']
})
export class GorevComponent extends AppComponentBase implements OnInit {

  gorevler: GorevDto[] = [];
  developerlar: DeveloperDto[] = [];
  projeler: ProjeDto[] = [];
  constructor(
    injector: Injector,
    private _gorevServiceProxy: GorevServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector)
  }

  ngOnInit(): void {

    this.GörevList();
  }
  GörevList(){
    this._gorevServiceProxy.getGorevList()
    .subscribe((res) => {
      this.gorevler = res;
    })
  }
  
  createGorev(): void {
    this.showEkleOrDüzenleGorev();
  }
  
  private showEkleOrDüzenleGorev(id?: number): void {
    let ekleOrdüzenleGorev: BsModalRef;
    if (!id) {
      ekleOrdüzenleGorev = this._modalService.show(
        EkleGorevComponent,
        {
          class: 'modal-lg',
        }
      );
    }

    ekleOrdüzenleGorev.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  refresh() {
    this.GörevList();
  }

  protected delete(gorev :GorevDto): void {
    abp.message.confirm(
      this.l(gorev.gorevTanimi+' isimli göreviniz silinecek! Onaylıyor musunuz?' ),
      undefined,
      (result: boolean) => {
        if (result) {
          this._gorevServiceProxy.deleteGorev(gorev.gorevId).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }
}


