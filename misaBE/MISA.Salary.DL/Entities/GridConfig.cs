using MISA.Salary.DL.Entities.Base;

namespace MISA.Salary.DL.Entities;

public class GridConfig : BaseEntity
{
    public Guid GridConfigId { get; set; }
    public string GridId { get; set; } = string.Empty;
    public string ColumnName { get; set; } = string.Empty;
    public string ColumnTitle { get; set; } = string.Empty;
    public int Width { get; set; } = 120;
    public bool Visible { get; set; } = true;
    public bool Pinned { get; set; } = false;
    public int OrderIndex { get; set; }
    public string? UserId { get; set; }
}
