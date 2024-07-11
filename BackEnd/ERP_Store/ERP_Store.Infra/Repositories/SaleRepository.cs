using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using ERP_Store.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP_Store.Infra.Repositories;

public class SaleRepository : BaseRepository<Sale>, ISaleRepository
{
    protected readonly AppDbContext _context;

    public SaleRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}