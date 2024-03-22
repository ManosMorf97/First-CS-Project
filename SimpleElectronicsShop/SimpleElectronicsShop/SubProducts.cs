using class_product;

namespace sub_products
{
	public class CDProduct(string title,float price,int year,string [] genres,float ratings_from_imdb):
		Product(year,price)
	{
		private readonly string [] genres = genres;
		private readonly float ratings_from_imdb = ratings_from_imdb;
		private readonly string title = title;

		public float Ratings_From_Imdb { 
			get { return ratings_from_imdb; } 
		}

		public string [] Genres {
			get { return genres; }
		}

		public String Title {
		get{ return title; } 
		}
		public override string ToString() {
			return "title: "+title+"\n"+"year: "+base.Year+"\n"
				+"ratings_from_imdb: "+ratings_from_imdb+"\n"+
				"genres: "+String.Join(",",genres)+"\n";
		}
	}

	public class DeviceProduct(string name, float price, int year, float ram, string constructor_type, string graphics_card) :
		Product(year, price)
	{
		private readonly string name=name;
		private readonly float ram = ram;
		private readonly string constructor_type=constructor_type;
		private readonly string graphics_card = graphics_card;

		public String Name
		{
			get { return name; }		
		}
		public float RAM
		{
			get { return ram; }	
		}
		public string Constructor_Type
		{
			get { return constructor_type; }
		}
		public string Graphics_Card
		{
			get { return graphics_card; }		
		}

		public override String ToString()
		{
            return "name: " + name + "\n" + "year: " + base.Year + "\n"+
                "RAM: " + ram + "\n" +
                "constructor_type: " + constructor_type + "\n"+
				"graphics_card: " +graphics_card+"\n";
        }



	
	}
}

