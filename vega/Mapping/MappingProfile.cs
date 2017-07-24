using AutoMapper;
using Vega.Controllers.Resources;
using Vega.Models;
namespace Vega.Mapping
{
    public class MappingProfile: Profile{
        public MappingProfile()
        {
            CreateMap<Maker, MakerResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
        }
    }
}