using ERP_Store.Domain.Enuns;
using ERP_Store.Domain.Validation;
using System.Text.Json.Serialization;

namespace ERP_Store.Domain.Entities;

public sealed class Sale : BaseEntity
{
    public Sale()
    {
        CreatedDate = DateTime.UtcNow;
        ClosingDate = DateTime.MinValue;
        StatusSale = EStatusSale.Pending;
    }

    public Sale(int clientId, Client client, int productId, Product product, decimal soldQuantity, DateTime createdDate, 
        DateTime closingDate, EStatusSale statusSale)
    {
        ValidateDomain(clientId, client, productId, product, soldQuantity, createdDate, closingDate, statusSale);
    }

    [JsonConstructor]
    public Sale(int id, int clientId, Client client, int productId, Product product, decimal soldQuantity, DateTime createdDate, 
        DateTime closingDate, EStatusSale statusSale)
    {
        DomainValidation.When(id < 0, "Id inválido");
        Id = id;
        ValidateDomain(clientId, client, productId, product, soldQuantity, createdDate, closingDate, statusSale);
    }

    public void Closing()
    {
        ClosingDate = DateTime.UtcNow;
        StatusSale = EStatusSale.Closing;
    }

    public void Update(int clientId, int productId, decimal soldQuantity)
    {
        ClientId = clientId;
        ProductId = productId;
        SoldQuantity = soldQuantity;
    }

    public int ClientId { get; private set; }
    public Client Client { get; private set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public decimal SoldQuantity { get; private set; }
    public DateTime? CreatedDate { get; private set; }
    public DateTime? ClosingDate { get; private set; }
    public EStatusSale? StatusSale { get; private set; }

    private void ValidateDomain(int clientId, Client client, int productId, Product product, decimal soldQuantity, 
        DateTime createdDate, DateTime closingDate, EStatusSale statusSale)
    {
        ClientId = clientId;
        Client = client;
        ProductId = productId;
        Product = product;
        SoldQuantity = soldQuantity;
        CreatedDate = createdDate;
        ClosingDate = closingDate;
        StatusSale = statusSale;
    }
}