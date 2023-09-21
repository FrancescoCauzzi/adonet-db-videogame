using static System.Console;
using adonet_db_videogame;
namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read 
            List<Videogame> videogames = VideogameManager.GetVideogames();

			WriteLine("Ecco la lista dei videogames:");

			foreach (Videogame videogame in videogames)
			{
				WriteLine($"- {videogame}");
			}

			WriteLine();
        }
    }
}