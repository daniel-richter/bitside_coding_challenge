using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingChallenge.Tests;

[TestClass]
public class UnitTest1
{
    public IList<Product> Inventory => new List<Product>
    {
        new Product { ID = "A0001", Price = 12.99m },
        new Product { ID = "A0002", Price =  3.99m },
    };

    [TestMethod]
    public void DefaultBasketWithSum1()
    {
        ShoppingBasket basket = new ShoppingBasket();
        basket.Scan("A0001", this.Inventory);

        decimal total = basket.GetTotalPrice();
        Assert.AreEqual(12.99m, total);
    }

    [TestMethod]
    public void DefaultBasketWithSum3()
    {
        ShoppingBasket basket = new ShoppingBasket();
        basket.Scan("A0002", this.Inventory);
        basket.Scan("A0001", this.Inventory);
        basket.Scan("A0002", this.Inventory);

        decimal total = basket.GetTotalPrice();
        Assert.AreEqual(20.97m, total);
    }

    [TestMethod]
    public void BuyOneGetOneFree()
    {
        ShoppingBasket basket = new ShoppingBasket();
        basket.Scan("A0002", this.Inventory);
        basket.Scan("A0001", this.Inventory);
        basket.Scan("A0002", this.Inventory);

        decimal total = basket.GetTotalPrice(SalesDeal.BuyOneGetOneFreeAdjustment("A0002"));
        Assert.AreEqual(16.98m, total);
    }

    [TestMethod]
    public void TenPercentOff()
    {
        ShoppingBasket basket = new ShoppingBasket();
        basket.Scan("A0002", this.Inventory);
        basket.Scan("A0001", this.Inventory);
        basket.Scan("A0002", this.Inventory);

        decimal total = basket.GetTotalPrice(SalesDeal.TenPercentOffAdjustment("A0001"));
        Assert.AreEqual(19.671m, total); // TODO: Wann monetär runden (EP vs. GesamtP)
    }
}