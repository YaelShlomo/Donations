import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DonationDetailsFormComponent } from './donation-details-form/donation-details-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material.module';
import { DonationListComponent } from './donation-list/donation-list.component';
import { DonationService } from './donation.service';
import { DeleteDonationModalComponent } from './delete-donation-modal/delete-donation-modal.component';

@NgModule({
  declarations: [
    DonationDetailsFormComponent,
    DonationListComponent,
    DeleteDonationModalComponent
    ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialModule
  ],
  providers: [DonationService],
  exports: [
    DonationDetailsFormComponent,
    DonationListComponent
  ]
})
export class DonationsModule { }
