using Dapper;
using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories.Base;

namespace MISA.Salary.DL.Repositories;

public class SalaryCompositionSystemRepository : BaseRepository<SalaryCompositionSystem>, ISalaryCompositionSystemRepository
{
    protected override string TableName => "pa_salary_composition_system";
    protected override string PrimaryKey => "SalaryCompositionSystemId";

    public SalaryCompositionSystemRepository(string connectionString) : base(connectionString) { }

    public async Task<(IEnumerable<SalaryCompositionSystem> Data, int TotalCount)> GetPagedAsync(
        string? keyword, int? status, int page, int pageSize)
    {
        using var conn = CreateConnection();
        var conditions = new List<string>();
        var parameters = new DynamicParameters();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            conditions.Add("(SalaryCompositionCode LIKE @Keyword OR SalaryCompositionName LIKE @Keyword)");
            parameters.Add("Keyword", $"%{keyword}%");
        }
        if (status.HasValue)
        {
            conditions.Add("Status = @Status");
            parameters.Add("Status", status.Value);
        }

        var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
        var countSql = $"SELECT COUNT(*) FROM {TableName} {where}";
        var dataSql = $"SELECT * FROM {TableName} {where} ORDER BY SalaryCompositionCode LIMIT @Offset, @PageSize";

        parameters.Add("Offset", (page - 1) * pageSize);
        parameters.Add("PageSize", pageSize);

        var totalCount = await conn.ExecuteScalarAsync<int>(countSql, parameters);
        var data = await conn.QueryAsync<SalaryCompositionSystem>(dataSql, parameters);
        return (data, totalCount);
    }

    public async Task<IEnumerable<SalaryCompositionSystem>> GetAvailableAsync(IEnumerable<string> excludeCodes)
    {
        using var conn = CreateConnection();
        var excludeList = excludeCodes.ToList();
        if (excludeList.Count == 0)
            return await conn.QueryAsync<SalaryCompositionSystem>(
                $"SELECT * FROM {TableName} WHERE Status = 1 ORDER BY SalaryCompositionCode");
        return await conn.QueryAsync<SalaryCompositionSystem>(
            $"SELECT * FROM {TableName} WHERE Status = 1 AND SalaryCompositionCode NOT IN @Codes ORDER BY SalaryCompositionCode",
            new { Codes = excludeList });
    }

    public override async Task<Guid> InsertAsync(SalaryCompositionSystem entity)
    {
        using var conn = CreateConnection();
        entity.SalaryCompositionSystemId = Guid.NewGuid();
        entity.CreatedDate = DateTime.UtcNow;
        entity.ModifiedDate = DateTime.UtcNow;
        var sql = $@"
            INSERT INTO {TableName} (
                SalaryCompositionSystemId, SalaryCompositionCode, SalaryCompositionName,
                SalaryComponentType, Nature, TaxOption, ValueType, Description, Status,
                CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
            ) VALUES (
                @SalaryCompositionSystemId, @SalaryCompositionCode, @SalaryCompositionName,
                @SalaryComponentType, @Nature, @TaxOption, @ValueType, @Description, @Status,
                @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy
            )";
        await conn.ExecuteAsync(sql, entity);
        return entity.SalaryCompositionSystemId;
    }

    public override async Task<int> UpdateAsync(SalaryCompositionSystem entity)
    {
        using var conn = CreateConnection();
        entity.ModifiedDate = DateTime.UtcNow;
        var sql = $@"
            UPDATE {TableName} SET
                SalaryCompositionCode = @SalaryCompositionCode,
                SalaryCompositionName = @SalaryCompositionName,
                SalaryComponentType = @SalaryComponentType,
                Nature = @Nature,
                TaxOption = @TaxOption,
                ValueType = @ValueType,
                Description = @Description,
                Status = @Status,
                ModifiedDate = @ModifiedDate,
                ModifiedBy = @ModifiedBy
            WHERE SalaryCompositionSystemId = @SalaryCompositionSystemId";
        return await conn.ExecuteAsync(sql, entity);
    }
}
