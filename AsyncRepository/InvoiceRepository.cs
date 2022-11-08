using DatabaseModels;
using DataRepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncRepository
{
    internal class InvoiceRepository : IInvoiceRepository
    {
        private readonly IAsyncSqlDataAccess _db;

        public InvoiceRepository(IAsyncSqlDataAccess db)
        {
            _db = db;
        }

        public async Task DeleteAsync(int Id)
        {
            string storedProcName = "Invoice_Delete";
            await _db.DeleteAsync<object>(storedProcName, Id);
        }

        public async Task<Invoice> GetAsync(int Id)
        {
            string storeProcName = "Invoice_ReadById";
            var rows = await _db.GetAsyncUsingStoredProcedure<Invoice, dynamic>(storeProcName, new { Id = Id });
            var returnRows = rows.FirstOrDefault();

            return returnRows;
        }

        public async Task<Invoice> InsertAsync(Invoice record)
        {
            string storedProcName = "Invoice_Insert";
            var insertedRow = await _db.InsertAsync<Invoice>(storedProcName, record);

            return insertedRow.FirstOrDefault();
        }

        public async Task<Invoice> UpdateAsync(int Id, Invoice record)
        {
            var storedProcName = "Invoice_Update";
            var parameters = new Dictionary<string, object>();
            parameters["@Id"] = Id;

            var updatedRow = await _db.UpdateAsync<Invoice>(storedProcName, parameters, record);
            return updatedRow.FirstOrDefault();
        }
    }
}
