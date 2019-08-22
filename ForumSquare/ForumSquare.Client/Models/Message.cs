using ForumSquare.Client.Models.Collections;
using System;

namespace ForumSquare.Client.Models
{
    public class Message : Link
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime When { get; set; }
        public string UserID { get; set; }
        //public virtual ApplicationUser Sender { get; set; }
    }
}
