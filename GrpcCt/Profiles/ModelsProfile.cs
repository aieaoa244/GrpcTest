using AutoMapper;
using GrpcCt.Models;

namespace GrpcCt.Profiles;

public class ModelsProfile : Profile
{
    public ModelsProfile()
    {
        CreateMap<GrpcModel, Model>();
    }
}