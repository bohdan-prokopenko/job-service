using JobService.Domain.Entity;

namespace JobService.Domain.UseCase;

public interface ICalculateTotalUseCase {
    JobResult Execute(RawJob job);
}