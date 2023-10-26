using AutoMapper;

namespace Infracstructures.Mappers
{
    public partial class MapperConfigs : Profile
    {
        public MapperConfigs() {

            UserMapperConfigs();
            
        }
    }
}
