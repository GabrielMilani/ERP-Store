using ERP_Store.Domain.Enuns;
using System.Text.Json.Serialization;
using ERP_Store.Domain.Validation;

namespace ERP_Store.Domain.Entities;

public sealed class MoveStock : BaseEntity
{
    public MoveStock()
    {
    }

    public MoveStock(EActionMoveStock eActionMoveStock, decimal quantityMoved, DateTime dateMoved, int productId, 
                     Product product, string document, EDocumentType documentType)
    {
        ValidateDomain(eActionMoveStock, quantityMoved, dateMoved, productId, product, document, documentType);
    }

    [JsonConstructor]
    public MoveStock(int id, EActionMoveStock eActionMoveStock, decimal quantityMoved, DateTime dateMoved, int productId, 
        Product product, string document, EDocumentType documentType)
    {
        DomainValidation.When(id < 0, "Id inválido");
        Id = id;
        ValidateDomain(eActionMoveStock, quantityMoved, dateMoved, productId, product, document, documentType);
    }

    public EActionMoveStock EActionMoveStock { get; private set; }
    public decimal QuantityMoved { get; private set; }
    public DateTime DateMoved { get; private set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public string Document { get; private set; }
    public EDocumentType DocumentType { get; private set; }

    public void Update(EActionMoveStock eActionMoveStock, decimal quantityMoved, DateTime dateMoved, int productId, 
        Product product, string document, EDocumentType documentType)
    {
        ValidateDomain(eActionMoveStock, quantityMoved, dateMoved, productId, product, document, documentType);
    }

    private void ValidateDomain(EActionMoveStock eActionMoveStock, decimal quantityMoved, DateTime dateMoved, int productId, 
                                Product product, string document, EDocumentType documentType)
    {
        EActionMoveStock = eActionMoveStock;
        QuantityMoved = quantityMoved;
        DateMoved = dateMoved;
        ProductId = productId;
        Product = product;
        Document = document;
        DocumentType = documentType;
    }
}