namespace CleanArchitectureTemplate.Application.DTOs.Product.Requests
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Rate { get; set; }
    }
}
