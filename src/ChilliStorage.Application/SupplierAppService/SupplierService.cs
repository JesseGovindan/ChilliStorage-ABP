using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChilliStorage.Interfaces;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.TenantManagement;

namespace ChilliStorage.SupplierAppService;

public class SupplierService : ApplicationService, ISupplierService
{
    private readonly IRepository<Tenant, Guid> _tenantRepository;

    public SupplierService(IRepository<Tenant, Guid> tenantRepository)
    {
        _tenantRepository = tenantRepository ?? throw new ArgumentNullException(nameof(tenantRepository));
    }

    public async Task<List<TenantDto>> GetAllSuppliers()
    {
        var suppliers = await _tenantRepository.GetListAsync();
        var results = ObjectMapper.Map<List<Tenant>, List<TenantDto>>(suppliers);
        return results;
    }
}