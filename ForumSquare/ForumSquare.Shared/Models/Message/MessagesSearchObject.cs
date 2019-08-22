using ForumSquare.Shared.Infrastructure.Searching;
using ForumSquare.Shared.Models.Utils;
using System;

namespace ForumSquare.Shared.Models.Messages
{
    public class MessagesSearchObject : Resource
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }

        [Searchable]
        public DateTime When { get; set; }
        public string UserID { get; set; }

        //[SearchableGuidAttribute]
        //public virtual ApplicationUserSearchObject Sender { get; set; }
    }
}
