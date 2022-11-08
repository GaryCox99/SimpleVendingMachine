using DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepositoryBase;

public interface IInvoiceItemRepository
{
    public Task DeleteAsync(int Id);

    public Task<InvoiceItem> GetAsync(int Id);

    Task<IEnumerable<InvoiceItem>> GetAllByInvoiceAsync(int InvoiceId);

    Task<IEnumerable<InvoiceItem>> GetAllByProductIdAsync(int ProductId);

    public Task<InvoiceItem> InsertAsync(InvoiceItem record);

    public Task<InvoiceItem> UpdateAsync(int Id, InvoiceItem record);
}
