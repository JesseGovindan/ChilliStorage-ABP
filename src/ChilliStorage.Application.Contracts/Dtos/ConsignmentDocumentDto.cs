using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.TenantManagement;

namespace ChilliStorage.Dtos;

public class ConsignmentDocumentDto: EntityDto<Guid>
{
    public string ConsignmentNumber { get; set; } = null!;
    public byte[] Document { get; set; } = [0x41, 0x42, 0x43, 0x44];
    public DateTime CapturedDate { get; set; }
    public Guid SupplierId { get; set; }
    public TenantDto Supplier { get; set; } = null!;
}