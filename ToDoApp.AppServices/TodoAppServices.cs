using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.AppServices.Dtos;
using ToDoApp.AppServices.Interfaces;
using ToDoApp.DomainServices.Interfaces;
using ToDoApp.AppServices.Extensions;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;

namespace ToDoApp.AppServices
{
    internal class TodoAppServices : ITodoAppServices
    {
        private readonly ITodoDomainServices domainServices;

        public TodoAppServices(ITodoDomainServices domainServices)
        {
            this.domainServices = domainServices;
        }
        public TodoDto Create(TodoDto todo)
        {
            var result = domainServices.Create(todo.MapTo<Todo>());
            return result.MapTo<TodoDto>();
        }

        public bool Delete(int id) => domainServices.Delete(id);

        public TodoDto GetById(int id)
        {
            var result = domainServices.GetById(id);
            return result.MapTo<TodoDto>();
        }

        public IEnumerable<TodoDto> List(TodoFilterDto filter)
        {
            var result = domainServices.List(filter.MapTo<TodoFilter>());
            return result.EnumerableTo<TodoDto>();
        }

        public bool Update(TodoDto todo) => domainServices.Update(todo.MapTo<Todo>());
       
    }
}
