import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArrialComponent } from './arrial/arrial.component';
import { CheckinComponent } from './checkin/checkin.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CancelComponent } from './cancel/cancel.component';
import { AllbookingComponent } from './allbooking/allbooking.component';



@NgModule({
  declarations: [
    ArrialComponent,
    CheckinComponent,
    CheckoutComponent,
    CancelComponent,
    AllbookingComponent

  ],
  imports: [
    CommonModule
  ]
})
export class BookingModule { }
