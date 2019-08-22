using ForumSquare.Shared.Models.Utils;
using ForumSquare.Shared.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ForumSquare.Api.Models;
using ForumSquare.Shared.Models.Messages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ForumSquare.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace ForumSquare.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IRepository<MessagesSearchObject, Message> _repository;

        private readonly UserManager<ApplicationUser> _userManager;

        public MessagesController(IRepository<MessagesSearchObject, Message> repository,
            UserManager<ApplicationUser> userManager)
        {
        	_repository = repository;
            _userManager = userManager;
        }

        [HttpGet(Name = nameof(GetMessagesAsync))]
        public async Task<IActionResult> GetMessagesAsync(
            [FromQuery] SearchOptions<MessagesSearchObject, Message> searchOptions, 
            CancellationToken ct)
        {
            var messages = await _repository.GetAllAsync(searchOptions, ct);
            
            var response = new MessagesResponse
            {
            	Value = messages.ToArray(),
            	Self = Link.ToCollection(nameof(GetMessagesAsync))
            };
            
            return Ok(response);
        }

        [Authorize]
        [HttpPost(Name = nameof(AddMessageAsync))]
        public async Task<IActionResult> AddMessageAsync(
            [FromBody] MessageForm form,
            CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Name));

            var message = new Message()
            {
                UserID = user.Id,
                UserName = user.Email,
                Text = form.Text
            };

            var task = await _repository.AddAsync(message, ct);
            return Ok(task);
        }
    }
}
