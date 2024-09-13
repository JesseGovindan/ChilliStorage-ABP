using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChilliStorage.Data.Entities;
using ChilliStorage.Dtos;
using ChilliStorage.Interfaces;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace ChilliStorage.ConsignmentDocumentAppService;

public class DocumentConsignmentService : ApplicationService, IDocumentConsignmentService
{
    private readonly ICurrentTenant _currentTenant;
    private readonly IRepository<ConsignmentDocument, Guid> _consignmentDocumentRepository;

    public DocumentConsignmentService(IRepository<ConsignmentDocument, Guid> consignmentDocumentRepository, ICurrentTenant currentTenant)
    {
        _consignmentDocumentRepository = consignmentDocumentRepository ??
                                         throw new ArgumentNullException(nameof(consignmentDocumentRepository));
        _currentTenant = currentTenant ?? throw new ArgumentNullException(nameof(currentTenant));
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

    public async Task<List<ConsignmentDocumentDto>> GetSupplierConsignmentDocumentsAsync()
    {
        if (_currentTenant.IsAvailable)
        {
            var supplierConsignmentDocumentEntities = await _consignmentDocumentRepository
                .GetListAsync(x => x.SupplierId == _currentTenant.Id);

            return ObjectMapper.Map<List<ConsignmentDocument>, List<ConsignmentDocumentDto>>(supplierConsignmentDocumentEntities);
        }

        var consignmentDocumentEntities = await _consignmentDocumentRepository
            .GetListAsync();
        return ObjectMapper.Map<List<ConsignmentDocument>, List<ConsignmentDocumentDto>>(consignmentDocumentEntities);
    }

    public async Task<string> GetDownloadConsignmentDocumentAsync(string consignmentNumber)
    {
        var consignmentDocument =
            await _consignmentDocumentRepository.FirstAsync(x => x.ConsignmentNumber == consignmentNumber);
        var result = Convert.ToBase64String(consignmentDocument.Document);
        return result;
    }
}