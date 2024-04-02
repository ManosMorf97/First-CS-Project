using sub_products;
using cd_products;
using class_product;
using device_products;
namespace buyer_
{
    public class Buyer
    {
        static void Main(string[] args)
        {
            List<Product> products = GetProducts("products.txt");
            List<Product> buyer_products = new List<Product>();
            string answer;
            Console.WriteLine("All products");
            foreach (Product product in products.OrderBy(p => p.Price).ToList())
                Console.WriteLine(product);
            do
            {
                Console.WriteLine("Anything that needs to add to chart yes or no?");
                answer = Console.ReadLine();
            } while (answer!=null && answer.ToLower() != "no" && answer.ToLower() != "yes");
            while (answer.ToLower() != "no") {
                Console.WriteLine("Product Type?");
                string type = Console.ReadLine();
                string name = "";
                string title = "";
                string console = "";
                if (type == "Gaming_Console" || type == "Mobile_Phone")
                {
                    Console.WriteLine("Name?");
                    name = Console.ReadLine();
                }
                else if (type == "Movie")
                {
                    Console.WriteLine("Title?");
                    title = Console.ReadLine();
                }
                else if (type == "Game") {
                    Console.WriteLine("Title?");
                    title = Console.ReadLine();
                    Console.WriteLine("Console?");
                    console = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("That type of product is not available there");
                    continue;
                }
                if (name != "")
                {
                    buyer_products.Add(products.Where(p =>p.GetType().Name == type && ((DeviceProduct)p).Name == name).ToList()[0]);
                }
                else {
                    if (console == "") {
                        buyer_products.Add(products.Where(p => p.GetType().Name == type && ((Movie)p).Title== title).ToList()[0]);

                    }
                    else
                    {

                        buyer_products.Add(products.Where(p => p.GetType().Name == type && ((Game)p).Title == title && 
                        ((Game)p).Console == console).ToList()[0]);

                    }
                
                }
                Console.WriteLine("All products");
                foreach (Product product in products.OrderBy(p => p.Price).ToList())
                    Console.WriteLine(product);
                do
                {
                    Console.WriteLine("Anything that needs to add to chart yes or no?");
                    answer = Console.ReadLine();
                } while (answer != null && answer.ToLower() != "no" && answer.ToLower() != "yes");
            }
            while (true)
            {
                if (buyer_products.Count == 0)
                    break;
                Console.WriteLine("Total Money:" + buyer_products.Sum(p => p.Price));
                buyer_products = buyer_products.OrderBy(p => p.Price).ToList();

                Console.WriteLine("Type the number of a product you want to remove.IF not type enter");
                for (int i = 0; i < buyer_products.Count; i++)
                    Console.WriteLine("Number: " + i + "\n" + buyer_products[i]);
                int selected_number;
                try
                {
                    selected_number = Convert.ToInt32(Console.ReadLine());
                    buyer_products.RemoveAt(selected_number);
                }
                catch (Exception)
                {
                    selected_number = -1;
                }
                if (selected_number == -1)
                    break;
            }


        }
        public static List<Product> GetProducts(string filename)
        {
            StreamReader product_file = new(filename);
            List<Product> products = new List<Product>();
            try
            {
                while (true)
                {
                    string type = product_file.ReadLine();
                    if (type == null)
                        break;
                    type = type.Substring(type.LastIndexOf('.') + 1);
                    Dictionary<string, string> attributes = new Dictionary<string, string>();
                    string line = product_file.ReadLine();
                    while (line != "")
                    {
                        attributes.Add(line.Substring(0, line.IndexOf(':')), line.Substring(line.IndexOf(": ") + 2));
                        line = product_file.ReadLine();
                    }
                    //create items to list
                    switch (type)
                    {
                        case "Mobile_Phone":
                            products.Add(new Mobile_Phone(attributes["name"],
                                float.Parse(attributes["price"]), int.Parse(attributes["year"]),
                                float.Parse(attributes["RAM"]), attributes["constructor_type"], attributes["graphics_card"]));
                            break;
                        case "Gaming_Console":
                            products.Add(new Gaming_Console(attributes["name"],
                                float.Parse(attributes["price"]), int.Parse(attributes["year"]),
                                float.Parse(attributes["RAM"]), attributes["constructor_type"], attributes["graphics_card"]));
                            break;
                        case "Movie":
                            products.Add(new Movie(attributes["title"],
                                float.Parse(attributes["price"]), int.Parse(attributes["year"]),
                                attributes["genres"].Split(","), float.Parse(attributes["ratings_from_imdb"]),
                                int.Parse(attributes["length"])));
                            break;
                        case "Game":
                            products.Add(new Game(attributes["title"],
                                float.Parse(attributes["price"]), int.Parse(attributes["year"]),
                                attributes["genres"].Split(","), float.Parse(attributes["ratings_from_imdb"]),
                                attributes["console"]));
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            product_file.Close();
            return products;
        }
    }
}
