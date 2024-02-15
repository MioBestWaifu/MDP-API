namespace MDP.Handlers.Review
{
    using MDP.Models;
    using MDP.Data;
    using MySql.Data.MySqlClient;
    using System.Threading.Tasks;
    using MDP.Handlers.User;

    /// <summary>
    /// Busca, cria e retorna uma única review baseada no Id dela.
    /// </summary>
    public class ReviewRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Review>
    { 
        //Inicia 1 connection
        /// <summary>
        /// Cria uma review com user, chamando o UserRequestHandler para buscar o usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Review> HandleRequest(int id)
        {
            Task<MySqlDataReader> reviewTask = connector.ExecuteQuery(StatementPreparer.GetReviewById(id));
            MySqlDataReader reviewReader = await reviewTask;
            reviewReader.Read();
            Review toReturn = Review.FromQuery(reviewReader);
            try { 
                Task<User> userTask = new SimpleUserRequestHandler(connector).HandleRequest(reviewReader.GetInt32("user"));
                toReturn.SetUser(await userTask);
            } catch (Exception ex)
            {
                Console.WriteLine("user column not found"); 
            }
            connector.CloseConnection(reviewReader);
            return toReturn;
        }


    }
}
