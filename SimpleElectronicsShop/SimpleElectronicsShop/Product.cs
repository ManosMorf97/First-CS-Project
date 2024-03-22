using System;

public class Product
{
	private int price;
	private string name_title;
	public Product(int price, string name_title)
	{
		this.price = price;
		this.name_title = name_title;
	}
	
	public int Price{
		get { return price; }
	}
	public string Name_Title {
		get { return name_title; }
	}

	public override string ToString()
	{
     
		return "name: " + name_title + " price: " + price;
	}
}
