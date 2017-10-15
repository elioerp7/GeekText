using GeekText.Data;
using System.ComponentModel.DataAnnotations;

namespace GeekText.Models
{
    public class Book
    {

        [Key]
        [MaxLength(17)]
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public string Publisher { get; set; }        

        [MinLength(0)]
        public int Quantity { get; set; }

        [MaxLength(255)]
        public string Image { get; set; }

        public int IsFeatured { get; set; }

    }
    
}
