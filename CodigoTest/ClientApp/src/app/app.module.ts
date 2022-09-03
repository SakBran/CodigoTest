import { MaterialModule } from './MaterialModule';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { DashboardListComponent } from './dashboard/dashboard-list/dashboard-list.component';
import { TextBoxComponent } from './Tools/text-box/text-box.component';
import { ImageCropperModule } from 'ngx-image-cropper';
import { BaseEditComponent } from './Base/base-edit/base-edit.component';
import { BaseListComponent } from './Base/base-list/base-list.component';
import { NgChartsModule } from 'ng2-charts';
import { UserEditComponent } from './User/UseEdit/user-edit/user-edit.component';
import { UserListComponent } from './User/UseList/user-list/user-list.component';
import { DatePipe } from '@angular/common';
import { LogEditComponent } from './logs/log-edit/log-edit.component';
import { LogListComponent } from './logs/log-list/log-list.component';
import { NotFoundComponent } from './Base/not-found/not-found.component';
import { NoPermissionComponent } from './Base/no-permission/no-permission.component';
import { MedicalRecordEditComponent } from './Medical/medical-record-edit/medical-record-edit.component';
import { MedicalRecordListComponent } from './Medical/medical-record-list/medical-record-list.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    DashboardListComponent,
    TextBoxComponent,
    BaseEditComponent,
    BaseListComponent,
    UserEditComponent,
    UserListComponent,
    LogEditComponent,
    LogListComponent,
    NotFoundComponent,
    NoPermissionComponent,
    MedicalRecordEditComponent,
    MedicalRecordListComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    ReactiveFormsModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    ImageCropperModule,
    NgChartsModule,
    RouterModule.forRoot([]),
    MaterialModule
    ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizeInterceptor,
      multi: true
    },
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
