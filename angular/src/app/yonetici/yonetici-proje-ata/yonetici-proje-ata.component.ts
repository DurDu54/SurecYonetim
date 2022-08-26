import { Component, EventEmitter, Injector, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { ProjeDto, ProjeServiceProxy, YoneticiServiceProxy } from '@shared/service-proxies/service-proxies';
import { Console } from 'console';
import { BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-yonetici-proje-ata',
  templateUrl: './yonetici-proje-ata.component.html',
  styleUrls: ['./yonetici-proje-ata.component.css']
})
export class YoneticiProjeAtaComponent extends AppComponentBase implements OnInit {
  @Output() onSave=new EventEmitter<any>();
  id:number
  projeler: ProjeDto[] = [];
  constructor(
    injector: Injector,
    private _projeServiceProxy: ProjeServiceProxy,
    private _yoneticiServiceProxy : YoneticiServiceProxy,
    private _modalService: BsModalService,
    private route:ActivatedRoute
  ) {
    super(injector)
  }



  ngOnInit(): void {
    // const yoneticiId = this.route.snapshot.params;
    // console.log(yoneticiId);
    // this.route.params.subscribe((res) => {
    //   this.id = res.id;
    //   console.log(this.id, "testttttttttttttttttt");
    // })
    var url = window.location.pathname;
    this.id = parseInt(url.substring(url.lastIndexOf('/') + 1));
    console.log(this.id)
    this._projeServiceProxy.getProjeWithoutYonetici()
      .subscribe((res) => {
        this.projeler = res;
      })
  }
  refresh() {
    window.location.reload();
  }
  projeAlCagir(proje :ProjeDto){
    this.projeyiAl(this.id , proje)
  }
  public projeyiAl(yoneticiId : number ,proje :ProjeDto ): void {
    abp.message.confirm(
      this.l( proje.projeAdi +' isimli projenin sorumlusu yöneticisi olacaksınız! Onaylıyor musunuz?' ),
      undefined,
      (result: boolean) => {
        if (result) {
          this._yoneticiServiceProxy.projeYoneticiAtama(yoneticiId,proje.projeId).subscribe(() => {
            abp.notify.success(this.l('Succesful'));
            this.refresh();
          });
        }
      }
    );
  }
}
