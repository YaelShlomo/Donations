import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MaterialModule} from './material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import {FormsModule} from '@angular/forms';
import { DonationsModule } from './modules/donations/donation.module';
import { HttpClientModule } from '@angular/common/http';
import { DonationService } from './modules/donations/donation.service';

@NgModule({
  declarations: [
    AppComponent
      ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    FormsModule,
    DonationsModule,
    HttpClientModule
  ],
  providers: [DonationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
