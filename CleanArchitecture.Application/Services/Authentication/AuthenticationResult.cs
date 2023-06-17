using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services.Authentication
{
    public record AuthenticationResult(Guid Id, string FirstName, string LastName, string Email, string Token);

    //public class AuthenticationResult
    //{
    //    public Guid Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Email { get; set; }
    //    public string Token { get; set; }
    //}
}
