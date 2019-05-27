using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsWebApi.Models
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] [MaxLength(10)] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
    }
}