using System.ComponentModel.DataAnnotations.Schema;

namespace DapperMapping.Api.Models
{
    public class ContactsNumber
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("number")]
        public string Number { get; set; }
    }
}
