using MISA.Salary.BL.DTOs;
using MISA.Salary.BL.Services.Base;
using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories;

namespace MISA.Salary.BL.Services;

public class SalaryCompositionService : ISalaryCompositionService
{
    private readonly ISalaryCompositionRepository _repo;

    public SalaryCompositionService(ISalaryCompositionRepository repo)
    {
        _repo = repo;
    }

    public async Task<ServiceResult<IEnumerable<SalaryComposition>>> GetAllAsync()
    {
        var data = await _repo.GetAllAsync();
        return ServiceResult<IEnumerable<SalaryComposition>>.Ok(data);
    }

    public async Task<ServiceResult<SalaryComposition>> GetByIdAsync(Guid id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null)
            return ServiceResult<SalaryComposition>.Fail("Không tìm thấy thành phần lương");
        return ServiceResult<SalaryComposition>.Ok(entity);
    }

    public async Task<ServiceResult<PagedResult<SalaryComposition>>> GetPagedAsync(SalaryCompositionFilterDto filter)
    {
        if (filter.Page < 1) filter.Page = 1;
        if (filter.PageSize < 1) filter.PageSize = 20;

        var (data, total) = await _repo.GetPagedAsync(
            filter.Keyword, filter.OrganizationId, filter.Status, filter.Page, filter.PageSize);

        return ServiceResult<PagedResult<SalaryComposition>>.Ok(new PagedResult<SalaryComposition>
        {
            Data = data, TotalCount = total, Page = filter.Page, PageSize = filter.PageSize
        });
    }

    public async Task<ServiceResult<Guid>> CreateAsync(SalaryCompositionCreateDto dto)
    {
        var errors = Validate(dto);
        if (errors.Count > 0) return ServiceResult<Guid>.Fail(errors);

        if (await _repo.IsCodeExistsAsync(dto.SalaryCompositionCode))
            return ServiceResult<Guid>.Fail($"Mã thành phần lương '{dto.SalaryCompositionCode}' đã tồn tại");

        var entity = MapToEntity(dto);
        var id = await _repo.InsertAsync(entity);
        return ServiceResult<Guid>.Ok(id, "Thêm mới thành phần lương thành công");
    }

    public async Task<ServiceResult<int>> UpdateAsync(Guid id, SalaryCompositionUpdateDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return ServiceResult<int>.Fail("Không tìm thấy thành phần lương");

        var errors = Validate(dto);
        if (errors.Count > 0) return ServiceResult<int>.Fail(errors);

        if (await _repo.IsCodeExistsAsync(dto.SalaryCompositionCode, id))
            return ServiceResult<int>.Fail($"Mã thành phần lương '{dto.SalaryCompositionCode}' đã tồn tại");

        var entity = MapToEntity(dto);
        entity.SalaryCompositionId = id;
        entity.Status = dto.Status;
        entity.ModifiedBy = dto.ModifiedBy;

        var rows = await _repo.UpdateAsync(entity);
        return ServiceResult<int>.Ok(rows, "Cập nhật thành phần lương thành công");
    }

    public async Task<ServiceResult<int>> DeleteAsync(Guid id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return ServiceResult<int>.Fail("Không tìm thấy thành phần lương");
        var rows = await _repo.DeleteAsync(id);
        return ServiceResult<int>.Ok(rows, "Xóa thành phần lương thành công");
    }

    public async Task<ServiceResult<int>> DeleteManyAsync(IEnumerable<Guid> ids)
    {
        var idList = ids.ToList();
        if (idList.Count == 0) return ServiceResult<int>.Fail("Danh sách ID không được rỗng");
        var rows = await _repo.DeleteManyAsync(idList);
        return ServiceResult<int>.Ok(rows, $"Đã xóa {rows} thành phần lương");
    }

    public async Task<ServiceResult<Guid>> CloneAsync(Guid id, SalaryCompositionCloneDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return ServiceResult<Guid>.Fail("Không tìm thấy thành phần lương cần nhân bản");

        if (string.IsNullOrWhiteSpace(dto.NewCode))
            return ServiceResult<Guid>.Fail("Mã thành phần lương mới không được để trống");

        if (await _repo.IsCodeExistsAsync(dto.NewCode))
            return ServiceResult<Guid>.Fail($"Mã thành phần lương '{dto.NewCode}' đã tồn tại");

        var newId = await _repo.CloneAsync(id, dto.NewCode, dto.NewName, dto.CreatedBy);
        return ServiceResult<Guid>.Ok(newId, "Nhân bản thành phần lương thành công");
    }

    private static List<string> Validate(SalaryCompositionCreateDto dto)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(dto.SalaryCompositionCode))
            errors.Add("Mã thành phần lương không được để trống");
        else if (dto.SalaryCompositionCode.Length > 255)
            errors.Add("Mã thành phần lương không được vượt quá 255 ký tự");
        if (string.IsNullOrWhiteSpace(dto.SalaryCompositionName))
            errors.Add("Tên thành phần lương không được để trống");
        else if (dto.SalaryCompositionName.Length > 255)
            errors.Add("Tên thành phần lương không được vượt quá 255 ký tự");
        if (dto.SalaryComponentType < 1 || dto.SalaryComponentType > 6)
            errors.Add("Loại thành phần không hợp lệ");
        if (dto.Nature < 1 || dto.Nature > 3)
            errors.Add("Tính chất không hợp lệ");
        return errors;
    }

    private static SalaryComposition MapToEntity(SalaryCompositionCreateDto dto) => new()
    {
        SalaryCompositionCode = dto.SalaryCompositionCode.Trim(),
        SalaryCompositionName = dto.SalaryCompositionName.Trim(),
        OrganizationId = dto.OrganizationId,
        SalaryComponentType = dto.SalaryComponentType,
        Nature = dto.Nature,
        TaxOption = dto.TaxOption,
        Quota = dto.Quota,
        AllowManualOverride = dto.AllowManualOverride,
        ValueType = dto.ValueType,
        ValueSource = dto.ValueSource,
        ValueFormula = dto.ValueFormula,
        Description = dto.Description,
        ShowOnPayslip = dto.ShowOnPayslip,
        SourceType = dto.SourceType,
        SalaryCompositionSystemId = dto.SalaryCompositionSystemId,
        CreatedBy = dto.CreatedBy
    };
}
