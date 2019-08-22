using ForumSquare.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumSquare.DataAccess
{
    public interface IApplicationDbContext
    {
        DbSet<Message> Messages { get; set; }
        //DbSet<Organization> Organizations { get; set; }
        //DbSet<OrganizationRole> OrganizationRoles { get; set; }
        //DbSet<UserOrganizationRole> UserOrganizationRoles { get; set; }
        //DbSet<MembershipRequest> MembershipRequests { get; set; }
        //DbSet<Motion> Motions { get; set; }
        //DbSet<Vote> Votes { get; set; }
    }
}
