import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientJsonpModule } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';
import { HomeComponent } from '@app/home/home.component';
import { AboutComponent } from '@app/about/about.component';
// tenants
import { TenantsComponent } from '@app/tenants/tenants.component';
import { CreateTenantDialogComponent } from './tenants/create-tenant/create-tenant-dialog.component';
import { EditTenantDialogComponent } from './tenants/edit-tenant/edit-tenant-dialog.component';
// roles
import { RolesComponent } from '@app/roles/roles.component';
import { CreateRoleDialogComponent } from './roles/create-role/create-role-dialog.component';
import { EditRoleDialogComponent } from './roles/edit-role/edit-role-dialog.component';
// users
import { UsersComponent } from '@app/users/users.component';
import { CreateUserDialogComponent } from '@app/users/create-user/create-user-dialog.component';
import { EditUserDialogComponent } from '@app/users/edit-user/edit-user-dialog.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { ResetPasswordDialogComponent } from './users/reset-password/reset-password.component';
// layout
import { HeaderComponent } from './layout/header.component';
import { HeaderLeftNavbarComponent } from './layout/header-left-navbar.component';
import { HeaderLanguageMenuComponent } from './layout/header-language-menu.component';
import { HeaderUserMenuComponent } from './layout/header-user-menu.component';
import { FooterComponent } from './layout/footer.component';
import { SidebarComponent } from './layout/sidebar.component';
import { SidebarLogoComponent } from './layout/sidebar-logo.component';
import { SidebarUserPanelComponent } from './layout/sidebar-user-panel.component';
import { SidebarMenuComponent } from './layout/sidebar-menu.component';
import { ProjeComponent } from './proje/proje.component';
import { GorevComponent } from './gorev/gorev.component';
import { MusteriComponent } from './musteri/musteri.component';
import { ProjeEkleComponent } from './proje/proje-ekle/proje-ekle.component';
import { EkleGorevComponent } from './gorev/ekle-gorev/ekle-gorev.component';
import { MusteriEkleComponent } from './musteri/musteri-ekle/musteri-ekle.component';
import { DeveloperComponent } from './developer/developer.component';
import { DeveloperEkleComponent } from './developer/developer-ekle/developer-ekle.component';
import { YoneticiComponent } from './yonetici/yonetici.component';
import { YoneticiEkleComponent } from './yonetici/yonetici-ekle/yonetici-ekle.component';
import { DeveloperDetailsComponent } from './developer/developer-details/developer-details.component';
import { DeveloperDuzenleComponent } from './developer/developer-duzenle/developer-duzenle.component';
import { MusteriDuzenleComponent } from './musteri/musteri-duzenle/musteri-duzenle.component';
import { YoneticiDuzenleComponent } from './yonetici/yonetici-duzenle/yonetici-duzenle.component';
import { YoneticiDeveloperAtaComponent } from './yonetici/yonetici-developer-ata/yonetici-developer-ata.component';
import { YoneticiDeveloperListComponent } from './yonetici/yonetici-developer-list/yonetici-developer-list.component';
import { YoneticiGorevAtaComponent } from './yonetici/yonetici-gorev-ata/yonetici-gorev-ata.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { DeveloperAlanComponent } from './developer-alan/developer-alan.component';
import { DeveloperAlanEkleComponent } from './developer-alan/developer-alan-ekle/developer-alan-ekle.component';

import { GorevDuzenleComponent } from './gorev/gorev-duzenle/gorev-duzenle.component';

import { ProjeDuzenleComponent } from './proje/proje-duzenle/proje-duzenle.component';
import { YoneticiProjeAtaComponent } from './yonetici/yonetici-proje-ata/yonetici-proje-ata.component';
import { MusteriTalepComponent } from './musteri/musteri-talep/musteri-talep.component';
import { MusteriTalepEkleComponent } from './musteri/musteri-talep/musteri-talep-ekle/musteri-talep-ekle.component';
import { MusteriTalepDuzenleComponent } from './musteri/musteri-talep/musteri-talep-duzenle/musteri-talep-duzenle.component';
import { YoneticiDeveloperProjeComponent } from './yonetici/yonetici-developer-proje/yonetici-developer-proje.component';
import { YoneticiGorevEkleComponent } from './yonetici/yonetici-gorev-ekle/yonetici-gorev-ekle.component';
import { DurumComponent } from './durum/durum.component';
import { ProjeDurumEkleComponent } from './durum/proje-durum-ekle/proje-durum-ekle.component';
import { GorevDurumEkleComponent } from './durum/gorev-durum-ekle/gorev-durum-ekle.component';
import { YoneticiDashboardComponent } from './yonetici-dashboard/yonetici-dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProfileComponent } from './profile/profile.component';
import { MusteriDashboardComponent } from './musteri-dashboard/musteri-dashboard.component';

 

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    // tenants
    TenantsComponent,
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    RolesComponent,
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    UsersComponent,
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ChangePasswordComponent,
    ResetPasswordDialogComponent,
    // layout
    HeaderComponent,
    HeaderLeftNavbarComponent,
    HeaderLanguageMenuComponent,
    HeaderUserMenuComponent,
    FooterComponent,
    SidebarComponent,
    SidebarLogoComponent,
    SidebarUserPanelComponent,
    SidebarMenuComponent,
    
    // proje
    ProjeComponent,
    ProjeEkleComponent,
    ProjeDuzenleComponent,
    
    // gorev
    GorevComponent,
    EkleGorevComponent,
    
    
    // musteri
    MusteriComponent,
    MusteriEkleComponent,

    // developer
    DeveloperComponent,
    DeveloperEkleComponent,
    YoneticiComponent,
    YoneticiEkleComponent,
    DeveloperDetailsComponent,
    DeveloperDuzenleComponent,
    MusteriDuzenleComponent,
    YoneticiDuzenleComponent,
    YoneticiDeveloperAtaComponent,
    YoneticiDeveloperListComponent,
    YoneticiGorevAtaComponent,
    DeveloperAlanComponent,
    DeveloperAlanEkleComponent,

    GorevDuzenleComponent,

    YoneticiProjeAtaComponent,
      MusteriTalepComponent,
      MusteriTalepEkleComponent,
      MusteriTalepDuzenleComponent,
      YoneticiDeveloperProjeComponent,
      YoneticiGorevEkleComponent,
      DurumComponent,
      ProjeDurumEkleComponent,
      GorevDurumEkleComponent,
      YoneticiDashboardComponent,
      ProfileComponent,
      MusteriDashboardComponent,

  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientJsonpModule,
    ModalModule.forChild(),
    BsDropdownModule,
    CollapseModule,
    FormsModule,
    NgSelectModule,
    
    TabsModule,
    AppRoutingModule,
    ServiceProxyModule,
    SharedModule,
    NgxPaginationModule,
  ],
  providers: [],
  entryComponents: [
    // tenants
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ResetPasswordDialogComponent,
  ],
})
export class AppModule {}
