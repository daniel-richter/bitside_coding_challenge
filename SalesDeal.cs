namespace CodingChallenge;

public static class SalesDeal
{
    public static Func<IEnumerable<Product>, IEnumerable<Product>> TenPercentOffAdjustment(string productID)
        => products => products
            .Select(p => new Product
            {
                ID = p.ID,
                Price = (p.ID==productID) ? p.Price * 0.9m : p.Price
            });

    public static Func<IEnumerable<Product>, IEnumerable<Product>> BuyOneGetOneFreeAdjustment(string productID)
        => products => products
            .GroupBy(p => p.ID).SelectMany(g => g.Select((p, idx) => new Product
            {
                ID = p.ID,
                Price = (p.ID==productID) ? (((idx % 2)==0) ? p.Price : 0) : p.Price,
            }));
}