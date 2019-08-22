using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ForumSquare.DataAccess.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Message> Messages { get; set; }
        //public virtual string FirstName { get; set; }
        //public virtual string LastName { get; set; }

        public ApplicationUser()
        {
            Messages = new HashSet<Message>();
        }
    }
}
