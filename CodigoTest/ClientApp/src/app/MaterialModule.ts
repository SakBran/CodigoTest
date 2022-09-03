import { MatTableExporterModule } from 'mat-table-exporter';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {NgModule} from '@angular/core';

@NgModule({
  exports: [
    MatTableExporterModule,
    MatDatepickerModule
  ]
})
export class MaterialModule {}
