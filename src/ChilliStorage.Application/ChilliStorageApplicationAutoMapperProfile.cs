using AutoMapper;
using ChilliStorage.Data.Entities;
using ChilliStorage.Dtos;

namespace ChilliStorage;

public class ChilliStorageApplicationAutoMapperProfile : Profile
{
    public ChilliStorageApplicationAutoMapperProfile()
    {
        CreateMap<ConsignmentDocument, ConsignmentDocumentDto>();
    }
}
