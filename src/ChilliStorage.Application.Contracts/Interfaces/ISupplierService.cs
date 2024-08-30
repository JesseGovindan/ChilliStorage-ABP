using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.TenantManagement;

namespace ChilliStorage.Interfaces;

public interface ISupplierService : IApplicationService
{
    Task<List<TenantDto>> GetAllSuppliers();
}