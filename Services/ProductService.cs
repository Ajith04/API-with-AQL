using SQL_Last_Assignment.DTO.RequestDTO;
using SQL_Last_Assignment.DTO.ResponseDTO;
using SQL_Last_Assignment.IRepositories;
using SQL_Last_Assignment.IServices;
using SQL_Last_Assignment.Models;

namespace SQL_Last_Assignment.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _iproductrepo;

        public ProductService(IProductRepo iproductrepo)
        {
            _iproductrepo = iproductrepo;
        }

        public async Task<List<ProductResponseDTO>> getProductByPrice()
        {
            var filteredProducts = await _iproductrepo.getProductByPrice();

            var productList = new List<ProductResponseDTO>();

            foreach (var product in filteredProducts)
            {
                var singleProduct = new ProductResponseDTO();
                singleProduct.Id = product.Id;
                singleProduct.Name = product.Name;
                singleProduct.Price = product.Price;
                singleProduct.Quantity = product.Quantity;

                productList.Add(singleProduct);
            }

            return productList;
        }

        public async Task<List<ProductResponseDTO>> getProductPagination(int PageSize, int PageNumber)
        {
            var productList = await _iproductrepo.getProductPagination(PageSize, PageNumber);

            var paginatedProductList = new List<ProductResponseDTO>();

            foreach (var product in productList)
            {
                var singleProduct = new ProductResponseDTO();
                singleProduct.Id = product.Id;
                singleProduct.Name = product.Name;
                singleProduct.Price = product.Price;
                singleProduct.Quantity= product.Quantity;

                paginatedProductList.Add(singleProduct);
            }

            return paginatedProductList;
        }

        public async Task<List<ProductResponseDTO>> getProductByDescending()
        {
            var productList = await _iproductrepo.getProductByDescending();

            var productresponseList = new List<ProductResponseDTO>();

            foreach(var product in productList)
            {
                var singleProduct = new ProductResponseDTO();
                singleProduct.Id = product.Id;
                singleProduct.Name = product.Name;
                singleProduct.Price = product.Price;
                singleProduct.Quantity= product.Quantity;

                productresponseList.Add(singleProduct);
            }

            return productresponseList;
        }

        public async Task<ProductResponseDTO> addProduct(ProductRequestDTO productrequestdto)
        {
            var product = new Product();
            product.Name = productrequestdto.Name;
            product.Price = productrequestdto.Price;
            product.Quantity = productrequestdto.Quantity;

            var addedProduct = await _iproductrepo.addProduct(product);
            
            var productResponse = new ProductResponseDTO();
            productResponse.Id = addedProduct.Id;
            productResponse.Name = addedProduct.Name;
            productResponse.Price = addedProduct.Price;
            productResponse.Quantity = addedProduct.Quantity;

            return productResponse;
        }

        public async Task<List<ProductResponseDTO>> addProductRange(List<ProductRequestDTO> listproductrequestdto)
        {
            var productList = new List<Product>();

            foreach(var product in listproductrequestdto)
            {
                var singleProduct = new Product();
                singleProduct.Name = product.Name;
                singleProduct.Price = product.Price;
                singleProduct.Quantity = product.Quantity;

                productList.Add(singleProduct);
            }

            var addedProductRange = await _iproductrepo.addProductRange(productList);

            var productResponseList = new List<ProductResponseDTO>();

            foreach(var addedproduct in addedProductRange)
            {
                var addedSingleProduct = new ProductResponseDTO();
                addedSingleProduct.Id = addedproduct.Id;
                addedSingleProduct.Name = addedproduct.Name;
                addedSingleProduct.Price = addedproduct.Price;
                addedSingleProduct.Quantity = addedproduct.Quantity;

                productResponseList.Add(addedSingleProduct);
            }

            return productResponseList;
        }

        public async Task<string> removeProduct(Guid id)
        {
            var deleteStatus = await _iproductrepo.removeProduct(id);

            if(deleteStatus != null)
            {
                return deleteStatus;
            }
            else
            {
                throw new Exception("There is no such record");
            }
        }

        public async Task<List<ProductResponseDTO>> searchWithPagination(int page_size, int page_number, string product_name)
        {
            var resultProduct = await _iproductrepo.searchWithPagination(page_size, page_number, product_name);

            var productList = new List<ProductResponseDTO>();

            foreach(var product in resultProduct)
            {
                var singleProduct = new ProductResponseDTO();
                singleProduct.Id = product.Id;
                singleProduct.Name = product.Name;
                singleProduct.Price = product.Price;
                singleProduct.Quantity = product.Quantity;

                productList.Add(singleProduct);
            }

            return productList;
        }

    }
}
