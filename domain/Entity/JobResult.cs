namespace JobService.Domain.Entity;
public record JobResult(IEnumerable<ItemResult> Items, decimal Total) {
}
