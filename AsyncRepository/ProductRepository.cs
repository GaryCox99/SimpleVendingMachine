using DatabaseModels;
using DataRepositoryBase;

namespace AsyncRepository
{
    internal class ProductRepository : IProductRepository
    {
        private readonly IAsyncSqlDataAccess _db;
        public ProductRepository(IAsyncSqlDataAccess db)
        {
            _db = db;
        }

        public async Task<Product> GetAsync(int Id)
        {
            string storedProcedure = "Product_ReadById";
            var rows = await _db.GetAsyncUsingStoredProcedure<Product, dynamic>(storedProcedure, new { Id = Id });
            var returnRow = rows.FirstOrDefault();

            return returnRow;
        }

        public async Task<IEnumerable<Product>> GetAsync(string ProductName)
        {
            string storedProcName = "Product_ReadByName";
            var results = await _db.GetAsyncUsingStoredProcedure<Product, dynamic>(storedProcName,
                                                                 new { ProductName = ProductName });
            return results;
        }

        public async Task<Product> InsertAsync(Product record)
        {
            string storedProcName = "Product_Insert";
            var insertedRow = await _db.InsertAsync<Product>(storedProcName, record);
            return insertedRow.FirstOrDefault();
        }

        public async Task<Product> UpdateAsync(int Id, Product record)
        {
            string storedProcName = "Product_Update";
            var parameters = new Dictionary<string, object>();
            parameters["@Id"] = Id;

            var updatedRow = await _db.UpdateAsync<Product>(storedProcName, parameters, record);
            return updatedRow.FirstOrDefault();
        }
    }

}