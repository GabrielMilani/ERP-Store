namespace ERP_Store.Application.UseCases.ProductCase.CreateProduct;

public sealed class CreateProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}