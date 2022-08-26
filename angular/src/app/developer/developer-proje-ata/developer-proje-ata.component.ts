import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-developer-proje-ata',
  templateUrl: './developer-proje-ata.component.html',
  styleUrls: ['./developer-proje-ata.component.css']
})
export class DeveloperProjeAtaComponent extends AppComponentBase implements OnInit {

  @Output() onSave=new EventEmitter<any>();


  constructor(
    injector:Injector,
    private _projeServiceProxy:ProjeServiceProxy,
    public bsModalRef:BsModalRef,
    
  ) {super(injector) }

  ngOnInit(): void {
  }

}
