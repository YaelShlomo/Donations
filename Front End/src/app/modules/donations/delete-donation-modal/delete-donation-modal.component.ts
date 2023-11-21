import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

export interface DialogData {
  animal: string;
  name: string;
}

@Component({
  selector: 'app-delete-donation-modal',
  templateUrl: './delete-donation-modal.component.html',
  styleUrls: ['./delete-donation-modal.component.css']
})
export class DeleteDonationModalComponent {

  constructor(public dialogRef: MatDialogRef<DeleteDonationModalComponent>) {}

}

