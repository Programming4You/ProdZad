using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductApp.Core
{
    public class Product
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

       public Category Category { get; set; }
    }
}
