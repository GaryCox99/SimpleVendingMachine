using DatabaseModels;
using DataRepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncRepository
{
    internal class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly IAsyncSqlDataAccess _db;

        public InvoiceItemRepository(IAsyncSqlDataAccess db)
        {
            _db = db;
        }

        public async Task DeleteAsync(int Id)
        {
            string storedProcName = "InvoiceItem_Delete";
            await _db.DeleteAsync<object>(storedProcName, Id);
        }

        public async Task<IEnumerable<InvoiceItem>> GetAllByInvoiceAsync(int InvoiceId)
        {
            string storedProcName = "InvoiceItem_ReadByInvoiceId";
            var results = await _db.GetAsyncUsingStoredProcedure<InvoiceItem, dynamic>(storedProcName,
                                                                 new { InvoiceId = InvoiceId });
            return results;
        }

        public async Task<IEnumerable<InvoiceItem>> GetAllByProductIdAsync(int ProductId)
        {
            string storedProcName = "InvoiceItem_ReadByProductId";
            var results = await _db.GetAsyncUsingStoredProcedure<InvoiceItem, dynamic>(storedProcName,
                                                                 new { ProductId = ProductId });
            return results;
        }

        public async Task<InvoiceItem> GetAsync(int Id)
        {
            string storedProcName = "InvoiceItem_ReadById";
            var rows = await _db.GetAsyncUsingStoredProcedure<InvoiceItem, dynamic>(storedProcName, new { Id = Id });
            var returnRow = rows.FirstOrDefault();

            return returnRow;
        }

        public async Task<InvoiceItem> InsertAsync(InvoiceItem record)
        {
            string storedProcName = "InvoiceItem_Insert";
            var insertedRow = await _db.InsertAsync<InvoiceItem>(storedProcName, record);

            return insertedRow.FirstOrDefault();
        }

        public async Task<InvoiceItem> UpdateAsync(int Id, InvoiceItem record)
        {
            string storedProcName = "InvoiceItem_Update";
            var parameters = new Dictionary<string, object>();
            parameters["@Id"] = Id;

            var updatedRow = await _db.UpdateAsync<InvoiceItem>(storedProcName, parameters, record);
            return updatedRow.FirstOrDefault();
        }
    }
}
