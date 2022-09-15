using System.ComponentModel.DataAnnotations.Schema;
namespace DapperMapping.Api.Models
{
    public class Contacts { 
   
        public int Id { get; set; }

        [Column("name_contact")]
        public int NameContact { get; set; }


        [Column("phone_number")]
        public int PhoneNumber { get; set; }
    }
}