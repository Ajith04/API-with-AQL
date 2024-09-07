using SQL_Last_Assignment.DTO.RequestDTO;
using SQL_Last_Assignment.DTO.ResponseDTO;

namespace SQL_Last_Assignment.IServices
{
    public interface IProductService
    {
        Task<List<ProductResponseDTO>> getProductByPrice();
        Task<List<ProductResponseDTO>> getProductPagination(int PageSize, int PageNumber);
        Task<List<ProductResponseDTO>> getProductByDescending();
        Task<ProductResponseDTO> addProduct(ProductRequestDTO productrequestdto);
        Task<List<ProductResponseDTO>> addProductRange(List<ProductRequestDTO> listproductrequestdto);
        Task<string> removeProduct(Guid id);
        Task<List<ProductResponseDTO>> searchWithPagination(int page_size, int page_number, string product_name);
    }
}
