import { Currency } from "./currency";
import { PoliticalEntity } from "./political-entity";

export class Donation {
    // id: String;
    id: Number;
    name: string;
    amount: Number;
    entity: PoliticalEntity;
    destination: string;
    condition?: string;
    currency: Currency;
    exchangeRate: Number;
    
    constructor() {
        this.id = 0;
    }
}

