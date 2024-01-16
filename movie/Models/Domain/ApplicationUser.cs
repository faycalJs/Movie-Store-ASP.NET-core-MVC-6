using Microsoft.AspNetCore.Identity;

namespace movie.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
