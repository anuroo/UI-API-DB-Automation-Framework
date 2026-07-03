[TestFixture]
[Category("UI")]
public class UiScaffoldTests
{
    [Test]
    [Explicit("UI automation is scaffolded only in Phase 0.")]
    public void Ui_Layer_ShouldBePresent()
    {
        Assert.Pass("UI folder and starter classes are present.");
    }
}
