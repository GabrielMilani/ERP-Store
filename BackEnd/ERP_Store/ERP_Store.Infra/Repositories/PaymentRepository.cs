using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using ERP_Store.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP_Store.Infra.Repositories;

public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
{
    protected readonly AppDbContext _context;


    public PaymentRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}