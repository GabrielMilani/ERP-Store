namespace ERP_Store.Domain.Abstractions;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    IClientRepository ClientRepository { get; }
    IPaymentRepository PaymentRepository { get; }
    ISaleRepository SaleRepository { get; }
    Task CommitAsync(CancellationToken cancellationToken);
}