using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.TenantManagement;

namespace ChilliStorage.Data.Entities;

public class ConsignmentDocument: Entity<Guid>
{
    public string ConsignmentNumber { get; set; } = null!;
    public byte[] Document { get; set; } = null!;
    public DateTime CapturedDate { get; set; }
    public Guid  SupplierId { get; set; }
    public Tenant Supplier { get; set; } = null!;
}