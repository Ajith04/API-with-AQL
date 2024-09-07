using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQL_Last_Assignment.DTO.RequestDTO;
using SQL_Last_Assignment.DTO.ResponseDTO;
using SQL_Last_Assignment.IServices;

namespace SQL_Last_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _iproductservice;

        public ProductController(IProductService iproductservice)
        {
            _iproductservice = iproductservice;
        }

        [HttpGet ("filter-products-by-price")]
        public async Task<IActionResult> getProductByPrice()
        {
            var filteredProducts = await _iproductservice.getProductByPrice();
            return Ok(filteredProducts);
        }

        [HttpGet ("get-product-pagination/{PageSize},{PageNumber}")]
        public async Task<IActionResult> getProductPagination(int PageSize, int PageNumber)
        {
            var paginatedProductList = await _iproductservice.getProductPagination(PageSize, PageNumber);
            return Ok(paginatedProductList);
        }

        [HttpGet ("get-product-by-descending")]
        public async Task<IActionResult> getProductByDescending()
        {
            var descendingProducts = await _iproductservice.getProductByDescending();
            return Ok(descendingProducts);
        }

        [HttpPost ("add-product")]
        public async Task<IActionResult> addProduct(ProductRequestDTO productrequestdto)
        {
            var addedProduct = await _iproductservice.addProduct(productrequestdto);
            return Ok(addedProduct);
        }

        [HttpPost ("add-product-range")]
        public async Task<IActionResult> addProductRange(List<ProductRequestDTO> listproductrequestDTO)
        {
            var addedProductList = await _iproductservice.addProductRange(listproductrequestDTO);
            return Ok(addedProductList);
        }

        [HttpDelete ("remove-product-by-id/{id}")]
        public async Task<IActionResult> removeProduct(Guid id)
        {
            try
            {
               var deleteSuccess = await _iproductservice.removeProduct(id);
               return Ok(deleteSuccess);
                
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpGet ("search-with-pagination/{Page_Size},{Page_Number},{Product_Name}")]
        public async Task<IActionResult> searchWithPagination(int Page_Size, int Page_Number, string Product_Name)
        {
            var resultProduct = await _iproductservice.searchWithPagination(Page_Size, Page_Number, Product_Name);
            return Ok(resultProduct);
        }
    }
}
