namespace JobService.Domain.Entity;
public record ItemResult(
    string Name, 
    decimal BasePrice, 
    decimal TotalPrice, 
    decimal SalesTax, 
    decimal Margin) {
}
