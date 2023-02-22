using MySqlConnector;
using WebApi.BML;
using Dapper;
namespace WebApi.DAL;

public class AUser
{
    private string mConnexion;
    public AUser(string mConnexion)
    {
        this.mConnexion = mConnexion;
    }

    public ReturnMessage GetUserUsingId(string userID)
    {
        ReturnMessage message = new ReturnMessage();
        using (MySqlConnection connection = new MySqlConnection(mConnexion))
        {
            try
            {
                MUser user = connection
                    .Query<MUser>("SELECT * from user where guid = USERGUID", new { USERGUID = userID })
                    .First();
                message.ReturnObject = user;
                message.Code = ReturnCode.OK;
            }
            catch (Exception e)
            {
                message.Message = "Erreur lors de la recuperation des données" + e.Message;
                message.Code = ReturnCode.FAILED;
            } 
           
        }

        return message;
    }
    public ReturnMessage Create(MUser mUser)
    {
        ReturnMessage message = new ReturnMessage();
        using (MySqlConnection connection = new MySqlConnection(mConnexion))
        {
            try
            {

                connection.Open();
                string query = "INSERT INTO user (name , email , id ) values (@name , @email , @id)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add("@name", MySqlDbType.String);
                command.Parameters["@name"].Value = mUser.name;
                command.Parameters.Add("@email", MySqlDbType.String);
                command.Parameters["@email"].Value = mUser.email;
                command.Parameters.Add("@id", MySqlDbType.String);
                command.Parameters["@id"].Value = (string.IsNullOrEmpty(mUser.ID)) ? new Guid() : mUser.ID;
                command.ExecuteNonQuery();
                message.Message = "Traitement effectué avec succes";
                message.Code = ReturnCode.OK;
                connection.Close();


            }
            catch (Exception e)
            {
                message.Message = "Erreur dans le fonction " + e.Message;
                message.Code = ReturnCode.FAILED;
            }
        }
        return message;
    }
}