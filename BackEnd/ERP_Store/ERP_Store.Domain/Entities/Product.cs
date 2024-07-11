
using System.Text.Json.Serialization;
using ERP_Store.Domain.Enuns;
using ERP_Store.Domain.Validation;

namespace ERP_Store.Domain.Entities;

public sealed class Product : BaseEntity
{
    public Product()
    {
    }

    public Product(string name, string description, decimal price, decimal quantity)
    {
        ValidateDomain(name, description, price, quantity);
    }

    [JsonConstructor]
    public Product(int id, string name, string description, decimal price, decimal quantity)
    {
        DomainValidation.When(id < 0, "Id inválido");
        Id = id;
        ValidateDomain(name, description, price, quantity);
    }

    public void Update(string name, string description, decimal price, decimal quantity)
    {
        ValidateDomain(name, description, price, quantity);
    }

    public void MoveStock(decimal quantity, EActionMoveStock actionMoveStock)
    {
        if (actionMoveStock == EActionMoveStock.remove)
            Quantity = Quantity - quantity;
        else
            Quantity = Quantity + quantity;
    }

    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public decimal Quantity { get; private set; }

    private void ValidateDomain(string name, string description, decimal price, decimal quantity)
    {
        DomainValidation.When(string.IsNullOrEmpty(name), "Nome Inválido, Nome e requirido.");
        DomainValidation.When(name.Length < 3, "Nome Inválido, O nome deve conter pelo menos 3 caracteres.");
        DomainValidation.When(string.IsNullOrEmpty(description), "Description Inválido, Description e requirido.");
        DomainValidation.When(description.Length < 3, "Description Inválido, O nome deve conter pelomenos 3 caracteres.");
        
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
    }
}