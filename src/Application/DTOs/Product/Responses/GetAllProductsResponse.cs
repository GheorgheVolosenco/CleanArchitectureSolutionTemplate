namespace CarDataPlatformIngestor.Application.DTOs.Product.Responses
{
    public class GetAllProductsResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal Rate { get; set; }
    }
}
