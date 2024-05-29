namespace JobService.Api.Response;

public record JobResponse(List<ResponseItem> Items, string Total) {
}
