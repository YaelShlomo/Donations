import { Component, EventEmitter, HostListener, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DonationService } from '../donation.service';
import { Currency } from '../models/currency';
import { Donation } from '../models/donation';
import { PoliticalEntity } from '../models/political-entity';

@Component({
  selector: 'app-donation-details-form',
  templateUrl: './donation-details-form.component.html',
  styleUrls: ['./donation-details-form.component.css']
})

export class DonationDetailsFormComponent implements OnInit {

  ngOnInit(): void {
    this.innerWidth = window.innerWidth;
  }

  public innerWidth: any;

  @HostListener('window:resize', ['$event'])
  onWindowResize() {
    this.innerWidth = window.innerWidth;
  }

  politicalEntities: PoliticalEntity[];

  private _isDisable: boolean;

  public get isDisable(): boolean {
    return this._isDisable;
  }

  @Input()
  public set isDisable(value: boolean) {
    this._isDisable = value;
    if (this._donation != undefined) {
      this.donationForm = new FormGroup({
        "id": new FormControl(this._donation.id),
        "name": new FormControl({ value: this._donation.name, disabled: this._isDisable }, [Validators.required, Validators.minLength(3), Validators.pattern(this.charRegex)]),
        "amount": new FormControl({ value: this._donation.amount, disabled: this._isDisable }, [Validators.required, Validators.pattern(this.numRegex)]),
        "entity": new FormControl({ value: this._donation.entity, disabled: this._isDisable }, Validators.required),
        "destination": new FormControl({ value: this._donation.destination, disabled: this._isDisable }, Validators.required),
        "condition": new FormControl({ value: this._donation.condition, disabled: this._isDisable }),
        "currency": new FormControl({ value: this.getKeyByValue(Currency, this._donation.currency), disabled: this._isDisable }, Validators.required),
        "exchangeRate": new FormControl({ value: this._donation.exchangeRate, disabled: this._isDisable }, Validators.required)
      });
    }
  }

  politicalEntity = PoliticalEntity;

  private _donation: Donation | null;

  donationForm: FormGroup;

  numRegex = /^-?\d*[.,]?\d{0,2}$/;

  charRegex = '^[a-zA-Z\u0590-\u05FF\u200f\u200e]+$';

  public get donation(): Donation | null {
    return this._donation!;
  }

  @Input()
  public set donation(value: Donation | null) {
    if (value != null) {
      this._donation = value;
      if (this._donation != undefined) {
        this.donationForm = new FormGroup({
          "id": new FormControl(this._donation.id),
          "name": new FormControl(this._donation.name, [Validators.required, Validators.minLength(3), Validators.pattern(this.charRegex)]),
          "amount": new FormControl(this._donation.amount, [Validators.required, Validators.pattern(this.numRegex)]),
          "entity": new FormControl(this._donation.entity, Validators.required),
          "destination": new FormControl(this._donation.destination, Validators.required),
          "condition": new FormControl(this._donation.condition),
          "currency": new FormControl(this.getKeyByValue(Currency, this._donation.currency), Validators.required),
          "exchangeRate": new FormControl(this._donation.exchangeRate, Validators.required)
        });
      }
    }    
  }

  getErrorMessage(field: string): string {
    if (this.donationForm.controls?.[field]?.errors?.['required']) {
      return 'זהו שדה חובה';
    }
    if (field == 'name' && this.donationForm.controls?.['name']?.errors?.['pattern']) {
      return "שדה זה מכיל תווים בעברית או אנגלית בלבד ";
    }
    if (field == 'name' && this.donationForm.controls?.['name']?.errors?.['minlength']) {
      return "שדה זה חייב להכל לפחות 3 תווים";
    }
    if (field == 'amount' && this.donationForm.controls?.['amount']?.errors?.['pattern']) {
      return "שדה זה מכיל ספרות בלבד ";
    }
    return '';
  }

  clearDonation() {
    if (this._donation)
    this.donationForm = new FormGroup({
      "id": new FormControl(this._donation.id),
      "name": new FormControl('', [Validators.required, Validators.minLength(3), Validators.pattern(this.charRegex)]),
      "amount": new FormControl('', [Validators.required, Validators.pattern(this.numRegex)]),
      "entity": new FormControl('', Validators.required),
      "destination": new FormControl('', Validators.required),
      "condition": new FormControl(''),
      "currency": new FormControl('', Validators.required),
      "exchangeRate": new FormControl('', Validators.required)
    });
  }

  @Output()
  onSaveDonation: EventEmitter<any> = new EventEmitter();

  saveNewDonation() {
    if (this.donationForm.valid) {
      console.log("this.donationForm.valid");
      this.donation = this.donationForm.value;
      this.onSaveDonation.emit(this._donation);
      this._donation = null
    } 
  }

  clearNewDonation() {
    this._donation = null
  }

  @Output()
  onFirstFocus: EventEmitter<any> = new EventEmitter();

  fistFocusEmited: boolean = false;

  inputFocus() {
    if (!this.fistFocusEmited) {
      this.fistFocusEmited = true
    }
    this.onFirstFocus.emit()
  }

  getKeyByValue(enumObj: any, value:any) {
    for (const key in enumObj) {
      if (enumObj[key] === value) {
        return key;
      }
    }
    return null; // Value not found in the enum
  }

  constructor(private _donationsService: DonationService) {
    _donationsService.getPoliticalEntitiesFromServer().subscribe(politicalEntitiesList => {
      this.politicalEntities = politicalEntitiesList;
    })
}

  // entities = Object.keys(PoliticalEntity).filter(key => isNaN(Number(key))==true);
  coins = Object.keys(Currency).filter(key => isNaN(Number(key))==true);
}
