
namespace ForumSquare.Client.Models.Collections
{
    public class Collection<T> : Link
    {
        public T[] Value { get; set; }
    }
}
