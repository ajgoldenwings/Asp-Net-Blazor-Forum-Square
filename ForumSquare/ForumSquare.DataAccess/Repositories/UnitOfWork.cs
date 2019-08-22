using ForumSquare.DataAccess.Repositories.Interfaces;

namespace ForumSquare.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }

        //public MessageRepository Messages { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
            //Messages = new MessageRepository(context);
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
