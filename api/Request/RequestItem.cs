namespace JobService.Api.Request;

public class RequestItem {
    public string Name {
        get; set;
    }
    public decimal Price {
        get; set;
    }
    public Exempt Exempt {
        get; set;
    }
}
