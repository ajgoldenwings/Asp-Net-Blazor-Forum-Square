using AutoMapper;
using ForumSquare.DataAccess.Models;
using ForumSquare.Shared.Models.Messages;

namespace ForumSquare.Shared.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Message, MessagesSearchObject>();
        }
    }
}
