using ChilliStorage.Dtos;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ChilliStorage.Interfaces;

public interface IDocumentConsignmentService: IApplicationService
{
    Task CreateAsync(ConsignmentDocumentDto consignmentDocumentDto);
    Task<List<ConsignmentDocumentDto>> GetSupplierConsignmentDocumentsAsync();
    Task<string> GetDownloadConsignmentDocumentAsync(string consignmentNumber);
}