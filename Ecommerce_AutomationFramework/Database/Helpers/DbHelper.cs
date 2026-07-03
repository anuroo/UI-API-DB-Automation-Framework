using RestSharp;

public interface IDbHelper
{
    Task<T?> QuerySingleAsync<T>(string sql, object? parameters = null);
    Task<int> ExecuteAsync(string sql, object? parameters = null);
}

public sealed class DbHelper : IDbHelper
{
    public DbHelper(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public string ConnectionString { get; }

    public Task<T?> QuerySingleAsync<T>(string sql, object? parameters = null)
    {
        throw new NotSupportedException("Database execution is scaffolded only in Phase 0. Wire a DB provider in Phase 1.");
    }

    public Task<int> ExecuteAsync(string sql, object? parameters = null)
    {
        throw new NotSupportedException("Database execution is scaffolded only in Phase 0. Wire a DB provider in Phase 1.");
    }
}
