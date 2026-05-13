using MISA.Salary.DL.Entities.Base;

namespace MISA.Salary.DL.Entities;

/// <summary>
/// Thành phần lương (pa_salary_composition)
/// </summary>
public class SalaryComposition : BaseEntity
{
    public Guid SalaryCompositionId { get; set; }
    public string SalaryCompositionCode { get; set; } = string.Empty;
    public string SalaryCompositionName { get; set; } = string.Empty;
    public Guid? OrganizationId { get; set; }

    /// <summary>1=Thu nhập, 2=Khấu trừ, 3=Chấm công, 4=Doanh số, 5=Thông tin nhân viên, 6=Khác</summary>
    public int SalaryComponentType { get; set; }

    /// <summary>1=Cố định, 2=Biến đổi, 3=Theo công thức</summary>
    public int Nature { get; set; }

    /// <summary>1=Chịu thuế, 2=Miễn thuế toàn phần, 3=Miễn thuế một phần</summary>
    public int TaxOption { get; set; } = 1;

    public string? Quota { get; set; }
    public bool AllowManualOverride { get; set; } = false;

    /// <summary>1=Tiền tệ, 2=Số, 3=Phần trăm, 4=Chữ</summary>
    public int ValueType { get; set; } = 1;

    /// <summary>1=Tự động, 2=Theo công thức</summary>
    public int ValueSource { get; set; } = 2;

    public string? ValueFormula { get; set; }
    public string? Description { get; set; }

    /// <summary>1=Có, 2=Không, 3=Chỉ nếu khác 0</summary>
    public int ShowOnPayslip { get; set; } = 2;

    /// <summary>1=Tự thêm, 2=Từ hệ thống</summary>
    public int SourceType { get; set; } = 1;

    public Guid? SalaryCompositionSystemId { get; set; }

    /// <summary>1=Đang theo dõi, 0=Ngừng theo dõi</summary>
    public int Status { get; set; } = 1;

    // Navigation (join)
    public string? OrganizationName { get; set; }
    public string? SalaryCompositionSystemCode { get; set; }
}
