using CleanArchitecture.Application.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Login(string Email, string Password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "FirstName", "LastName", Email, "token");

        }

        public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
        {
            //check if user already exist
            Guid userId = Guid.NewGuid();

            //create user(generate unique Id)
            var token = _jwtTokenGenerator.GenerateToken(userId, FirstName, LastName);
            //create JWT token
            return new AuthenticationResult(Guid.NewGuid(), FirstName, LastName, Email, "token");
        }
    }
}
