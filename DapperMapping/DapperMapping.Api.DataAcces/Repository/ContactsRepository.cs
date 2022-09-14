using DapperMapping.Api.Models;
using System.Data;
using Dapper;
namespace DapperMapping.Api.DataAcces.Repository
{
    public class ContactsRepository : RepositoryBase, IContactsRepository
    {
        public ContactsRepository(IDbTransaction transaction) : base(transaction)
        {
         
        }

        public IEnumerable<Contacts> All()
        {
            return Connection.Query<Contacts>(
                "SELECT * FROM contacts",
                transaction: Transaction
            ).ToList();
        }
    }
}
