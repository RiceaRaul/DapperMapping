using DapperMapping.Api.DataAcces.Repository;

namespace DapperMapping.Api.DataAcces
{
    public interface IUnitWork : IDisposable
    {

        IContactsRepository ContactsRepository { get; }
        void Commit();
    }
}
