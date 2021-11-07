<Query Kind="Program" />

void Main()
{
	var product = FactoryMethod.GetProductInstance(1);
	var wrapperOne = FactoryMethod.GetProductInstance(2);
	var wrapperTwo = FactoryMethod.GetProductInstance(3);
	//here we need to apply the factory method pattern in order to have a factory for products and anoher for productWrappers
	//refactor made in factory method
	wrapperOne.SetProductConteined(product);
	wrapperTwo.SetProductConteined(wrapperOne);
	Console.WriteLine(wrapperTwo.GetPrice());
}


public static class FactoryMethod
{
	public static Product GetProductInstance(int idProductType)
	{
		switch(idProductType)
		{
			case 1:
				return new SpecificProduct();
			case 2:
				return new FirstWrapper();
			case 3:
				return new SecondWrapper();
			default:
	            return new SpecificProduct();
		}
	}
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