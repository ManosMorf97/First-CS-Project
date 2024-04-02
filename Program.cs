// See https://aka.ms/new-console-template for more information
using cd_products;
using class_product;
using device_products;
Product[,] products= new Product[4, 3];
string [] movie_name = ["Terminator", "Titanic", "Last of the Mochicans"];
string[][] movie_genres = [["action","horror","science fiction"], ["action","horror","romance"], ["action","history","war"]];
int[,] year = { {1984, 1997, 1992}, {2007, 2007, 2004},{ 2015, 2014, 2010 },{ 2006,2005,2000} };
string[] game_genres = ["fighting"];
string[] game_name = ["Tekken 6", "Tekken 6", "Tekken 5"];
string[] console_name = ["PS3", "XBOX-360", "PS2"];
float[,] price = { {5,4,5}, {15,15,10},{200,181,120},{350,350,(float)240.6 } };
float[] game_ratings = [(float)7.4, (float)7.4, (float)8.1];
float[] movie_ratings = [(float)8.1, (float)7.9, (float)7.7];
int[] length = [107, 195, 112];
string[] mobile_name = ["XPERIA Z4", "OnePlus 12", "XPERIA X10 Mini Pro"];
string[] mobile_constructor = ["Sony", "OnePlus", "Sony"];
float[] mobile_ram = [(float)3, (float)12, (float)8];
string[] mobile_graphics_card = ["Qualcomm Adreno","Adreno","Qualcomm"];
string[] console_constructor = ["Sony","Microsoft","Sony"];
float[] console_ram = [(float)0.25, (float)0.5, (float)0.03125];
string[] console_graphics_card = ["NVIDIA", "ATI", "Sony"];

for (int i = 0; i < 3; i++)
    products[0, i] = new Movie(movie_name[i], price[0, i], year[0,i], movie_genres[0], movie_ratings[i], length[0]);
for (int i = 0; i < 3; i++)
    products[1, i] = new Game(game_name[i], price[1, i], year[1, i], game_genres, game_ratings[i], console_name[i]);
for (int i = 0; i < 3; i++)
    products[2, i] = new Mobile_Phone(mobile_name[i], price[2, i], year[2, i], mobile_ram[i], 
        mobile_constructor[i], mobile_graphics_card[i]);
for (int i = 0; i < 3; i++)
    products[3, i] = new Gaming_Console(console_name[i], price[3, i], year[3, i], console_ram[i],
        console_constructor[i], console_graphics_card[i]);
StreamWriter product_file = new("products.txt");
try
{
    foreach (Product product in products)
    {
        product_file.WriteLine("Type: " + product.GetType());
        product_file.Write(product+"\n");
    }
    product_file.Close();
    Console.WriteLine("The products have been writen to file");
}
catch(Exception e)
{
    Console.WriteLine(e.ToString());
}
