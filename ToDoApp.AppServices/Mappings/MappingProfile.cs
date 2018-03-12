using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.AppServices.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Dtos.TodoDto, Domain.Entities.Todo>().ReverseMap();
            CreateMap<Dtos.TodoFilterDto, Domain.Filters.TodoFilter>().ReverseMap();

        }
    }
}
