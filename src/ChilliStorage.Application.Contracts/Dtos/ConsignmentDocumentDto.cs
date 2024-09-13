using System;
using Volo.Abp.Application.Dtos;
namespace ChilliStorage.Dtos;

public class ConsignmentDocumentDto: EntityDto<Guid>
{
    public string ConsignmentNumber { get; set; } = null!;
    public string Document { get; set; } = null!;
    public DateTime CapturedDate { get; set; }
    public Guid SupplierId { get; set; }
}