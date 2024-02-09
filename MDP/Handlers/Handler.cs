using MDP.Data;

namespace MDP.Handlers
{
    public class Handler
    {
        protected DatabaseConnector connector;

        public Handler(DatabaseConnector connector)
        {
            this.connector = connector;
        }
    }
}
