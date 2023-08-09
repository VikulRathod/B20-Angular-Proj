import { CART_ID } from "../app.constant";
import { environment } from "../environments/environment";
import { CartItem } from "./cartItem";

function GenerateGUID(): string {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }

export class Cart{
    id: string;
    items: CartItem[];
    total: number;
    tax: number;
    taxRate: number;
    grandTotal: number;
    userId: number;
    createdDate?: string;
    constructor(){
        this.id = this.getCartId();
        this.userId = 0;
        this.items = [];
        this.total = 0;
        this.tax = 0;
        this.grandTotal = 0;
        this.taxRate = environment.tax.taxRate;
    }
    getCartId() {
        let cid = localStorage.getItem(CART_ID);
        if (cid == undefined) {
            let id = GenerateGUID();
            localStorage.setItem(CART_ID, id);
            return id;
        }
        else {
            return cid;
        }
    }
}