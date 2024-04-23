import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MarksListComponent } from './Components/marks/marks-list/marks-list.component';
import { HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MarksAddComponent } from './Components/marks/marks-add/marks-add.component';
import { MarksEditComponent } from './Components/marks/marks-edit/marks-edit.component';
import { MarksDeleteComponent } from './Components/marks/marks-delete/marks-delete.component';
import { AttendanceListComponent } from './Components/attendance/attendance-list/attendance-list.component';
import { AttendanceAddComponent } from './Components/attendance/attendance-add/attendance-add.component';
import { FeeListComponent } from './Components/fee/fee-list/fee-list.component';
import { FeeEditComponent } from './Components/fee/fee-edit/fee-edit.component';
import { FeeCreateComponent } from './Components/fee/fee-create/fee-create.component';
//import { FeetypeComponent } from './Components/feetype/feetype.component';
import { FeetypeListComponent } from './Components/feetype/feetype-list/feetype-list.component';
import { FeetypeEditComponent } from './Components/feetype/feetype-edit/feetype-edit.component';
import { FeetypeCreateComponent } from './Components/feetype/feetype-create/feetype-create.component';
import { MonthlypaymentListComponent } from './Components/monthlypayment/monthlypayment-list/monthlypayment-list.component';
import { MonthlypaymentEditComponent } from './Components/monthlypayment/monthlypayment-edit/monthlypayment-edit.component';
import { MonthlypaymentDetailsComponent } from './Components/monthlypayment/monthlypayment-details/monthlypayment-details.component';
import { MonthlypaymentCreatComponent } from './Components/monthlypayment/monthlypayment-create/monthlypayment-create.component';
import { StaffListComponent } from './Components/staff/staff-list/staff-list.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { DepartementListComponent } from './Components/department/department-list/department-list.component';
import { StaffSalaryListComponent } from './Components/staff-salary/staff-salary-list/staff-salary-list.component';
import { authInterceptor } from './Authentication/SecurityModels/auth.interceptor';
import { StaffCreateComponent } from './Components/staff/staff-create/staff-create.component';
import { ExamtypeListComponent } from './Components/examtype/examtype-list/examtype-list.component';
import { ExamtypeAddComponent } from './Components/examtype/examtype-add/examtype-add.component';
import { ExamtypeEditComponent } from './Components/examtype/examtype-edit/examtype-edit.component';
import { StaffEditComponent } from './Components/staff/staff-edit/staff-edit.component';
import { StaffDetailsComponent } from './Components/staff/staff-details/staff-details.component';
import {
  AggregateService, ColumnChooserService, ColumnMenuService, EditService, FilterService, GridModule, GroupService, PageService, PagerModule, ReorderService, ResizeService, SortService, SearchService,
  SelectionService, ExcelExportService, PdfExportService, DetailRowService, ToolbarService
} from '@syncfusion/ej2-angular-grids';
import { ChartModule } from '@syncfusion/ej2-angular-charts';
import { TextBoxModule, UploaderModule } from '@syncfusion/ej2-angular-inputs';
import { StaffDeleteComponent } from './Components/staff/staff-delete/staff-delete.component';
/*import { ToastModule, ToastrService } from '@syncfusion/ej2-angular-notifications';*/
/*import { ToastrModule, ToastrService } from 'ngx-toastr';*/





@NgModule({
  declarations: [
    AppComponent,
    MarksListComponent, MarksAddComponent, MarksEditComponent, MarksDeleteComponent, AttendanceListComponent, AttendanceAddComponent, FeeListComponent, FeeEditComponent, FeeCreateComponent, FeetypeListComponent, FeetypeEditComponent, FeetypeCreateComponent, MonthlypaymentListComponent, MonthlypaymentEditComponent, MonthlypaymentDetailsComponent, MonthlypaymentCreatComponent, StaffListComponent,  DepartementListComponent, StaffSalaryListComponent, StaffCreateComponent, ExamtypeListComponent, ExamtypeAddComponent, ExamtypeEditComponent, StaffEditComponent, StaffDetailsComponent, StaffDeleteComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    GridModule, PagerModule, ChartModule, TextBoxModule, UploaderModule


        
  ],
  providers: [PageService, SortService, FilterService, GroupService, EditService, AggregateService,
    ColumnChooserService, ColumnMenuService, ResizeService, ReorderService, SearchService,
    SelectionService, ExcelExportService, PdfExportService, DetailRowService, ToolbarService,
    provideAnimationsAsync(),
    provideHttpClient(withInterceptors([authInterceptor]))
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
