using Microsoft.AspNetCore.Identity;

namespace MovieWeb.Domain
{
    public class MovieAppUser : IdentityUser
    {
        public string Geslacht { get; set; }
    }
}
