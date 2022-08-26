import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { DeveloperDto, DevelopersServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DeveloperEkleComponent } from './developer-ekle/developer-ekle.component';
//  import{slugify} from "angular-slugify";

@Component({
  selector: 'app-developer',
  templateUrl: './developer.component.html',
  styleUrls: ['./developer.component.css']
})
export class DeveloperComponent extends AppComponentBase implements OnInit {

  developerlar : DeveloperDto[]=[];
  constructor(
    injector: Injector,
    private _developerServiceProxy :DevelopersServiceProxy,
    private _modalService : BsModalService
  ) {
    super( injector)
   }

  ngOnInit(): void {    
    this.DeveloeprLİstele();
  }
  DeveloeprLİstele(){
    this._developerServiceProxy.getDeveloperList()
    .subscribe((res)=>{
      this.developerlar = res;
    })
  }

  createDeveloper():void{
      this.showekleorDüzenleDeveloper();
    }
    
  private showekleorDüzenleDeveloper(id?: number):void{
    let ekleOrDüzenleDeveloper :BsModalRef;
    if(!id){
      ekleOrDüzenleDeveloper = this._modalService.show(
        DeveloperEkleComponent,{
          class: 'modal-lg',
        }
      );
    }
    ekleOrDüzenleDeveloper.content.onSave.subscribe(()=>{
      this.refresh();
    });
  }

  protected delete(developer :DeveloperDto): void {
    abp.message.confirm(
      this.l(developer.developerName+' isimli geliştiriciniz silinecek! Onaylıyor musunuz?' ),
      undefined,
      (result: boolean) => {
        if (result) {
          this._developerServiceProxy.deleteDeveloper(developer.developerId).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  refresh(){
    this.DeveloeprLİstele();
  }
}
