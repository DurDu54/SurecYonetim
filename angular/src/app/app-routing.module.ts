import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { ProjeComponent } from './proje/proje.component';
import { GorevComponent } from './gorev/gorev.component';
import { MusteriComponent } from './musteri/musteri.component';
import { DeveloperComponent } from './developer/developer.component';
import { YoneticiComponent } from './yonetici/yonetici.component';
import { DeveloperDuzenleComponent } from './developer/developer-duzenle/developer-duzenle.component';
import { MusteriDuzenleComponent } from './musteri/musteri-duzenle/musteri-duzenle.component';
import { YoneticiDuzenleComponent } from './yonetici/yonetici-duzenle/yonetici-duzenle.component';
import { DeveloperAlanComponent } from './developer-alan/developer-alan.component';

import { GorevDuzenleComponent } from './gorev/gorev-duzenle/gorev-duzenle.component';

import { ProjeDuzenleComponent } from './proje/proje-duzenle/proje-duzenle.component';
import { YoneticiProjeAtaComponent } from './yonetici/yonetici-proje-ata/yonetici-proje-ata.component';
import { DurumComponent } from './durum/durum.component';
import { YoneticiDashboardComponent } from './yonetici-dashboard/yonetici-dashboard.component';
import { ProfileComponent } from './profile/profile.component';
import { MusteriDashboardComponent } from './musteri-dashboard/musteri-dashboard.component';
import { ProjectComponent } from './project/project.component';
import { DeveloperDashboardComponent } from './developer-dashboard/developer-dashboard.component';
import { DevelopersComponent } from './developers/developers.component';
import { TasksComponent } from './tasks/tasks.component';
import { RequestComponent } from './request/request.component';


@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent, canActivate: [AppRouteGuard] },
                    { path: 'developeralan', component: DeveloperAlanComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'durum', component: DurumComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'proje', component: ProjeComponent, data: { permission: 'Pages.Proje' }, canActivate: [AppRouteGuard] },
                    { path: 'yonetici-dashboard', component: YoneticiDashboardComponent, data: { permission: 'Pages.Deneme' }, canActivate: [AppRouteGuard] },
                    { path: 'musteri-dashboard', component: MusteriDashboardComponent, data: { permission: 'Pages.Deneme' }, canActivate: [AppRouteGuard] },
                    { path: 'developer-dashboard', component: DeveloperDashboardComponent, data: { permission: 'Pages.Deneme' }, canActivate: [AppRouteGuard] },
                    { path: 'gorev', component: GorevComponent, data: { permission: 'Pages.Gorev' }, canActivate: [AppRouteGuard] },
                    { path: 'developer', component: DeveloperComponent, data: { permission: 'Pages.Developer' }, canActivate: [AppRouteGuard] },
                    { path: 'musteri', component: MusteriComponent, data: { permission: 'Pages.Musteri' }, canActivate: [AppRouteGuard] },
                    { path: 'yonetici', component: YoneticiComponent, data: { permission: 'Pages.Deneme' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'update-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard] },
                    { path: 'developer/developer-duzenle/:id', component: DeveloperDuzenleComponent, canActivate: [AppRouteGuard] },
                    {path:'musteri/musteri-duzenle/:id',component:MusteriDuzenleComponent,canActivate:[AppRouteGuard]},
                    {path:'yonetici/yonetici-duzenle/:id',component:YoneticiDuzenleComponent,canActivate:[AppRouteGuard]},
                    {path:'gorev/gorev-duzenle/:id',component:GorevDuzenleComponent,canActivate:[AppRouteGuard]},

                    { path:'profile/:id/:rolid',component:ProfileComponent,canActivate:[AppRouteGuard] },
                    { path:'project/:id/:rolid',component:ProjectComponent,canActivate:[AppRouteGuard] },
                    { path:'developers/:id/:rolid',component:DevelopersComponent,canActivate:[AppRouteGuard] },
                    { path:'tasks/:id/:rolid',component:TasksComponent,canActivate:[AppRouteGuard] },
                    { path:'request/:id/:rolid',component:RequestComponent,canActivate:[AppRouteGuard] },


                    { path:'musteri/musteri-duzenle/:id',component:MusteriDuzenleComponent,canActivate:[AppRouteGuard] },
                    { path:'yonetici/yonetici-duzenle/:id/:rolid',component:YoneticiDuzenleComponent,canActivate:[AppRouteGuard] },
                    { path:'proje/proje-duzenle/:id',component:ProjeDuzenleComponent,canActivate:[AppRouteGuard] },    
                    { path:'yonetici/yonetici-duzenle/:id',component:YoneticiProjeAtaComponent,canActivate:[AppRouteGuard] },    

                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
