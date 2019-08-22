using System.Threading.Tasks;

namespace ForumSquare.Server.Services
{
    public interface IEmailSender
    {
        Task SendEmailConfirmationAsync(string email, string userName, string confirmationLink);
        Task SendPasswordForgetAsync(string email, string userName, string passwordResetLink);
    }
}
