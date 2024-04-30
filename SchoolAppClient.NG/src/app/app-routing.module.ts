import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MarksListComponent } from './Components/marks/marks-list/marks-list.component';
import { MarksAddComponent } from './Components/marks/marks-add/marks-add.component';
import { MarksEditComponent } from './Components/marks/marks-edit/marks-edit.component';
import { MarksDeleteComponent } from './Components/marks/marks-delete/marks-delete.component';
import { AttendanceListComponent } from './Components/attendance/attendance-list/attendance-list.component';
import { AttendanceAddComponent } from './Components/attendance/attendance-add/attendance-add.component';
import { FeetypeListComponent } from './Components/feetype/feetype-list/feetype-list.component';
import { FeetypeEditComponent } from './Components/feetype/feetype-edit/feetype-edit.component';
import { FeetypeCreateComponent } from './Components/feetype/feetype-create/feetype-create.component';
import { FeeListComponent } from './Components/fee/fee-list/fee-list.component';
import { FeeCreateComponent } from './Components/fee/fee-create/fee-create.component';
import { FeeEditComponent } from './Components/fee/fee-edit/fee-edit.component';
import { MonthlypaymentListComponent } from './Components/monthlypayment/monthlypayment-list/monthlypayment-list.component';
import { MonthlypaymentEditComponent } from './Components/monthlypayment/monthlypayment-edit/monthlypayment-edit.component';
import { MonthlypaymentCreatComponent } from './Components/monthlypayment/monthlypayment-create/monthlypayment-create.component';
import { MonthlypaymentDetailsComponent } from './Components/monthlypayment/monthlypayment-details/monthlypayment-details.component';
import { StaffListComponent } from './Components/staff/staff-list/staff-list.component';
/*import { DepartementListComponent } from './Components/department/department-list/department-list.component';*/
import { StaffSalaryListComponent } from './Components/staff-salary/staff-salary-list/staff-salary-list.component';
import { LoginComponent } from './Authentication/SecurityComponents/login/login.component';
import { AuthGuard } from './Authentication/SecurityModels/auth.guard';
import { StaffCreateComponent } from './Components/staff/staff-create/staff-create.component';
import { ExamtypeListComponent } from './Components/examtype/examtype-list/examtype-list.component';
import { ExamtypeAddComponent } from './Components/examtype/examtype-add/examtype-add.component';
import { ExamtypeEditComponent } from './Components/examtype/examtype-edit/examtype-edit.component';
import { StaffEditComponent } from './Components/staff/staff-edit/staff-edit.component';
import { StaffDetailsComponent } from './Components/staff/staff-details/staff-details.component';
import { StaffDeleteComponent } from './Components/staff/staff-delete/staff-delete.component';
import { DepartmentListComponent } from './Components/department/department-list/department-list.component';
import { OtherpaymentListComponent } from './Components/other-payment/other-payment-list/other-payment-list.component';
import { OtherpaymentCreatComponent } from './Components/other-payment/other-payment-create/other-payment-create.component';
import { OtherpaymentEditComponent } from './Components/other-payment/other-payment-edit/other-payment-edit.component';
import { OtherpaymentDetailsComponent } from './Components/other-payment/other-payment-details/other-payment-details.component';
import { DepartmentCreateComponent } from './Components/department/department-create/department-create.component';
import { DepartmentEditComponent } from './Components/department/department-edit/department-edit.component';
import { StandardListComponent } from './Components/standard/standard-list/standard-list.component';
import { StandardCreateComponent } from './Components/standard/standard-create/standard-create.component';
import { StandardEditComponent } from './Components/standard/standard-edit/standard-edit.component';
import { PaymentDetailsPerStudentComponent } from './Components/payment-details/payment-details-per-student/payment-details-per-student.component';
import { StaffSalaryCreateComponent } from './Components/staff-salary/staff-salary-create/staff-salary-create.component';
import { StaffSalaryEditComponent } from './Components/staff-salary/staff-salary-edit/staff-salary-edit.component';
import { MarksnewEntryListComponent } from './Components/marks-new/marksnew-entry-list/marksnew-entry-list.component';
import { MarkEntryCreateComponent } from './Components/marks-new/marksnew-entry-create/marksnew-entry-create.component';
import { MarkEntryDetailsComponent } from './Components/marks-new/marksnew-entry-details/marksnew-entry-details.component';
import { MarksnewEntryDeleteComponent } from './Components/marks-new/marksnew-entry-delete/marksnew-entry-delete.component';


const routes: Routes = [
  /*{ path: "", redirectTo: "/marksList", pathMatch: "full" },*/

  { path: "", redirectTo: "/marksentrynewList", pathMatch: "full" },

  { path: "login", component: LoginComponent },

  /*{ path: "", redirectTo: "/attendanceList", pathMatch: "full" },*/

  { path: "marksentrynewList", component: MarksnewEntryListComponent },
  { path: 'markNew-entry-create', component: MarkEntryCreateComponent },
  { path: 'markNew-entry-details/:id', component: MarkEntryDetailsComponent },
  {
    path: 'markNew-entry-delete/:id', component:
      MarksnewEntryDeleteComponent
  },



  { path: "marksList", component: MarksListComponent },
  { path: 'marks/add', component: MarksAddComponent },
  { path: 'marks/edit/:id', component: MarksEditComponent },
  { path: "marks/delete/:id", component: MarksDeleteComponent },

  { path: "attendanceList", component: AttendanceListComponent },
  { path: "attendance/add", component: AttendanceAddComponent },

  { path: 'departments', component: DepartmentListComponent },
  { path: 'departments/create', component: DepartmentCreateComponent },
  { path: 'departments/:id/edit', component: DepartmentEditComponent },

  //{ path: 'fee-types', component: FeetypeListComponent },
  //{ path: 'fee-types/create', component: FeetypeCreateComponent },
  //{ path: 'fee-types/:id/edit', component: FeetypeEditComponent },

  { path: 'fee-types', component: FeetypeListComponent },
  { path: 'fee-types/create', component: FeetypeCreateComponent },
  { path: 'fee-types/:id/edit', component: FeetypeEditComponent },

  //{ path: 'fees', component: FeeListComponent },
  //{ path: 'fees/create', component: FeeCreateComponent },
  //{ path: 'fees/:id/edit', component: FeeEditComponent },

  { path: 'fees', component: FeeListComponent },
  { path: 'fees/create', component: FeeCreateComponent },
  { path: 'fees/:id/edit', component: FeeEditComponent },

  //{ path: 'monthlypayment', component: MonthlypaymentListComponent, canActivate: [AuthGuard] },
  //{ path: 'monthlypayment/create', component: MonthlypaymentCreatComponent },
  //{ path: 'monthlypayment/:id/edit', component: MonthlypaymentEditComponent },
  //{ path: 'monthlypayment/:id/details', component: MonthlypaymentDetailsComponent },

  { path: 'monthlypayment', component: MonthlypaymentListComponent },
  { path: 'monthlypayment/create', component: MonthlypaymentCreatComponent },
  { path: 'monthlypayment/:id/edit', component: MonthlypaymentEditComponent },
  { path: 'monthlypayment/:id/details', component: MonthlypaymentDetailsComponent },

  { path: 'otherpayment', component: OtherpaymentListComponent },
  { path: 'otherpayment/create', component: OtherpaymentCreatComponent },
  { path: 'otherpayment/:id/edit', component: OtherpaymentEditComponent },
  { path: 'otherpayment/:id/details', component: OtherpaymentDetailsComponent },

  { path: 'staff-list', component: StaffListComponent },
  { path: 'staff-create', component: StaffCreateComponent },
  { path: 'staff-edit/:id', component: StaffEditComponent },
  { path: 'staff-details/:id', component: StaffDetailsComponent },
  { path: 'staff-delete/:id', component: StaffDeleteComponent },

  { path: 'departments', component: DepartmentListComponent },

  { path: 'staff-salaries', component: StaffSalaryListComponent },
  { path: 'staff-salaries-create', component: StaffSalaryCreateComponent },
  { path: 'staff-salaries-edit/:id', component: StaffSalaryEditComponent },
  

  { path: 'exam-types', component: ExamtypeListComponent, canActivate: [AuthGuard] },
  { path: 'examType/create', component: ExamtypeAddComponent, canActivate: [AuthGuard] },
  { path: "examType/edit/:id", component: ExamtypeEditComponent, canActivate: [AuthGuard] },

  
  { path: 'standards', component: StandardListComponent },
  { path: 'standard/create', component: StandardCreateComponent },
  { path: 'standard/:id/edit', component: StandardEditComponent },

  { path: 'pmaymentdetails', component: PaymentDetailsPerStudentComponent },

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
