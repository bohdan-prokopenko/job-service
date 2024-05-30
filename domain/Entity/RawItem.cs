namespace JobService.Domain.Entity;

public record RawItem(string Name, decimal Price, bool Exempt = false) {
}
