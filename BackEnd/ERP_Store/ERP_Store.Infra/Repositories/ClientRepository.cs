using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using ERP_Store.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP_Store.Infra.Repositories;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    protected readonly AppDbContext _context;

    public ClientRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}