using System.Collections.Generic;
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
            float total_money = (float)0.0;
            string answer;
            do
            {
                Console.WriteLine("Anything that needs to add to chart yes or no?");
                answer = Console.ReadLine();
            } while (answer.ToLower() != "no" && answer.ToLower() != "yes");
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
                else if (type == "Game?") {
                    Console.WriteLine("Title");
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

                }
                else { 
                
                
                }

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
                        attributes.Add(line.Substring(0, line.IndexOf(':')), line.Substring(line.IndexOf(": ") + 1));
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
