using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataModels
{
    public class User
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(255)]
        public string EmailAddress { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }
    }
}