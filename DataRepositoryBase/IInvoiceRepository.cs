using DatabaseModels;

namespace DataRepositoryBase;

public interface IInvoiceRepository
{
    public Task DeleteAsync(int Id);

    public Task<Invoice> GetAsync(int Id);

    public Task<Invoice> InsertAsync(Invoice record);

    public Task<Invoice> UpdateAsync(int Id, Invoice record);
}
