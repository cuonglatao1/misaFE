using System.ComponentModel.DataAnnotations;

namespace MISA.Salary.BL.DTOs;

public class SalaryCompositionCreateDto
{
    [Required(ErrorMessage = "Mã thành phần lương không được để trống")]
    [MaxLength(255, ErrorMessage = "Mã thành phần lương không được vượt quá 255 ký tự")]
    public string SalaryCompositionCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tên thành phần lương không được để trống")]
    [MaxLength(255, ErrorMessage = "Tên thành phần lương không được vượt quá 255 ký tự")]
    public string SalaryCompositionName { get; set; } = string.Empty;

    public Guid? OrganizationId { get; set; }

    [Required(ErrorMessage = "Loại thành phần không được để trống")]
    [Range(1, 6, ErrorMessage = "Loại thành phần không hợp lệ")]
    public int SalaryComponentType { get; set; }

    [Required(ErrorMessage = "Tính chất không được để trống")]
    [Range(1, 3, ErrorMessage = "Tính chất không hợp lệ")]
    public int Nature { get; set; }

    [Range(1, 3)] public int TaxOption { get; set; } = 1;
    public string? Quota { get; set; }
    public bool AllowManualOverride { get; set; } = false;
    [Range(1, 4)] public int ValueType { get; set; } = 1;
    [Range(1, 2)] public int ValueSource { get; set; } = 2;
    public string? ValueFormula { get; set; }
    public string? Description { get; set; }
    [Range(1, 3)] public int ShowOnPayslip { get; set; } = 2;
    public int SourceType { get; set; } = 1;
    public Guid? SalaryCompositionSystemId { get; set; }
    public string? CreatedBy { get; set; }
}

public class SalaryCompositionUpdateDto : SalaryCompositionCreateDto
{
    [Required] public Guid SalaryCompositionId { get; set; }
    [Range(0, 1)] public int Status { get; set; } = 1;
    public string? ModifiedBy { get; set; }
}

public class SalaryCompositionCloneDto
{
    [Required(ErrorMessage = "Mã thành phần lương mới không được để trống")]
    [MaxLength(255)] public string NewCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tên thành phần lương mới không được để trống")]
    [MaxLength(255)] public string NewName { get; set; } = string.Empty;

    public string? CreatedBy { get; set; }
}

public class SalaryCompositionFilterDto
{
    public string? Keyword { get; set; }
    public Guid? OrganizationId { get; set; }
    public int? Status { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
