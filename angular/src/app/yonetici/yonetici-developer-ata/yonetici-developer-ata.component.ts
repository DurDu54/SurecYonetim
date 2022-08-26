import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DevelopersServiceProxy, YoneticiServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-yonetici-developer-ata',
  templateUrl: './yonetici-developer-ata.component.html',
  styleUrls: ['./yonetici-developer-ata.component.css']
})
export class YoneticiDeveloperAtaComponent extends AppComponentBase implements OnInit {

  @Output() onSave=new EventEmitter<any>();
  id:number
  developerlar:DeveloperDto[]=[];
  constructor(
    injector:Injector,
    private _developerServiceProxy:DevelopersServiceProxy,
    private _yoneticiServiceProxy:YoneticiServiceProxy,
    public bsModalRef:BsModalRef,
    private route:ActivatedRoute,
  ) {
    super(injector)
   }

  ngOnInit(): void {
    var url = window.location.pathname;
    this.id = parseInt(url.substring(url.lastIndexOf('/') + 1));

    this._developerServiceProxy.getDeveloperWithoutYonetici()
      .subscribe((res)=>{
        this.developerlar=res;
      })
  }
  refresh(){
    window.location.reload();
  }

  developerAlCagir(developer:DeveloperDto){
    this.developerAl(this.id,developer)
  }
  public developerAl(yoneticiId : number ,developer :DeveloperDto ): void {
    abp.message.confirm(
      this.l( developer.developerName +' isimli developerın sorumlusu yöneticisi olacaksınız! Onaylıyor musunuz?' ),
      undefined,
      (result: boolean) => {
        if (result) {
          this._yoneticiServiceProxy.developerYoneticiAtama(yoneticiId,developer.developerId).subscribe(() => {
            abp.notify.success(this.l('Succesful'));
            this.refresh();
          });
        }
      }
    );
  }
}
