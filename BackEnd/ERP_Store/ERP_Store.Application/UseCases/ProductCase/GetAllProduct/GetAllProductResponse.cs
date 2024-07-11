namespace ERP_Store.Application.UseCases.ProductCase.GetAllProduct;

public sealed class GetAllProductResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}