using JobService.Domain.Entity;

using static System.Math;

namespace JobService.Domain.UseCase;

internal class CalculateTotalUseCase : ICalculateTotalUseCase {
    private const decimal BaseMarginDefault = 0.11M;
    private const decimal ExtraMarginDefault = 0.05M;
    private const decimal SalesTaxDefault = 0.07M;

    public JobResult Execute(RawJob job) {
        IEnumerable<ItemResult> results = job.Items.Select(CalculateItemResult);
        var total = CalculateJobTotalPrice(job);
        return new JobResult(results, total);
    }

    public ItemResult CalculateItemResult(RawItem item) {
        var tax = item.Exempt ? 0 : SalesTaxDefault;
        var price = item.Price;
        price += Round(item.Price * tax, 2);
        return new ItemResult(item.Name, price);
    }

    public decimal CalculateJobTotalPrice(RawJob job) {
        IEnumerable<RawItem> items = job.Items;
        var margin = job.ExtraMargin ? BaseMarginDefault + ExtraMarginDefault : BaseMarginDefault;
        var totalMargin = items.Select(i => i.Price * margin).Sum();
        var totalTax = items.Select(i => i.Exempt ? 0 : i.Price * SalesTaxDefault).Sum();
        var totalPrice = items.Select(i => i.Price).Sum();
        return Round(totalPrice + totalTax + totalMargin, 2, MidpointRounding.ToZero);
    }
}
