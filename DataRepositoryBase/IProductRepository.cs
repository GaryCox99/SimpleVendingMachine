using DatabaseModels;

namespace DataRepositoryBase;

public interface IProductRepository
{
    public Task<Product> GetAsync(int Id);

    Task<IEnumerable<Product>> GetAsync(string ProductName);

    public Task<Product> InsertAsync(Product record);

    public Task<Product> UpdateAsync(int Id, Product record);

}