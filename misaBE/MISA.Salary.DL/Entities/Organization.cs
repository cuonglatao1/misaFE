using MISA.Salary.DL.Entities.Base;

namespace MISA.Salary.DL.Entities;

public class Organization : BaseEntity
{
    public Guid OrganizationId { get; set; }
    public string OrganizationCode { get; set; } = string.Empty;
    public string OrganizationName { get; set; } = string.Empty;
    public Guid? ParentId { get; set; }
    public int Status { get; set; } = 1;
}
