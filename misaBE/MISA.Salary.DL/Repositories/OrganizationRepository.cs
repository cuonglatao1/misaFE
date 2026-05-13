using Dapper;
using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories.Base;

namespace MISA.Salary.DL.Repositories;

public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
{
    protected override string TableName => "pa_organization";
    protected override string PrimaryKey => "OrganizationId";

    public OrganizationRepository(string connectionString) : base(connectionString) { }

    public async Task<IEnumerable<Organization>> GetActiveAsync()
    {
        using var conn = CreateConnection();
        return await conn.QueryAsync<Organization>(
            $"SELECT * FROM {TableName} WHERE Status = 1 ORDER BY OrganizationName");
    }

    public override async Task<Guid> InsertAsync(Organization entity)
    {
        using var conn = CreateConnection();
        entity.OrganizationId = Guid.NewGuid();
        entity.CreatedDate = DateTime.UtcNow;
        entity.ModifiedDate = DateTime.UtcNow;
        var sql = $@"
            INSERT INTO {TableName} (
                OrganizationId, OrganizationCode, OrganizationName, ParentId, Status,
                CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
            ) VALUES (
                @OrganizationId, @OrganizationCode, @OrganizationName, @ParentId, @Status,
                @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy
            )";
        await conn.ExecuteAsync(sql, entity);
        return entity.OrganizationId;
    }

    public override async Task<int> UpdateAsync(Organization entity)
    {
        using var conn = CreateConnection();
        entity.ModifiedDate = DateTime.UtcNow;
        var sql = $@"
            UPDATE {TableName} SET
                OrganizationCode = @OrganizationCode,
                OrganizationName = @OrganizationName,
                ParentId = @ParentId,
                Status = @Status,
                ModifiedDate = @ModifiedDate,
                ModifiedBy = @ModifiedBy
            WHERE OrganizationId = @OrganizationId";
        return await conn.ExecuteAsync(sql, entity);
    }
}
