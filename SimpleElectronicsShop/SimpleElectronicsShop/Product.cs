namespace class_product
{
	public abstract class Product(int year,float price)
    {
		private readonly float price=price;
		private readonly int year = year;

		public float Price
		{
			get { return price; }
		}
		public int Year {
			get { return year; }
		}
		public override string ToString()
		{

			return "year: " + year + "\n" + "price: " + price+"\n";
		}

	}
}
