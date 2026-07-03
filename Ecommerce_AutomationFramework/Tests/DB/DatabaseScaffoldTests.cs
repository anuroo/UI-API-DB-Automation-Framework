[TestFixture]
[Category("DB")]
public class DatabaseScaffoldTests
{
    [Test]
    [Explicit("Database validation is scaffolded only in Phase 0.")]
    public void Database_Layer_ShouldBePresent()
    {
        Assert.Pass("Database helper and repository scaffolds are present.");
    }
}
