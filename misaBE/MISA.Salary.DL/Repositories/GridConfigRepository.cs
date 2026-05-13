using Dapper;
using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories.Base;

namespace MISA.Salary.DL.Repositories;

public class GridConfigRepository : BaseRepository<GridConfig>, IGridConfigRepository
{
    protected override string TableName => "pa_grid_config";
    protected override string PrimaryKey => "GridConfigId";

    public GridConfigRepository(string connectionString) : base(connectionString) { }

    public async Task<IEnumerable<GridConfig>> GetByGridIdAsync(string gridId, string? userId = null)
    {
        using var conn = CreateConnection();
        var sql = userId != null
            ? $"SELECT * FROM {TableName} WHERE GridId = @GridId AND (UserId = @UserId OR UserId IS NULL) ORDER BY OrderIndex"
            : $"SELECT * FROM {TableName} WHERE GridId = @GridId AND UserId IS NULL ORDER BY OrderIndex";
        return await conn.QueryAsync<GridConfig>(sql, new { GridId = gridId, UserId = userId });
    }

    public async Task<int> SaveConfigAsync(string gridId, string? userId, IEnumerable<GridConfig> configs)
    {
        using var conn = CreateConnection();
        await conn.ExecuteAsync(
            $"DELETE FROM {TableName} WHERE GridId = @GridId AND (UserId = @UserId OR (@UserId IS NULL AND UserId IS NULL))",
            new { GridId = gridId, UserId = userId });
        var now = DateTime.UtcNow;
        var rows = 0;
        foreach (var config in configs)
        {
            config.GridConfigId = Guid.NewGuid();
            config.GridId = gridId;
            config.UserId = userId;
            config.CreatedDate = now;
            config.ModifiedDate = now;
            await conn.ExecuteAsync($@"
                INSERT INTO {TableName} (GridConfigId, GridId, ColumnName, ColumnTitle, Width, Visible, Pinned, OrderIndex, UserId, CreatedDate, ModifiedDate)
                VALUES (@GridConfigId, @GridId, @ColumnName, @ColumnTitle, @Width, @Visible, @Pinned, @OrderIndex, @UserId, @CreatedDate, @ModifiedDate)",
                config);
            rows++;
        }
        return rows;
    }

    public override async Task<Guid> InsertAsync(GridConfig entity)
    {
        using var conn = CreateConnection();
        entity.GridConfigId = Guid.NewGuid();
        entity.CreatedDate = DateTime.UtcNow;
        entity.ModifiedDate = DateTime.UtcNow;
        await conn.ExecuteAsync($@"
            INSERT INTO {TableName} (GridConfigId, GridId, ColumnName, ColumnTitle, Width, Visible, Pinned, OrderIndex, UserId, CreatedDate, ModifiedDate)
            VALUES (@GridConfigId, @GridId, @ColumnName, @ColumnTitle, @Width, @Visible, @Pinned, @OrderIndex, @UserId, @CreatedDate, @ModifiedDate)",
            entity);
        return entity.GridConfigId;
    }

    public override async Task<int> UpdateAsync(GridConfig entity)
    {
        using var conn = CreateConnection();
        entity.ModifiedDate = DateTime.UtcNow;
        return await conn.ExecuteAsync($@"
            UPDATE {TableName} SET Width=@Width, Visible=@Visible, Pinned=@Pinned, OrderIndex=@OrderIndex, ModifiedDate=@ModifiedDate
            WHERE GridConfigId=@GridConfigId", entity);
    }
}
