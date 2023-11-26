import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Currency } from "./models/currency";
import { Donation } from "./models/donation";
import { PoliticalEntity } from "./models/political-entity";


@Injectable()
export class DonationService {

    getDonationsFromServer(): Observable<Donation[]> {
          return this._http.get<Donation[]>("/api/Donations");
    }

    getDonationsFromServerByDone(done: boolean) {
        return this._http.get<Donation[]>("/api/Donations/?done=" + done);
    }

    getDonationsFromServerByMyId(id: Number) {
        return this._http.get<Donation[]>("/api/Donations/?id=" + id);
    }

    getPoliticalEntitiesFromServer(): Observable<PoliticalEntity[]> {
        return this._http.get<PoliticalEntity[]>("/api/PoliticalEntity");
  }

  getCurrenciesFromServer(): Observable<Currency[]> {
    return this._http.get<Currency[]>("/api/Currency");
}

    saveDonation(conationToSave: Donation): Observable<boolean> {
        return this._http.post<boolean>("/api/Donations", conationToSave); 
    }
    updateDonation(conationToSave: Donation): Observable<boolean> {
        return this._http.put<boolean>("/api/Donations/"+conationToSave.id, conationToSave); 
    }

    deleteDonationsFromServer(id: Number): Observable<boolean> {
        return this._http.delete<boolean>("/api/Donations/"+id);
    }

    // sendEmail(email: EmailModel) :Observable<boolean> {
    //     console.log("sendEmail")
    //     return this._http.post<boolean>('/api/Donations/send', email);
    //   }

    constructor(private _http:HttpClient) {
    }
}

