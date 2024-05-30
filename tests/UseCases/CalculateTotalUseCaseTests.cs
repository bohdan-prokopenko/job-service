using JobService.Domain.Entity;
using JobService.Domain.UseCase;

namespace JobService.Domain.Tests.UseCases;

[TestFixture]
internal class CalculateTotalUseCaseTests {

    private readonly ICalculateTotalUseCase useCase = new CalculateTotalUseCase();

    [Test]
    public void ExecuteTest1() {
        var frisbees = new RawItem("frisbees", 19385.38M, true);
        var yoyos = new RawItem("yo-yos", 1829M, true);
        var job = new RawJob([frisbees, yoyos], true);

        JobResult result = useCase.Execute(job);

        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            ItemResult resultFrisbees = result.Items.FirstOrDefault(i => i.Name.Equals("frisbees"));
            ItemResult resultYoyos = result.Items.FirstOrDefault(i => i.Name.Equals("yo-yos"));
            Assert.That(resultFrisbees, Is.Not.Null);
            Assert.That(resultYoyos, Is.Not.Null);
            Assert.That(resultFrisbees.TotalPrice, Is.EqualTo(19385.38M));
            Assert.That(resultYoyos.TotalPrice, Is.EqualTo(1829.00M));
            Assert.That(result.Total, Is.EqualTo(24608.68M));
        });
    }

    [Test]
    public void ExecuteTest2() {
        var envelopes = new RawItem("envelopes", 520.00M);
        var letterhead = new RawItem("letterhead", 1983.37M, true);
        var job = new RawJob([envelopes, letterhead], true);

        JobResult result = useCase.Execute(job);

        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            ItemResult resultEnvelopes = result.Items.FirstOrDefault(i => i.Name.Equals("envelopes"));
            ItemResult resultLetterhead = result.Items.FirstOrDefault(i => i.Name.Equals("letterhead"));
            Assert.That(resultEnvelopes, Is.Not.Null);
            Assert.That(resultLetterhead, Is.Not.Null);
            Assert.That(resultEnvelopes.TotalPrice, Is.EqualTo(556.40M));
            Assert.That(resultLetterhead.TotalPrice, Is.EqualTo(1983.37M));
            Assert.That(result.Total, Is.EqualTo(2940.30M));
        });
    }

    [Test]
    public void ExecuteTest3() {
        var tshirts = new RawItem("t-shirts", 294.04M);
        var job = new RawJob([tshirts]);

        JobResult result = useCase.Execute(job);

        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            ItemResult resultTshirts = result.Items.FirstOrDefault(i => i.Name.Equals("t-shirts"));
            Assert.That(resultTshirts, Is.Not.Null);
            Assert.That(resultTshirts.TotalPrice, Is.EqualTo(314.62M));
            Assert.That(result.Total, Is.EqualTo(346.96M));
        });
    }

    [Test]
    public void ExecuteTest4() {
        var item = new RawItem("item", 100M);
        var job = new RawJob([item]);

        JobResult result = useCase.Execute(job);

        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            ItemResult resultItem = result.Items.FirstOrDefault(i => i.Name.Equals("item"));
            Assert.That(resultItem, Is.Not.Null);
            Assert.That(resultItem.TotalPrice, Is.EqualTo(107M));
            Assert.That(result.Total, Is.EqualTo(118M));
        });
    }
}
