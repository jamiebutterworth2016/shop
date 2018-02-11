using System.ComponentModel.DataAnnotations;

namespace DAL.DataModels
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string EmailAddress { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }
    }
}