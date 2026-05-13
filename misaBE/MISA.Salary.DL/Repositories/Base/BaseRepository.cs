using Dapper;
using MySqlConnector;

namespace MISA.Salary.DL.Repositories.Base;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly string _connectionString;
    protected abstract string TableName { get; }
    protected abstract string PrimaryKey { get; }

    protected BaseRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected MySqlConnection CreateConnection() => new(_connectionString);

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        using var conn = CreateConnection();
        return await conn.QueryAsync<T>($"SELECT * FROM {TableName}");
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        using var conn = CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<T>(
            $"SELECT * FROM {TableName} WHERE {PrimaryKey} = @Id",
            new { Id = id });
    }

    public abstract Task<Guid> InsertAsync(T entity);
    public abstract Task<int> UpdateAsync(T entity);

    public virtual async Task<int> DeleteAsync(Guid id)
    {
        using var conn = CreateConnection();
        return await conn.ExecuteAsync(
            $"DELETE FROM {TableName} WHERE {PrimaryKey} = @Id",
            new { Id = id });
    }

    public virtual async Task<int> DeleteManyAsync(IEnumerable<Guid> ids)
    {
        using var conn = CreateConnection();
        return await conn.ExecuteAsync(
            $"DELETE FROM {TableName} WHERE {PrimaryKey} IN @Ids",
            new { Ids = ids });
    }
}
