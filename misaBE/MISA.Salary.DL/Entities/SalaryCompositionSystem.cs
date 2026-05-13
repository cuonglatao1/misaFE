using MISA.Salary.DL.Entities.Base;

namespace MISA.Salary.DL.Entities;

/// <summary>
/// Danh mục thành phần lương hệ thống (pa_salary_composition_system)
/// </summary>
public class SalaryCompositionSystem : BaseEntity
{
    public Guid SalaryCompositionSystemId { get; set; }
    public string SalaryCompositionCode { get; set; } = string.Empty;
    public string SalaryCompositionName { get; set; } = string.Empty;

    /// <summary>1=Thu nhập, 2=Khấu trừ, 3=Chấm công, 4=Doanh số, 5=Thông tin nhân viên, 6=Khác</summary>
    public int SalaryComponentType { get; set; }

    /// <summary>1=Cố định, 2=Biến đổi, 3=Theo công thức</summary>
    public int Nature { get; set; }

    /// <summary>1=Chịu thuế, 2=Miễn thuế toàn phần, 3=Miễn thuế một phần</summary>
    public int TaxOption { get; set; } = 1;

    /// <summary>1=Tiền tệ, 2=Số, 3=Phần trăm, 4=Chữ</summary>
    public int ValueType { get; set; } = 1;

    public string? Description { get; set; }

    /// <summary>1=Đang theo dõi, 0=Ngừng theo dõi</summary>
    public int Status { get; set; } = 1;
}
