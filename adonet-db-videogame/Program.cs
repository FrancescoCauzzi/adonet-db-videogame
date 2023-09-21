using static System.Console;
using adonet_db_videogame;
using csharp_gestore_eventi;
using System.Numerics;
namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string welcomeMessage = @"Insert a command you wish to run:
            - 1: insert a new videogame 
            - 2: find a videogame by its id
            - 3: find a videogame by a string snippet matching its name
            - 4: delete a specific videogame by its id
            - 5: close the program";
            WriteLine("Welcome to our videogame manager console app!");
            Write(welcomeMessage);
            WriteLine();
            Write("Insert a command: ");
            int selectedOption = InputChecker.GetIntInput();
            WriteLine();
            while(selectedOption != 5)
            {
                switch (selectedOption)
                {
                    case 1:
                        WriteLine("Insert the data of a new videogame");
                        Write("Insert the name of the videogame: ");
				        string name = InputChecker.GetStringInput();
                        Write("Insert the overview of the videogame: ");
                        string overview = InputChecker.GetStringInput();
                        Write("Insert the release dateof the videogame: ");
                        DateTime releaseDate = InputChecker.GetDateTimeInput();
                        Write("Insert the software house id: ");
                        long softwareHouseId = (long)InputChecker.GetIntInput();
                        Videogame newVideogame = new Videogame(0, name, overview, releaseDate, softwareHouseId);
                        bool inserted = VideogameManager.InsertVideogame(newVideogame);
                        if (inserted)
                        {
                            WriteLine("The videogame has been inserted!");
                        }
                        else
                        {
                            WriteLine("The videogame could not be inserted");
                        }
                        break;
                    
                    case 2:
                        Write("Insert the id of the videogame you are looking for: ");
                        int videogameId = InputChecker.GetIntInput();
                        Videogame videogameFounded = VideogameManager.GetVideoGameById(videogameId);
                        if(videogameFounded != null)
                        {
                            WriteLine(videogameFounded);
                        }
                        break;
                    
                    case 3:
                        Write("Insert the name of the videogame you are looking for: ");
                        string videogameSnippet = InputChecker.GetStringInput();
                        List<Videogame> videogameList= VideogameManager.GetVideogamesByStringSnippet(videogameSnippet);
                        WriteLine();
                        if(videogameList.Count > 0)
                        {
                            WriteLine($"We have found {videogameList.Count} videogames with the snippet '{videogameSnippet}', they are: ");
                            foreach(Videogame videogame in videogameList)
                            {
                                WriteLine(videogame);
                            }
                        }else{
                            WriteLine("No videogames have been found");
                        
                        }                      
                        
                        break;
                    
                    case 4:
                        Write("Insert the id of the videogame you want to delete: ");
			            long idVideogameToDelete = (long)InputChecker.GetIntInput();
                        bool deleted = VideogameManager.DeleteVideogameById(idVideogameToDelete);

                        if (deleted)
                        {
                            WriteLine("The videogame has been deleted correctly");
                        }
                        else
                        {
                            WriteLine("The videogame could not be deleted");
                        }

                        break;                        
                    
                    default:
                        WriteLine("Invalid option");
                        break;
                    
                }
                WriteLine();
                WriteLine("What do you want to do now?");
                WriteLine(welcomeMessage);
                Write("Insert a command: ");
                selectedOption = InputChecker.GetIntInput();
                WriteLine();
            }

            // read 
            /*
            List<Videogame> videogames = VideogameManager.GetVideogames();

			WriteLine("Ecco la lista dei videogames:");

			foreach (Videogame videogame in videogames)
			{
				WriteLine($"- {videogame}");
			}

			WriteLine();
            */
        }
    }
}