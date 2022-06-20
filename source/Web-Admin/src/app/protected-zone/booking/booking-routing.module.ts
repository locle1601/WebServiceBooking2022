import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllbookingComponent } from './allbooking/allbooking.component';
import { ArrialComponent } from './arrial/arrial.component';

const routes: Routes = [
  {

    path: 'all',
    component: AllbookingComponent
  },
  {
    path: '',
    component: AllbookingComponent,
  },
  {
    path: 'arrival',
    component: ArrialComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookingRoutingModule { }
