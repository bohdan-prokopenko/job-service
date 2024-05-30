using JobService.Domain.Entity;

namespace JobService.Api.Dto.Response;

public class ResponseItem(ItemResult item) {
    public string Name {
        get; private set;
    } = item.Name;

    public string Price {
        get; private set;
    } = $"${item.TotalPrice}";
}
