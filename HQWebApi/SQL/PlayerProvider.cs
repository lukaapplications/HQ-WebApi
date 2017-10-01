using HQWebApi.Helpers;
using HQWebApi.Models;
namespace HQWebApi.SQL
{
    public class PlayerProvider
    {
        public static Player GetPlayer(long id)
        {
            var sql = new SQLHelper();
            sql.SqlCommand.CommandText = "SELECT * FROM Player WHERE Id = @Id;";
            sql.SqlCommand.Parameters.AddWithValue("@Id", id);
            var data = sql.GetDataSet();

            if (data.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            var row = data.Tables[0].Rows[0];

            return new Player(row);
        }

        public static Player CreatePlayer(string name)
        {
            var sql = new SQLHelper();
            sql.SqlCommand.CommandText = "INSERT INTO Player (Name) OUTPUT Inserted.ID VALUES(@Name)";
            sql.SqlCommand.Parameters.AddWithValue("@Name", name);
            var id = ValidationHelper.GetLong(sql.ExecuteScalar());

            return GetPlayer(id);
        }

        public static Player UpdatePlayer(Player player)
        {
            var sql = new SQLHelper();
            sql.SqlCommand.CommandText = "UPDATE Player SET Name=@Name, Intelligence=@Intelligence, Strength=@Strength, Charisma=@Charisma, Good=@Good, Evil=@Evil WHERE Id=@Id";
            sql.SqlCommand.Parameters.AddWithValue("@Name", player.Name);
            sql.SqlCommand.Parameters.AddWithValue("@Intelligence", player.Intelligence);
            sql.SqlCommand.Parameters.AddWithValue("@Strength", player.Strength);
            sql.SqlCommand.Parameters.AddWithValue("@Charisma", player.Charisma);
            sql.SqlCommand.Parameters.AddWithValue("@Good", player.Good);
            sql.SqlCommand.Parameters.AddWithValue("@Evil", player.Evil);
            sql.SqlCommand.Parameters.AddWithValue("@Id", player.Id);

            sql.ExecuteScalar();

            return GetPlayer(player.Id);
        }
    }
}