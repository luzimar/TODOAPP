using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize((configuration) =>
            {
                configuration.AddProfiles(IoC.AutoMapperConfiguration.GetAutoMapperProfiles());
            });
        }
    }
}
