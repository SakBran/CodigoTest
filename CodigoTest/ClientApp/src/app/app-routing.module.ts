import { MedicalRecordEditComponent } from './Medical/medical-record-edit/medical-record-edit.component';
import { MedicalRecordListComponent } from './Medical/medical-record-list/medical-record-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
const routes: Routes = [
  {
    path: '',
    component: MedicalRecordListComponent,
    pathMatch: 'full'
  },
  {
    path: 'medicalRecords',
    component: MedicalRecordListComponent,
   // canActivate: [AuthorizeGuard]
  },
  {
    path: 'medicalRecord/:id',
    component: MedicalRecordEditComponent,
   // canActivate: [AuthorizeGuard]
  },
  {
    path: 'medicalRecord',
    component: MedicalRecordEditComponent,
   // canActivate: [AuthorizeGuard]
  },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
