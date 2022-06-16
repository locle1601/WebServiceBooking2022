import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllbookingComponent } from './allbooking/allbooking.component';
import { ArrialComponent } from './arrial/arrial.component';
import { CancelComponent } from './cancel/cancel.component';
import { CheckinComponent } from './checkin/checkin.component';
import { CheckoutComponent } from './checkout/checkout.component';

const routes: Routes = [
  {
    path: '',
    component: AllbookingComponent
  },
  {
    path: 'all',
    component: AllbookingComponent
  },
  {
    path: 'arr',
    component: ArrialComponent
  },
  {
    path: 'ci',
    component: CheckinComponent
  },
  {
    path: 'co',
    component: CheckoutComponent
  },
  {
    path: 'cc',
    component: CancelComponent
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookingRoutingModule { }
