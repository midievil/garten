using AutoMapper;
using Garten.Core.Models.User;
using Garten.Database.Entities;

namespace Garten.Api
{
    /// <summary>
    /// Default app mapping profile
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping settings
        /// </summary>
        public MappingProfile()
        {
            CreateMap<UserEditDto, User>();
            CreateMap<User, UserViewDto>();

        }
    }
}
