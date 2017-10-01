using HQWebApi.Helpers;
using HQWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;

namespace HQWebApi.Controllers
{
    public class PlayersController : ApiController
    {
        Player[] players = new Player[]
        {
            new Player
            {
                Id = 1,
                Name = "Player1",
                Charisma = 1,
                Intelligence = 10,
                Strength = 20,
                Evil = 3,
                Good = 4
            },
            new Player
            {
                Id = 2,
                Name = "Player2",
                Charisma = 10,
                Intelligence = 100,
                Strength = 200,
                Evil = 30,
                Good = 40
            }
        };

        public IEnumerable<Player> GetAllPlayers()
        {
            return players;
        }


        public IHttpActionResult GetPlayer(int id)
        {
            var sql = new SQLHelper();
            sql.SqlCommand.CommandText = "SELECT * FROM Player WHERE Id = @Id;";
            sql.SqlCommand.Parameters.AddWithValue("@Id", id);
            var data = sql.GetDataSet();

            var row = data.Tables[0].Rows[0];

            var player = new Player(row);

            // TODO
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPut]
        [Route("~/api/players/create")]
        public IHttpActionResult PutPlayer([FromBody] Player player)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HQConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand();
             
            try
            {
                con.Open();
                // Create a object of SqlCommand class
                com.Connection = con; //Pass the connection object to Command
                com.CommandText = "INSERT INTO Player(Name) VALUES (@name)"; //Stored Procedure Name

                com.Parameters.AddWithValue("@name", player.Name);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            
            return Ok(player);
        }
    }
}
