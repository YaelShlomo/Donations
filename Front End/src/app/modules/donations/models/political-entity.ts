// export const PoliticalEntity: { [key: string]: Object }[] = [
//     {  id: 'country', name:"מדינה זרה" },
//     {  id: 'embassy', name:"שגרירות של מדינה זרה" },
//     {  id: 'governmentalAuthority', name:"רשות שלטונית או מקומית של מדינה זרה" },
//     {  id: 'corporation', name:"תאגיד או מוסד בשליטת מדינה זרה" },
//     {  id: 'organiztion', name:"הרשות הפלסטינית או תאגיד שנשלט על ידה" },
// ];

// export enum PoliticalEntity { 
//     'country' = "מדינה זרה" ,
//     'embassy' = "שגרירות של מדינה זרה" ,
//     'governmentalAuthority' = "רשות שלטונית או מקומית של מדינה זרה" ,
//     'corporation' = "תאגיד או מוסד בשליטת מדינה זרה" ,
//     'organization' = "הרשות הפלסטינית או תאגיד שנשלט על ידה" 
// }


export class PoliticalEntity {
    entityId: Number;
    name: string;
    description: string;

    constructor() {
        // this.entityId = 0;
    }
}