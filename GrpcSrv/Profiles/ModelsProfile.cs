using AutoMapper;
using GrpcSrv.Models;

namespace GrpcSrv.Profiles;

public class ModelsProfile : Profile
{
    public ModelsProfile()
    {
        CreateMap<Model, GrpcModel>();
    }
}