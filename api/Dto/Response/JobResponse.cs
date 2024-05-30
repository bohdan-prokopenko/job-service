using JobService.Domain.Entity;

namespace JobService.Api.Dto.Response;

public class JobResponse(JobResult job) {
    public List<ResponseItem> Items {
        get; private set;
    } = job.Items.Select(i => new ResponseItem(i)).ToList();

    public string Total {
        get; private set;
    } = $"${job.Total}";
}
