using sub_products;

namespace cd_products
{
    public class Movie(string title, float price, int year, string[] genres, float ratings_from_imdb, int length) :
            CDProduct(title, price, year, genres, ratings_from_imdb)
    {

        private readonly int length = length;

        public int Length_ { get { return length; } }

        public override string ToString() {
            return base.ToString() + "length: " + length + "\n";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Movie movie) return false;
            return Title==movie.Title&&length==movie.Length_;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }

    public class Game(string title,float price,int year,string[] genres,float ratings_from_imdb,string console):
        CDProduct(title, price, year, genres, ratings_from_imdb)
    { 
        private readonly string console = console;
    
        public string Console { get { return console; } }

        public override string ToString() {
            return base.ToString()+"\n"+"console: "+console+"\n";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Game game) return false;
            return Title == game.Title && console == game.Console;

        }
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
