using System;
using System.Collections.Generic;
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
        var documentBuffer = Convert.FromBase64String(consignmentDocumentDto.Document);
        var consignmentEntity = new ConsignmentDocument
        {
            SupplierId = consignmentDocumentDto.SupplierId,
            ConsignmentNumber = consignmentDocumentDto.ConsignmentNumber,
            CapturedDate = DateTime.Now,
            Document = documentBuffer
        };
        await _consignmentDocumentRepository.InsertAsync(consignmentEntity);
    }

    public async Task<List<ConsignmentDocumentDto>> GetSupplierConsignmentDocumentsAsync(Guid supplierId)
    {
        var consignmentDocumentEntities = await _consignmentDocumentRepository
            .GetListAsync(x => x.SupplierId == supplierId);

        return ObjectMapper.Map<List<ConsignmentDocument>, List<ConsignmentDocumentDto>>(consignmentDocumentEntities);
    }

    public async Task<List<ConsignmentDocumentDto>> GetAllAsync()
    {
        var consignmentDocumentEntities = await _consignmentDocumentRepository
            .GetListAsync();

        return ObjectMapper.Map<List<ConsignmentDocument>, List<ConsignmentDocumentDto>>(consignmentDocumentEntities);
    }

    public async Task<byte[]> GetDownloadConsignmentDocumentAsync(string consignmentNumber)
    {
        var consignmentDocument =
            await _consignmentDocumentRepository.FirstAsync(x => x.ConsignmentNumber == consignmentNumber);
        return consignmentDocument.Document;
    }
}