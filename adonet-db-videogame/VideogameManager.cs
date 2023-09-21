using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        private static string connectionString = "Data Source=localhost;Initial Catalog=db_videogame;Integrated Security=True";

        public static List<Videogame> GetVideogames()
		{

			List<Videogame> videogames = new List<Videogame>();

			using (SqlConnection connection = new SqlConnection(connectionString)) {

				try
				{
					connection.Open();

					string query = "SELECT videogames.id, videogames.name, videogames.overview, videogames.release_date, videogames.software_house_id FROM videogames;";

					using(SqlCommand cmd = new SqlCommand(query, connection))
					using(SqlDataReader data = cmd.ExecuteReader())
					{
						while (data.Read())
						{
							Videogame VideogameReaded = new Videogame(data.GetInt64(0), data.GetString(1), data.GetString(2), data.GetDateTime(3), data.GetInt64(4));
							videogames.Add(VideogameReaded);
						}
					}

				}catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
				}

				return videogames;
                // we do not need to close the connection, it will be closed automatically thanks to using statement (using-wiht-resources)
			
			}
		}
    }
}
