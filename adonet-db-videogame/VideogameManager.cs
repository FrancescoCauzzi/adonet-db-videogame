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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                    string query = "SELECT videogames.id, videogames.name, videogames.overview, videogames.release_date, videogames.software_house_id FROM videogames;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        while (data.Read())
                        {
                            Videogame VideogameReaded = new Videogame(data.GetInt64(0), data.GetString(1), data.GetString(2), data.GetDateTime(3), data.GetInt64(4));
                            videogames.Add(VideogameReaded);
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                    Console.WriteLine("An error occurred: " + ex.Message);
                }

                return videogames;
                // we do not need to close the connection, it will be closed automatically thanks to using statement (using-with-resources)
            }
        }

        public static bool InsertVideogame(Videogame videogame)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@name, @overview, @release_date, @software_house_id);";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@name", videogame.Name));
                    cmd.Parameters.Add(new SqlParameter("@overview", videogame.Overview));
                    cmd.Parameters.Add(new SqlParameter("@release_date", videogame.ReleaseDate));
                    cmd.Parameters.Add(new("@software_house_id", videogame.SoftwareHouseId));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                return false;
            }
        }

        public static Videogame GetVideoGameById(long id)
        {
            const string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE id = @id;";
            try
            {
                // here we open the connection by using the using statement that will close it automatically
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                // here we create a new command and set its properties
                using SqlCommand cmd = new SqlCommand(query, connection);
                // the parameters of the command are set using the AddParameter method
                cmd.Parameters.Add(new SqlParameter("@id", id));
                // here we execute the command and get the number of rows affected
                using SqlDataReader data = cmd.ExecuteReader();
                // here we check if the data is not empty and if it is we read it
                if (data.Read())
                {
                    Videogame videogameFounded = new Videogame(
                        data.GetInt64(0),
                        data.GetString(1),
                        data.GetString(2),
                        data.GetDateTime(3),
                        data.GetInt64(4)
                    );
                    return videogameFounded;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // Optionally, re-throw the exception or log it to a file
            }

            // if we reach this point, it means that the data was not found and we throw an exception            
            throw new Exception("No record was found");
        }

        public static List<Videogame> GetVideogamesByStringSnippet(string snippet)
        {
            List<Videogame> videogames = new List<Videogame>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT videogames.id, videogames.name, videogames.overview, videogames.release_date, videogames.software_house_id FROM videogames WHERE videogames.name LIKE '%' + @snippet + '%';";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@snippet", snippet));

                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        while (data.Read())
                        {
                            Videogame VideogameReaded = new Videogame(data.GetInt64(0), data.GetString(1), data.GetString(2), data.GetDateTime(3), data.GetInt64(4));
                            videogames.Add(VideogameReaded);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                return videogames;
            }
        }

        public static bool DeleteVideogameById(long idToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM videogames WHERE id=@Id";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Id", idToDelete));


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                    Console.WriteLine("An error occurred: " + ex.Message);

                }

                return false;
            }
        }
    }
}
