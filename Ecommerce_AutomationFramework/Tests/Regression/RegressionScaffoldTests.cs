[TestFixture]
[Category("Regression")]
public class RegressionScaffoldTests
{
    [Test]
    [Explicit("Regression suite scaffolding only. Add real scenarios in Phase 1.")]
    public void Regression_Suite_ShouldBeWired()
    {
        Assert.Pass("Regression suite scaffold is in place.");
    }
}
