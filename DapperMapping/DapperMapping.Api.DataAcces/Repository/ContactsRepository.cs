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

        public IEnumerable<ContactsResponse> All()
        {
            return Connection.Query<Contacts,ContactsName,ContactsNumber,ContactsResponse>(
                sql:"SELECT * FROM [learn].[dbo].[contacts] LEFT JOIN[learn].[dbo].[ContactsName] ON [learn].[dbo].[contacts].name_contact =  [learn].[dbo].[ContactsName].id LEFT JOIN[learn].[dbo].[ContactNumber] ON[learn].[dbo].[contacts].phone_number =  [learn].[dbo].[ContactNumber].id",
                map:(contact,contactname,contactNumber) =>
                {
                    ContactsResponse response = new ContactsResponse();
                    response.Id = contact.Id;
                    response.NameContact = contactname.Name;
                    response.PhoneNumber = contactNumber.Number;
                    return response;
                },
                splitOn:"id",
                transaction: Transaction
            ).ToList();
        }
    }
}
