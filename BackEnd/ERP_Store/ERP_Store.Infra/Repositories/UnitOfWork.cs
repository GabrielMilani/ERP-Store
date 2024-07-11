using ERP_Store.Domain.Abstractions;
using ERP_Store.Infra.Context;

namespace ERP_Store.Infra.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable, IAsyncDisposable
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    private IProductRepository? _productRepository;
    private IClientRepository? _clientRepository;
    private IPaymentRepository? _paymentRepository;
    private ISaleRepository? _saleRepository;

    public IProductRepository ProductRepository
        => _productRepository = _productRepository ?? new ProductRepository(_context);

    public IClientRepository ClientRepository 
        => _clientRepository = _clientRepository ?? new ClientRepository(_context);

    public IPaymentRepository PaymentRepository 
        => _paymentRepository = _paymentRepository ?? new PaymentRepository(_context);

    public ISaleRepository SaleRepository 
        => _saleRepository = _saleRepository ?? new SaleRepository(_context);

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}