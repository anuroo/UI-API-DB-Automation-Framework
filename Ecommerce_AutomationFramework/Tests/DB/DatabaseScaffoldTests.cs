[TestFixture]
[Category("DB")]
public class DatabaseScaffoldTests
{
    [Test]
    // [Explicit("Set ESHOP_DB_CONNECTION to the exact Aspire Postgres connection string and run this once to verify connectivity.")]
    public async Task Postgres_Connection_Should_Work()
    {
        var db = new DbHelper(SettingsProvider.ActiveProfile.DbConnectionString);
        var value = await db.QuerySingleAsync<int>("SELECT 1");

        Assert.That(value, Is.EqualTo(1));
    }
    [Test]
    public async Task TestCount_CatalogDb()
    {
        var db=new DbHelper(SettingsProvider.ActiveProfile.DbConnectionString);
        var count = await db.QuerySingleAsync<int>("Select COUNT(*) FROM \"Catalog\"");
        Assert.That(count,Is.EqualTo(101));
        System.Console.WriteLine($"The total count of catalog db:{count}");
    }
}
