namespace JobService.Api.Dto.Request;

public class RequestItemDto {
    public string Name {
        get; set;
    }
    public decimal Price {
        get; set;
    }
    public bool Exempt {
        get; set;
    }
}
