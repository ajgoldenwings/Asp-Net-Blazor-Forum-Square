using AutoMapper;
using ForumSquare.DataAccess.Models;
using ForumSquare.Shared.Models.Messages;
using ForumSquare.Shared.Models.Utils;

namespace ForumSquare.Shared.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Message, MessagesSearchObject>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src =>
                    Link.To(nameof(Server.Controllers.MessagesController.GetMessagesAsync), new { messageId = src.Id })));
            CreateMap<Message, MessagesSearchObject>();
        }
    }
}
