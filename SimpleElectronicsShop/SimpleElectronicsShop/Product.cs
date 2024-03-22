namespace class_product
{
	public abstract class Product(int price, string name_title)
    {
		private readonly int price=price;
		private readonly string name_title=name_title;

		public int Price
		{
			get { return price; }
		}
		public string Name_Title
		{
			get { return name_title; }
		}
		public override string ToString()
		{

			return "name: " + name_title + "\n" + "price: " + price;
		}

	}
}
