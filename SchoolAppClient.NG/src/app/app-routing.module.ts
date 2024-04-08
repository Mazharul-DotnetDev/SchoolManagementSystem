import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MarksListComponent } from './Components/marks/marks-list/marks-list.component';
import { MarksAddComponent } from './Components/marks/marks-add/marks-add.component';
import { MarksEditComponent } from './Components/marks/marks-edit/marks-edit.component';
import { MarksDeleteComponent } from './Components/marks/marks-delete/marks-delete.component';

const routes: Routes = [
  { path: "", redirectTo: "/marksList", pathMatch: "full" },
  { path: "marksList", component: MarksListComponent },
  { path: 'marks/add', component: MarksAddComponent },
  { path: 'marks/edit/:id', component: MarksEditComponent },
  { path: "marks/delete/:id", component: MarksDeleteComponent }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
