<Query Kind="Program" />

void Main()
{
	//Refactor with factory
	var product = new SpecificProduct();
	var wrapperOne = new FirstWrapper();
	var wrapperTwo = new SecondWrapper();
	
	wrapperOne.SetProductConteined(product);
	wrapperTwo.SetProductConteined(wrapperOne);
	Console.WriteLine(wrapperTwo.GetPrice());
}

public abstract class Product
{
	public decimal Price { get; set; }
	public string Title { get; set; }
	public abstract decimal GetPrice();
}

public abstract class ProductWrapper : Product
{
	public abstract void SetProductConteined(Product product);
	public Product ProductConteined { get; set; }
}

public class SpecificProduct : Product
{
	public SpecificProduct()
	{
		Price = 2;
		Title = "Specific Product";
	}
	
	public override decimal GetPrice()
	{
		return this.Price;
	}
}
public class FirstWrapper : ProductWrapper
{
	public FirstWrapper()
	{
		Price = 6;
		Title = "First product wrapper";
	}
		
	public override void SetProductConteined(Product product)
	{
		this.ProductConteined = product;
	}
	
	public override decimal GetPrice()
	{
		return this.Price + ProductConteined.GetPrice();
	}
}
public class SecondWrapper : ProductWrapper
{
	public SecondWrapper()
	{
		Price = 3;
		Title = "Second product wrapper";
	}
	
	public override void SetProductConteined(Product product)
	{
		this.ProductConteined = product;
	}
	
	public override decimal GetPrice()
	{
		return this.Price + ProductConteined.GetPrice();
	}
}
