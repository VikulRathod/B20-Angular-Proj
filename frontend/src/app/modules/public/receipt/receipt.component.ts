import { Component, OnInit } from '@angular/core';
import { RECEIPT_ID } from 'src/app/app.constant';
import { Receipt } from 'src/app/models/receipt';

@Component({
  selector: 'app-receipt',
  templateUrl: './receipt.component.html',
  styles: [
  ]
})
export class ReceiptComponent implements OnInit {
  receipt: Receipt | any;
  ngOnInit(): void {
    const strData = localStorage.getItem(RECEIPT_ID);
    if (strData != undefined) {
      this.receipt = JSON.parse(strData);
    }
  }
}
