import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatExpansionPanel } from '@angular/material/expansion';
import { ActivatedRoute } from '@angular/router';
import { DonationService } from '../donation.service';
import { DeleteDonationModalComponent } from '../delete-donation-modal/delete-donation-modal.component';
import { Currency } from '../models/currency';
import { Donation } from '../models/donation';
import { PoliticalEntity } from '../models/political-entity';

@Component({
  selector: 'app-donation-list',
  templateUrl: './donation-list.component.html',
  styleUrls: ['./donation-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class DonationListComponent implements OnInit {

  entity = PoliticalEntity;
  currency = Currency;
  donations: Donation[];
  selectedDonation1: Donation;
  selectedDonation2: Donation | null;
  isDisable: boolean;
  donationsCounter: number;

  deleteDonation(donation: Donation) {
    let indexToDelete = this.donations.indexOf(donation);
    this.donations.splice(indexToDelete, 1);
    let id = donation.id;
    console.log(id);
    this._donationsService.deleteDonationsFromServer(id).subscribe(data=>{
      console.log(data);
    });
  }

  showNewDonationDetails() {
    this.selectedDonation1 = new Donation();
  }

  addNewDonationToList(conationToAdd: Donation) {
    console.log("addNewDonationToList")
    this.donations.push(conationToAdd);
  }

  saveDonationToList(donationToSave: Donation) {
    console.log(JSON.stringify(donationToSave));
    let donationToSaveInCorrectFormat = new Donation();
    donationToSaveInCorrectFormat.id = donationToSave.id;
    donationToSaveInCorrectFormat.name = donationToSave.name;
    donationToSaveInCorrectFormat.amount = Number(donationToSave.amount);
    donationToSaveInCorrectFormat.entity = donationToSave.entity;
    donationToSave.entity = donationToSave.entity;
    donationToSaveInCorrectFormat.destination = donationToSave.destination;
    donationToSaveInCorrectFormat.condition = donationToSave.condition;
    donationToSaveInCorrectFormat.currency = donationToSave.currency;
    donationToSaveInCorrectFormat.exchangeRate = Number(donationToSave.exchangeRate);

    if (donationToSave.id == 0) {
      this.donationsCounter += 1;
      donationToSave.id = this.donationsCounter;
      donationToSaveInCorrectFormat.id = donationToSave.id;
      this.donations.push(donationToSave);
      this._donationsService.saveDonation(donationToSaveInCorrectFormat).subscribe(data=>{
      })
    }
    else {
      let conationToUpdate = this.donations.filter(x => x.id == donationToSave.id)[0];
      let index = this.donations.indexOf(conationToUpdate);
      this.donations[index] = donationToSave;
      this._donationsService.updateDonation(donationToSaveInCorrectFormat).subscribe(data=>{
      })
    }
    // let emailDetails = new EmailModel()
    // emailDetails.recipient = "yaelfrank100@gmail.com";
    // emailDetails.body = "Email Body";
    // emailDetails.subject = "A Contribution in excess of 10000 was received"
    // console.log(emailDetails)
    // this._donationsService.sendEmail(emailDetails).subscribe( data => {})
  }

  showDetails(donation: Donation) {
    this.selectedDonation2 = donation;
    this.isDisable = true;
  }

  editDetails(donation: Donation) {
    this.selectedDonation2 = donation;
    this.isDisable = false;
  }

  showDonationsByDone(done: boolean) {
    this._donationsService.getDonationsFromServerByDone(done).subscribe(data => {
      this.donations = data;
    })
  }

  constructor(private _donationsService: DonationService, private _acr: ActivatedRoute, public dialog: MatDialog) {
        _donationsService.getDonationsFromServer().subscribe(donationsList => {
          this.donations = donationsList;
          this.donationsCounter = this.donations.length;
    })
 }

  userId?: number;

  ngOnInit(): void {
  }

  openDialog(): void {
    this.dialog.open(DeleteDonationModalComponent, {
      width: '250px',
    });
  }

  expandPanel(matExpansionPanel: MatExpansionPanel, event: any) {
    event.stopPropagation();
    if (!this._isExpansionIndicator(event.target)) {
      matExpansionPanel.open();
    }
  }

  private _isExpansionIndicator(target: EventTarget | any): boolean {
    const expansionIndicatorClass = "mat-expansion-indicator";
    return (
      target.classList && target.classList.contains(expansionIndicatorClass)
    );
  }

  getKeyByValue(enumObj: any, value:any) {
    for (const key in enumObj) {
      if (enumObj[key] === value) {
        if (typeof enumObj[key] === "number") {
          return key;
        }
        else {
          return enumObj[key];
        }
      }
    }
    return null; // Value not found in the enum
  }

}

