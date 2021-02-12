import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {Routes, RouterModule} from '@angular/router';

import {EmployeeComponent} from './employee/employee.component';
import {DepartmentComponent} from './department/department.component';

const routes: Routes = [
  {path: 'employee', component:EmployeeComponent},
  {path: 'department', component:DepartmentComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),CommonModule
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
