﻿namespace CleanArchitectureTemplate.Application.DTOs.Product.Requests
{
    public partial class CreateProductRequest
    {
        public string Name { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal Rate { get; set; }
    }
}
