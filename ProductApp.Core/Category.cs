
using System.ComponentModel;


namespace ProductApp.Core
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Category Name")]
        public string Name { get; set; }
    }
}
