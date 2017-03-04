using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFD.Model
{
    public class User
    {
        public User(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public User()
        {
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
