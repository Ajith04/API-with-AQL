using SQL_Last_Assignment.Models;

namespace SQL_Last_Assignment.IRepositories
{
    public interface IProductRepo
    {
        Task<List<Product>> getProductByPrice();
        Task<List<Product>> getProductPagination(int PageSize, int PageNumber);
        Task<List<Product>> getProductByDescending();

        Task<Product> addProduct(Product product);
        Task<List<Product>> addProductRange(List<Product> productList);
        Task<string> removeProduct(Guid id);
        Task<List<Product>> searchWithPagination(int page_size, int page_number, string product_name);
    }
}
