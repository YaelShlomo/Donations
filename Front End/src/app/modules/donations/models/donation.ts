import { Currency } from "./currency";
import { PoliticalEntity } from "./political-entity";

export class Donation {
    // id: String;
    id: Number;
    name: string;
    amount: Number;
    entityId: Number;
    destination: string;
    condition?: string;
    currencyId: Number;
    exchangeRate: Number;
    
    constructor() {
        this.id = 0;
    }
}

