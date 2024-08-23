using System;
using System.Threading.Tasks;
using ChilliStorage.Data.Entities;
using ChilliStorage.Dtos;
using ChilliStorage.Interfaces;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ChilliStorage.ConsignmentDocumentAppService;

public class DocumentConsignmentService : ApplicationService, IDocumentConsignmentService
{
    private readonly IRepository<ConsignmentDocument, Guid> _consignmentDocumentRepository;

    public DocumentConsignmentService(IRepository<ConsignmentDocument, Guid> consignmentDocumentRepository)
    {
        _consignmentDocumentRepository = consignmentDocumentRepository ??
                                         throw new ArgumentNullException(nameof(consignmentDocumentRepository));
    }

    public async Task CreateAsync(ConsignmentDocumentDto consignmentDocumentDto)
    {
        var consignmentEntity = ObjectMapper.Map<ConsignmentDocumentDto, ConsignmentDocument>(consignmentDocumentDto);
        await _consignmentDocumentRepository.InsertAsync(consignmentEntity);
    }
}