namespace CodingChallenge;

public class ShoppingBasket
{
    public IList<Product> Items { get; private set; } = new List<Product>();

    public void Scan(Product product)
        => this.Items.Add(product);

    public void Scan(string productID, IList<Product> inventory)
        => this.Scan(inventory.Single(p => p.ID==productID));

    public decimal GetTotalPrice(params Func<IEnumerable<Product>, IEnumerable<Product>>[] priceAdjustments)
    {
        IList<Product> products = this.Items;
        foreach (Func<IEnumerable<Product>, IEnumerable<Product>>? adjustment in priceAdjustments)
            products = adjustment(products).ToList();

        return products.Sum(p => p.Price);
    }
}