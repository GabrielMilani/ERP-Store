using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using ERP_Store.Infra.Context;

namespace ERP_Store.Infra.Repositories;

public class MoveStockRepository : BaseRepository<MoveStock>, IMoveStockRepository
{
    protected readonly AppDbContext _context;

    public MoveStockRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}