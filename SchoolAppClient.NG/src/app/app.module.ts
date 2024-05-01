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
/*import { DepartementListComponent } from './Components/department/department-list/department-list.component';*/
import { StaffSalaryListComponent } from './Components/staff-salary/staff-salary-list/staff-salary-list.component';
import { authInterceptor } from './Authentication/SecurityModels/auth.interceptor';
import { StaffCreateComponent } from './Components/staff/staff-create/staff-create.component';
import { ExamtypeListComponent } from './Components/examtype/examtype-list/examtype-list.component';
import { ExamtypeAddComponent } from './Components/examtype/examtype-add/examtype-add.component';
import { ExamtypeEditComponent } from './Components/examtype/examtype-edit/examtype-edit.component';
/*import { StaffEditComponent } from './Components/staff/staff-edit/staff-edit.component';*/
import { StaffDetailsComponent } from './Components/staff/staff-details/staff-details.component';
import {
  AggregateService, ColumnChooserService, ColumnMenuService, EditService, FilterService, GridModule, GroupService, PageService, PagerModule, ReorderService, ResizeService, SortService, SearchService,
  SelectionService, ExcelExportService, PdfExportService, DetailRowService, ToolbarService
} from '@syncfusion/ej2-angular-grids';
import { ChartModule } from '@syncfusion/ej2-angular-charts';
import { TextBoxModule, UploaderModule } from '@syncfusion/ej2-angular-inputs';
import { StaffDeleteComponent } from './Components/staff/staff-delete/staff-delete.component';
import { DepartmentEditComponent } from './Components/department/department-edit/department-edit.component';
import { DepartmentCreateComponent } from './Components/department/department-create/department-create.component';
//import { OtherPaymentListComponent } from './Components/other-payment/other-payment-list/other-payment-list.component';
//import { OtherPaymentEditComponent } from './Components/other-payment/other-payment-edit/other-payment-edit.component';
//import { OtherPaymentDetailsComponent } from './Components/other-payment/other-payment-details/other-payment-details.component';
//import { OtherPaymentCreateComponent } from './Components/other-payment/other-payment-create/other-payment-create.component';
import { PaymentDetailsPerStudentComponent } from './Components/payment-details/payment-details-per-student/payment-details-per-student.component';
import { StandardListComponent } from './Components/standard/standard-list/standard-list.component';
import { StandardEditComponent } from './Components/standard/standard-edit/standard-edit.component';
import { StandardCreateComponent } from './Components/standard/standard-create/standard-create.component';
import { ConfirmationDialogComponent } from './Components/confirmation-dialog/confirmation-dialog.component';
import { DepartmentListComponent } from './Components/department/department-list/department-list.component';
import { OtherpaymentListComponent } from './Components/other-payment/other-payment-list/other-payment-list.component';
import { OtherpaymentEditComponent } from './Components/other-payment/other-payment-edit/other-payment-edit.component';
import { OtherpaymentDetailsComponent } from './Components/other-payment/other-payment-details/other-payment-details.component';
import { OtherpaymentCreatComponent } from './Components/other-payment/other-payment-create/other-payment-create.component';
import { StaffEditComponent } from './Components/staff/staff-edit/staff-edit.component';
/*import { ToastModule, ToastrService } from '@syncfusion/ej2-angular-notifications';*/
/*import { ToastrModule, ToastrService } from 'ngx-toastr';*/
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StaffSalaryCreateComponent } from './Components/staff-salary/staff-salary-create/staff-salary-create.component';
import { StaffSalaryEditComponent } from './Components/staff-salary/staff-salary-edit/staff-salary-edit.component';
import { MarksnewEntryListComponent } from './Components/marks-new/marksnew-entry-list/marksnew-entry-list.component';
import { MarkEntryCreateComponent } from './Components/marks-new/marksnew-entry-create/marksnew-entry-create.component';
import { MarkEntryDetailsComponent } from './Components/marks-new/marksnew-entry-details/marksnew-entry-details.component';
import { MarksnewEntryDeleteComponent } from './Components/marks-new/marksnew-entry-delete/marksnew-entry-delete.component';
/*import { MarksnewEntryDetailsComponent } from './Components/marks-new/marksnew-entry-details/marksnew-entry-details.component';*/
/*import { MarksnewEntryCreateComponent } from './Components/marks-new/marksnew-entry-create/marksnew-entry-create.component';*/
/*import { StaffSalaryEditComponent } from './Components/staff/staff-salary/staff-salary-edit/staff-salary-edit.component';*/


import { MatTableModule } from '@angular/material/table';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { HeaderComponent } from './Layout/header/header.component';
import { SidebarComponent } from './Layout/sidebar/sidebar.component';
import { DashboardComponent } from './Components/dashboard/dashboard-grid/dashboard-grid.component';
import { MainComponent } from './Components/main/main.component';
import { ExamScheduleStandardsListComponent } from './Components/ExamScheduleStandards/exam-schedule-standards-list/exam-schedule-standards-list.component';
import { ExamScheduleStandardsEditComponent } from './Components/ExamScheduleStandards/exam-schedule-standards-edit/exam-schedule-standards-edit.component';
import { ExamScheduleStandardsCreateComponent } from './Components/ExamScheduleStandards/exam-schedule-standards-create/exam-schedule-standards-create.component';
import { ExamscheduleListComponent } from './Components/examschedule/examschedule-list/examschedule-list.component';
import { ExamscheduleEditComponent } from './Components/examschedule/examschedule-edit/examschedule-edit.component';
import { ExamscheduleAddComponent } from './Components/examschedule/examschedule-add/examschedule-add.component';
/*import { StudentListComponent } from './Components/student/student-list/student-list.component';*/
import { StudentEditComponent } from './Components/student/student-edit/student-edit.component';
import { StudentDetailsComponent } from './Components/student/student-details/student-details.component';
import { StudentAddComponent } from './Components/student/student-add/student-add.component';
import { SubjectListComponent } from './Components/subject/subject-list/subject-list.component';
import { SubjectEditComponent } from './Components/subject/subject-edit/subject-edit.component';
import { SubjectAddComponent } from './Components/subject/subject-add/subject-add.component';
import { ListStudentComponent } from './Components/student/student-list/student-list.component';
import { HomepageComponent } from './Components/homepage/homepage.component';







@NgModule({
  declarations: [
    AppComponent,
    MarksListComponent, MarksAddComponent, MarksEditComponent, MarksDeleteComponent, AttendanceListComponent, AttendanceAddComponent, FeeListComponent, FeeEditComponent, FeeCreateComponent, FeetypeListComponent, FeetypeEditComponent, FeetypeCreateComponent, MonthlypaymentListComponent, MonthlypaymentEditComponent, MonthlypaymentDetailsComponent, MonthlypaymentCreatComponent, StaffListComponent, DepartmentListComponent, StaffSalaryListComponent, StaffCreateComponent, StaffEditComponent, ExamtypeListComponent, ExamtypeAddComponent, ExamtypeEditComponent, StaffDetailsComponent, StaffDeleteComponent, DepartmentEditComponent, DepartmentCreateComponent, OtherpaymentListComponent, OtherpaymentEditComponent, OtherpaymentDetailsComponent, OtherpaymentCreatComponent, PaymentDetailsPerStudentComponent, StandardListComponent, StandardEditComponent, StandardCreateComponent, ConfirmationDialogComponent, StaffSalaryCreateComponent, StaffSalaryEditComponent, MarksnewEntryListComponent, MarkEntryCreateComponent, MarkEntryDetailsComponent, MarksnewEntryDeleteComponent, HeaderComponent, SidebarComponent, DashboardComponent, MainComponent, ExamScheduleStandardsListComponent, ExamScheduleStandardsEditComponent, ExamScheduleStandardsCreateComponent, ExamscheduleListComponent, ExamscheduleEditComponent, ExamscheduleAddComponent, ListStudentComponent, StudentEditComponent, StudentDetailsComponent, StudentAddComponent, SubjectListComponent, SubjectEditComponent, SubjectAddComponent, HomepageComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    GridModule, PagerModule, ChartModule, TextBoxModule, UploaderModule,
    BrowserAnimationsModule, MatSidenavModule,
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    MatDividerModule,
    MatListModule,
    MatButtonModule,
    MatCardModule,
    MatTableModule


        
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
