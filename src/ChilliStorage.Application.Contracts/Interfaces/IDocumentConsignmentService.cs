using ChilliStorage.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ChilliStorage.Interfaces;

public interface IDocumentConsignmentService: IApplicationService
{
    Task CreateAsync(ConsignmentDocumentDto consignmentDocumentDto);
}