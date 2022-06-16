import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArrialComponent } from './arrial/arrial.component';
import { CheckinComponent } from './checkin/checkin.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CancelComponent } from './cancel/cancel.component';
import { AllbookingComponent } from './allbooking/allbooking.component';
import { BookingRoutingModule } from './booking-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http'
import { AgGridModule } from 'ag-grid-angular';



@NgModule({
  declarations: [
    ArrialComponent,
    CheckinComponent,
    CheckoutComponent,
    CancelComponent,
    AllbookingComponent,
  ],
  imports: [
    CommonModule,
    BookingRoutingModule,
    BrowserModule,
    HttpClientModule,
    AgGridModule

  ],
  providers: [],
  bootstrap: [AllbookingComponent]
})
export class BookingModule { }
