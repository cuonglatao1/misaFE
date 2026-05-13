using Dapper;
using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories.Base;
using MySqlConnector;

namespace MISA.Salary.DL.Repositories;

public class SalaryCompositionRepository : BaseRepository<SalaryComposition>, ISalaryCompositionRepository
{
    protected override string TableName => "pa_salary_composition";
    protected override string PrimaryKey => "SalaryCompositionId";

    public SalaryCompositionRepository(string connectionString) : base(connectionString) { }

    public async Task<(IEnumerable<SalaryComposition> Data, int TotalCount)> GetPagedAsync(
        string? keyword, Guid? organizationId, int? status, int page, int pageSize)
    {
        using var conn = CreateConnection();
        var conditions = new List<string>();
        var parameters = new DynamicParameters();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            conditions.Add("(sc.SalaryCompositionCode LIKE @Keyword OR sc.SalaryCompositionName LIKE @Keyword)");
            parameters.Add("Keyword", $"%{keyword}%");
        }
        if (organizationId.HasValue)
        {
            conditions.Add("sc.OrganizationId = @OrganizationId");
            parameters.Add("OrganizationId", organizationId.Value);
        }
        if (status.HasValue)
        {
            conditions.Add("sc.Status = @Status");
            parameters.Add("Status", status.Value);
        }

        var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
        var countSql = $"SELECT COUNT(*) FROM {TableName} sc {where}";
        var dataSql = $@"
            SELECT sc.*, o.OrganizationName, sys.SalaryCompositionCode AS SalaryCompositionSystemCode
            FROM {TableName} sc
            LEFT JOIN pa_organization o ON sc.OrganizationId = o.OrganizationId
            LEFT JOIN pa_salary_composition_system sys ON sc.SalaryCompositionSystemId = sys.SalaryCompositionSystemId
            {where}
            ORDER BY sc.ModifiedDate DESC, sc.CreatedDate DESC
            LIMIT @Offset, @PageSize";

        parameters.Add("Offset", (page - 1) * pageSize);
        parameters.Add("PageSize", pageSize);

        var totalCount = await conn.ExecuteScalarAsync<int>(countSql, parameters);
        var data = await conn.QueryAsync<SalaryComposition>(dataSql, parameters);
        return (data, totalCount);
    }

    public async Task<bool> IsCodeExistsAsync(string code, Guid? excludeId = null)
    {
        using var conn = CreateConnection();
        var sql = excludeId.HasValue
            ? $"SELECT COUNT(1) FROM {TableName} WHERE SalaryCompositionCode = @Code AND SalaryCompositionId != @ExcludeId"
            : $"SELECT COUNT(1) FROM {TableName} WHERE SalaryCompositionCode = @Code";
        var count = await conn.ExecuteScalarAsync<int>(sql, new { Code = code, ExcludeId = excludeId });
        return count > 0;
    }

    public async Task<SalaryComposition?> GetByCodeAsync(string code)
    {
        using var conn = CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<SalaryComposition>(
            $"SELECT * FROM {TableName} WHERE SalaryCompositionCode = @Code", new { Code = code });
    }

    public async Task<Guid> CloneAsync(Guid id, string newCode, string newName, string? createdBy)
    {
        using var conn = CreateConnection();
        var newId = Guid.NewGuid();
        var now = DateTime.UtcNow;
        var sql = $@"
            INSERT INTO {TableName} (
                SalaryCompositionId, SalaryCompositionCode, SalaryCompositionName,
                OrganizationId, SalaryComponentType, Nature, TaxOption,
                Quota, AllowManualOverride, ValueType, ValueSource, ValueFormula,
                Description, ShowOnPayslip, SourceType, SalaryCompositionSystemId, Status,
                CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
            )
            SELECT @NewId, @NewCode, @NewName,
                OrganizationId, SalaryComponentType, Nature, TaxOption,
                Quota, AllowManualOverride, ValueType, ValueSource, ValueFormula,
                Description, ShowOnPayslip, SourceType, SalaryCompositionSystemId, Status,
                @Now, @CreatedBy, @Now, @CreatedBy
            FROM {TableName} WHERE SalaryCompositionId = @Id";
        await conn.ExecuteAsync(sql, new { NewId = newId, NewCode = newCode, NewName = newName, Id = id, Now = now, CreatedBy = createdBy });
        return newId;
    }

    public override async Task<Guid> InsertAsync(SalaryComposition entity)
    {
        using var conn = CreateConnection();
        entity.SalaryCompositionId = Guid.NewGuid();
        entity.CreatedDate = DateTime.UtcNow;
        entity.ModifiedDate = DateTime.UtcNow;
        var sql = $@"
            INSERT INTO {TableName} (
                SalaryCompositionId, SalaryCompositionCode, SalaryCompositionName,
                OrganizationId, SalaryComponentType, Nature, TaxOption,
                Quota, AllowManualOverride, ValueType, ValueSource, ValueFormula,
                Description, ShowOnPayslip, SourceType, SalaryCompositionSystemId, Status,
                CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
            ) VALUES (
                @SalaryCompositionId, @SalaryCompositionCode, @SalaryCompositionName,
                @OrganizationId, @SalaryComponentType, @Nature, @TaxOption,
                @Quota, @AllowManualOverride, @ValueType, @ValueSource, @ValueFormula,
                @Description, @ShowOnPayslip, @SourceType, @SalaryCompositionSystemId, @Status,
                @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy
            )";
        await conn.ExecuteAsync(sql, entity);
        return entity.SalaryCompositionId;
    }

    public override async Task<int> UpdateAsync(SalaryComposition entity)
    {
        using var conn = CreateConnection();
        entity.ModifiedDate = DateTime.UtcNow;
        var sql = $@"
            UPDATE {TableName} SET
                SalaryCompositionCode = @SalaryCompositionCode,
                SalaryCompositionName = @SalaryCompositionName,
                OrganizationId = @OrganizationId,
                SalaryComponentType = @SalaryComponentType,
                Nature = @Nature,
                TaxOption = @TaxOption,
                Quota = @Quota,
                AllowManualOverride = @AllowManualOverride,
                ValueType = @ValueType,
                ValueSource = @ValueSource,
                ValueFormula = @ValueFormula,
                Description = @Description,
                ShowOnPayslip = @ShowOnPayslip,
                Status = @Status,
                ModifiedDate = @ModifiedDate,
                ModifiedBy = @ModifiedBy
            WHERE SalaryCompositionId = @SalaryCompositionId";
        return await conn.ExecuteAsync(sql, entity);
    }
}
