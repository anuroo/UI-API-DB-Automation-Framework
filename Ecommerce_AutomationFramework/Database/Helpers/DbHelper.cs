using System.Globalization;
using System.Text.Json;
using Npgsql;

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

    public async Task<T?> QuerySingleAsync<T>(string sql, object? parameters = null)
    {
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(sql, connection);
        AddParameters(command, parameters);

        await using var reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
        {
            return default;
        }

        return MapRow<T>(reader);
    }

    public async Task<int> ExecuteAsync(string sql, object? parameters = null)
    {
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(sql, connection);
        AddParameters(command, parameters);
        return await command.ExecuteNonQueryAsync();
    }

    private static void AddParameters(NpgsqlCommand command, object? parameters)
    {
        if (parameters is null)
        {
            return;
        }

        foreach (var property in parameters.GetType().GetProperties())
        {
            var parameterName = $"@{property.Name}";
            var value = property.GetValue(parameters) ?? DBNull.Value;
            command.Parameters.AddWithValue(parameterName, value);
        }
    }

    private static T? MapRow<T>(NpgsqlDataReader reader)
    {
        var targetType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

        if (reader.FieldCount == 1)
        {
            var value = reader.GetValue(0);
            if (value is DBNull)
            {
                return default;
            }

            if (targetType.IsAssignableFrom(value.GetType()))
            {
                return (T)value;
            }

            return (T)Convert.ChangeType(value, targetType, CultureInfo.InvariantCulture);
        }

        var row = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < reader.FieldCount; i++)
        {
            row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
        }

        var json = JsonSerializer.Serialize(row);
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}
