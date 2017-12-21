using AutoMapper;
using InfoNovitas.LoginSample.Services.Messaging.Views.Users;

namespace InfoNovitas.LoginSample.Services
{
    public class AutoMapperBootstrapper
    {
        public static void CreateMap()
        {

           Mapper.CreateMap<UserInfo, Model.Users.UserInfo>();
           Mapper.CreateMap<Model.Users.UserInfo, UserInfo>();

           Mapper.AssertConfigurationIsValid();
        }
    }
}
