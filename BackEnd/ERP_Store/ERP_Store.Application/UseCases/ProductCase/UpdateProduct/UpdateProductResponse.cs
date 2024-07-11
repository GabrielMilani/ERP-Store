namespace ERP_Store.Application.UseCases.ProductCase.UpdateProduct;

public sealed class UpdateProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}