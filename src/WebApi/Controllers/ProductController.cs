using Application.Services.Products;
using CleanArchitectureTemplate.Application.DTOs.Product.Requests;
using CleanArchitectureTemplate.Application.DTOs.Product.Responses;
using CleanArchitectureTemplate.Application.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.WebApi.Controllers.v1
{
    [Route("api/product")]
    public class ProductController : BaseApiController
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Get a page with products.
        /// </summary>
        /// <param name="filter">Filter.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Page with products.</returns>
        /// <response code="200">Returns page with products.</response>
        /// <response code="400">Invalid payload.</response> 
        /// <response code="500">Internal error.</response> 
        /// <response code="503">Service Unavailable.</response> 
        [HttpGet]
        [ProducesResponseType(typeof(Response<IEnumerable<GetAllProductsResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsParameter filter, CancellationToken cancellationToken)
        {
            var query = new GetAllProductsRequest
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber
            };

            var response = await productService.GetAllProducts(query, cancellationToken);

            return this.Ok(response);
        }

        /// <summary>
        /// Get a product by Id.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Single product.</returns>
        /// <response code="200">Returns a product.</response>
        /// <response code="404">Product not found.</response> 
        /// <response code="500">Internal error.</response> 
        /// <response code="503">Service Unavailable.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<ProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Produces("application/json")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var request = new GetProductByIdRequest
            {
                Id = id
            };

            var response = await productService.GetProductById(request, cancellationToken);
            return this.Ok(response);
        }

        /// <summary>
        /// Add a new product.
        /// </summary>
        /// <param name="request">Product payload.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Created product Id.</returns>
        /// <response code="200">Returns created product Id.</response>
        /// <response code="401">Unauthorised.</response> 
        /// <response code="500">Internal error.</response> 
        /// <response code="503">Service Unavailable.</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Response<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Produces("application/json")]
        public async Task<IActionResult> Post(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var response = await productService.AddProduct(request, cancellationToken);
            return this.Ok(response);
        }

        /// <summary>
        /// Update a product.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <param name="request">Product payload.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Updated product Id.</returns>
        /// <response code="200">Returns updated product Id.</response>
        /// <response code="400">Invalid payload.</response> 
        /// <response code="401">Unauthorised.</response> 
        /// <response code="500">Internal error.</response> 
        /// <response code="503">Service Unavailable.</response>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Produces("application/json")]
        public async Task<IActionResult> Put(int id, UpdateProductRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var response = await productService.UpdateProduct(request, cancellationToken);
            return this.Ok(response);
        }

        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Deleted product Id.</returns>
        /// <response code="200">Returns deleted product Id.</response>
        /// <response code="401">Unauthorised.</response> 
        /// <response code="500">Internal error.</response> 
        /// <response code="503">Service Unavailable.</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var request = new DeleteProductByIdRequest
            {
                Id = id
            };

            var response = await productService.DeleteProduct(request, cancellationToken);
            return this.Ok(response);
        }
    }
}
