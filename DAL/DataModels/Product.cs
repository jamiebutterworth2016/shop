using System.ComponentModel.DataAnnotations;

namespace DAL.DataModels
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
    }
}