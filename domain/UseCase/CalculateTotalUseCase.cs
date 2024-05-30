using JobService.Domain.Entity;

using static System.Math;

namespace JobService.Domain.UseCase;

internal class CalculateTotalUseCase : ICalculateTotalUseCase {
    private const decimal BaseMarginDefault = 0.11M;
    private const decimal ExtraMarginDefault = 0.05M;
    private const decimal SalesTaxDefault = 0.07M;

    public JobResult Execute(RawJob job) {
        IEnumerable<ItemResult> results = job.Items.Select(item => {
            var totalPrice = item.Price;
            var tax = item.Exempt ? 0 : SalesTaxDefault;
            totalPrice += Round(item.Price * tax, 2);
            var margin = job.ExtraMargin ? BaseMarginDefault + ExtraMarginDefault : BaseMarginDefault;
            return new ItemResult(
                Name: item.Name,
                BasePrice: item.Price,
                TotalPrice: totalPrice,
                SalesTax: item.Price * tax,
                Margin: item.Price * margin);
        });

        return CalculateJob(results);
    }

    private JobResult CalculateJob(IEnumerable<ItemResult> items) {
        var totalPrice = items.Select(i => i.BasePrice).Sum();
        var totalTax = items.Select(i => i.SalesTax).Sum();
        var totalMargin = items.Select(i => i.Margin).Sum();
        var total = Round(totalPrice + totalTax + totalMargin, 2, MidpointRounding.ToZero);
        return new JobResult(items, total);
    }
}
