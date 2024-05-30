using JobService.Domain.Entity;

namespace JobService.Api.Dto.Request;

public class JobRequestDto {
    public List<RequestItemDto> Items {
        get; set;
    }
    public bool ExtraMargin {
        get; set;
    }

    internal RawJob ToRawJob() {
        IEnumerable<RawItem> rawItems = Items.Select(i => new RawItem(i.Name, i.Price, i.Exempt));
        return new RawJob(rawItems, ExtraMargin);
    }
}
