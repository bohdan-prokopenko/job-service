namespace JobService.Api.Request;

public class JobRequest {
    public List<RequestItem> Jobs {
        get; set;
    }
    public ExtraMargin ExtraMargin {
        get; set;
    }
}
