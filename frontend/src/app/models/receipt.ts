export interface Receipt {
    paymentId: string;
    currency: string;
    email: string;
    status: string;
    grandTotal: number;
}