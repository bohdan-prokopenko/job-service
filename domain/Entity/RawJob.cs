namespace JobService.Domain.Entity;

public record RawJob(IEnumerable<RawItem> Items, bool ExtraMargin = false) {
}
