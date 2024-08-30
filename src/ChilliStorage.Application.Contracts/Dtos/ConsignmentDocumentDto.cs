using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.TenantManagement;

namespace ChilliStorage.Dtos;

public class ConsignmentDocumentDto: EntityDto<Guid>
{
    public string ConsignmentNumber { get; set; } = null!;
    public string Document { get; set; } = null!;
    public DateTime CapturedDate { get; set; }
    public Guid SupplierId { get; set; }
    //public TenantDto Supplier { get; set; } = null!;
}