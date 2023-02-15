using System.ComponentModel.DataAnnotations;

namespace StoringSystemBe.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string productType { get; set; } = null!;
    }
}
