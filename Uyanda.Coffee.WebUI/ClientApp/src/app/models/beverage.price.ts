export interface IBeveragePrice {
    id: number,
    beverageId: number,
    beverageSizeId: number,
    beverage: {
        id: number,
        beverageTypeId: number,
        isActive: boolean,
        name: string,
        beverageType: string
    },
    cost: number,
    beverageSize: string
}