using MDP.Data;
using MDP.Handlers;
using MDP.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MDP.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController
    {
        private readonly DatabaseConnector conn;
        public AuthController(DatabaseConnector conn)
        {
            this.conn = conn;
        }

        [HttpPost("login")]
        public User Login(User login)
        {
            return new AuthHandler(conn).Login(login);
        }

        [HttpPost("register")]
        public bool Register(User register)
        {
            return new AuthHandler(conn).Register(register);
        }
    }
}
