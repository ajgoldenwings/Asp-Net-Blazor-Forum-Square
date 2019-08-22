using Newtonsoft.Json;

namespace ForumSquare.Shared.Models.Utils
{
    public abstract class Resource : Link
    {
        [JsonIgnore]
        public Link Self { get; set; }

    }
}
