export interface Catalog {
    id: number;
    name: string;
    summary: string;
    description: string;
    imageUrl: string;
    url: string;
    unitPrice: number;
    difficultyType: number;
    createdDate: Date;
    categoryId: number;
    mentorId: number;
}