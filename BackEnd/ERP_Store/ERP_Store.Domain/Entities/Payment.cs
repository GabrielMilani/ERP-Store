using ERP_Store.Domain.Enuns;
using ERP_Store.Domain.Validation;
using System.Text.Json.Serialization;

namespace ERP_Store.Domain.Entities;

public sealed class Payment : BaseEntity
{
    public Payment()
    {
    }

    public Payment(int saleId, Sale sale, decimal valuePay, decimal valuePaid, DateTime createdDate, DateTime paymentDate, 
        EStatusPayment statusPayment)
    {
        ValidateDomain(saleId, sale, valuePay, valuePaid, createdDate, paymentDate, statusPayment);
    }

    public Payment(int saleId, Sale sale, decimal valuePay)
    {
        SaleId = saleId;
        Sale = sale;
        ValuePay = valuePay;
        ValuePaid = 0;
        CreatedDate = DateTime.UtcNow;
        PaymentDate = DateTime.MinValue;
        StatusPayment = EStatusPayment.Pending;
    }

    [JsonConstructor]
    public Payment(int id, int saleId, Sale sale, decimal valuePay, decimal valuePaid, DateTime createdDate, DateTime paymentDate, 
        EStatusPayment statusPayment)
    {
        DomainValidation.When(id < 0, "Id inválido");
        Id = id;
        ValidateDomain(saleId, sale, valuePay, valuePaid, createdDate, paymentDate, statusPayment);
    }

    public void Update(int saleId, Sale sale, decimal valuePay, decimal valuePaid, DateTime createdDate, DateTime paymentDate, 
        EStatusPayment statusPayment)
    {
        ValidateDomain(saleId, sale, valuePay, valuePaid, createdDate, paymentDate, statusPayment);
    }

    public void Paid(decimal valuePaid)
    {
        if (valuePaid != 0)
        {
            if (valuePaid >= ValuePay)
            {
                ValuePaid = valuePaid;
                PaymentDate = DateTime.UtcNow;
                StatusPayment = EStatusPayment.Paid;
            }
            DomainValidation.When(valuePaid < ValuePay, "Valor insuficiente para pagar esta venda.");
        }

    }

    public int SaleId { get; private set; }
    public Sale? Sale { get; private set; }
    public decimal? ValuePay { get; private set; }
    public decimal? ValuePaid { get; private set; }
    public DateTime? CreatedDate { get; private set; }
    public DateTime? PaymentDate { get; private set; }
    public EStatusPayment? StatusPayment { get; private set; }

    private void ValidateDomain(int saleId, Sale? sale, decimal? valuePay, decimal? valuePaid, DateTime? createdDate, DateTime? paymentDate, EStatusPayment? statusPayment)
    {
        SaleId = saleId;
        Sale = sale;
        ValuePay = valuePay;
        ValuePaid = valuePaid;
        CreatedDate = createdDate;
        PaymentDate = paymentDate;
        StatusPayment = statusPayment;
    }
}