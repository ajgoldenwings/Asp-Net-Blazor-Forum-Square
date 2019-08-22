using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ForumSquare.Client.Models;
using ForumSquare.Client.Services;
using System;

namespace ForumSquare.Client.Pages.Forum
{
    public class ForumPageModel : ComponentBase
    {
        [Inject]
        private MessagesService MessagesService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }
        public string MessagePost { get; set; }
        public List<Message> Messages { get; set; }

        public ApiError Error { get; set; }

        public async Task OnMessageCreate(MessageForm messageForm)
        {
            if (!string.IsNullOrEmpty(messageForm.Text))
            {
                var result = await MessagesService.CreateMessage(messageForm);
                if (result.Response != null)
                {
                    Messages.Add(result.Response);
                }
                if (result.Error != null)
                {
                    Error = result.Error;
                }
                StateHasChanged();
            }
        }

        public async Task SubmitMessage()
        {
            await GetMessages();
            MessagePost = "";
        }

        private async Task GetMessages()
        {
            var result = await MessagesService.GetMessages();
            
            try
            {
                if (result.Response != null)
                {
                    Messages = result.Response.Value.ToList();
                }
                if (result.Error != null)
                {
                    Error = result.Error;
                }
            }
            catch (Exception ex)
            {
                Error = new ApiError() {
                    Details = "Null result returned. The message service did not return any results.",
                    Message = ex.Message
                };
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await AuthenticationStateTask;
            await GetMessages();
        }
    }
}
