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

  donations: Donation[];
  selectedDonation1: Donation;
  selectedDonation2: Donation | null;
  isDisable: boolean;
  donationsCounter: number;
  politicalEntities: PoliticalEntity[];
  currencies: Currency[];

  deleteDonation(donation: Donation) {
    let indexToDelete = this.donations.indexOf(donation);
    this.donations.splice(indexToDelete, 1);
    let id = donation.id;
    console.log(id);
    this._donationsService.deleteDonationsFromServer(id).subscribe(data => {
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
    donationToSaveInCorrectFormat.entityId = donationToSave.entityId;
    donationToSave.entityId = donationToSave.entityId;
    donationToSaveInCorrectFormat.destination = donationToSave.destination;
    donationToSaveInCorrectFormat.condition = donationToSave.condition;
    donationToSaveInCorrectFormat.currencyId = donationToSave.currencyId;
    donationToSaveInCorrectFormat.exchangeRate = Number(donationToSave.exchangeRate);
    console.log(JSON.stringify(donationToSaveInCorrectFormat));

    if (donationToSave.id == 0) {
      this.donationsCounter += 1;
      donationToSave.id = this.donationsCounter;
      donationToSaveInCorrectFormat.id = donationToSave.id;
      this.donations.push(donationToSave);
      this._donationsService.saveDonation(donationToSaveInCorrectFormat).subscribe(data => {
      })
    }
    else {
      let conationToUpdate = this.donations.filter(x => x.id == donationToSave.id)[0];
      let index = this.donations.indexOf(conationToUpdate);
      this.donations[index] = donationToSave;
      this._donationsService.updateDonation(donationToSaveInCorrectFormat).subscribe(data => {
      })
    }
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
    _donationsService.getPoliticalEntitiesFromServer().subscribe(politicalEntitiesList => {
      this.politicalEntities = politicalEntitiesList;
    })
    _donationsService.getCurrenciesFromServer().subscribe(currenciesList => {
      this.currencies = currenciesList;
    })
  }

  getCurrencySymbolById(currencyId: Number): string {
    if (this.currencies !== undefined) {
      const foundCurrency = this.currencies.find(c => c.currencyId === currencyId);
      return foundCurrency ? foundCurrency.symbol : '';
    }
    return '';
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

}

