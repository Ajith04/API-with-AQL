using Azure.Messaging;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using SQL_Last_Assignment.DbContexts;
using SQL_Last_Assignment.IRepositories;
using SQL_Last_Assignment.Models;

namespace SQL_Last_Assignment.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly CompanyDbContext _companydbcontext;

        public ProductRepo(CompanyDbContext companydbcontext)
        {
            _companydbcontext = companydbcontext;
        }

        public async Task<List<Product>> getProductByPrice()
        {
            var filteredProducts = await _companydbcontext.Products.Where(r => r.Price > 100).ToListAsync();
            return filteredProducts;
        }

        public async Task<List<Product>> getProductPagination(int PageSize, int PageNumber)
        {
            var productList = await _companydbcontext.Products.Skip((PageNumber-1)*PageSize).Take(PageSize).ToListAsync();
            return productList;

        }

        public async Task<List<Product>> getProductByDescending()
        {
            var descendingProducts = await _companydbcontext.Products.OrderByDescending(r => r.Price).ToListAsync();
            return descendingProducts;
        }

        public async Task<Product> addProduct(Product product)
        {
            await _companydbcontext.Products.AddAsync(product);
            await _companydbcontext.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> addProductRange(List<Product> productList)
        {
            await _companydbcontext.Products.AddRangeAsync(productList);
            await _companydbcontext.SaveChangesAsync();
            return productList;
        }

        public async Task<string> removeProduct(Guid id)
        {
            var deleteProduct = _companydbcontext.Products.Find(id);
            if (deleteProduct != null)
            {
                _companydbcontext.Products.Remove(deleteProduct);
                await _companydbcontext.SaveChangesAsync();
                return "Successfully Deleted";
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Product>> searchWithPagination(int page_size, int page_number, string product_name)
        {
            var resultProduct = await _companydbcontext.Products.Where(r => r.Name.Contains(product_name)).Skip((page_number-1) * page_size).Take(page_size).ToListAsync();
            return resultProduct;
        }
    }
}
