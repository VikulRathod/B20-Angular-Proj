//object
export class Payment {
    paymentId?: string;
    signature?: string;
    orderId?: string;
    tax?: number;
    currency?: string;
    total?: number;
    email?: string;
    cartId?: string;
    items?: [];
    userId?: number;
    grandTotal?: number;
}