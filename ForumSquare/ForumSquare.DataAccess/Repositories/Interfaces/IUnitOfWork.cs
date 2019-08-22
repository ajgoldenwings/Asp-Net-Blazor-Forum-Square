using ForumSquare.Shared.Models;
using System;

namespace ForumSquare.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext Context { get; }

        //MessageRepository Messages { get; }

        void Commit();
    }
}
