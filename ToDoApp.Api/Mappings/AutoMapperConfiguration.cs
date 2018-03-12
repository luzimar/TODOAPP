using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Api.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(
                (configuracao) =>
                {
                    configuracao.AddProfiles(IoC.AutoMapperConfiguration.GetAutoMapperProfiles());
                });
        }
    }
}
