
using System.Text.Json.Serialization;
using ERP_Store.Domain.Validation;

namespace ERP_Store.Domain.Entities;

public sealed class Client : BaseEntity
{
    public Client()
    {
    }

    public Client(string name, string email)
    {
        ValidateDomain(name, email);
    }

    [JsonConstructor]
    public Client(int id, string name, string email)
    {
        DomainValidation.When(id < 0, "Id inválido");
        Id = id;
        ValidateDomain(name, email);
    }

    public void Update(string name, string email)
    {
        ValidateDomain(name, email);
    }

    public string? Name { get; private set; }
    public string? Email { get; private set; }   

    private void ValidateDomain(string name, string email)
    {
        Name = name;
        Email = email;
    }
}