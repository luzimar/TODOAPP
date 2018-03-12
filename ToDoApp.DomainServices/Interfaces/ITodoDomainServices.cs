using System.Collections.Generic;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;

namespace ToDoApp.DomainServices.Interfaces
{
    public interface ITodoDomainServices
    {
        Todo Create(Todo todo);
        IEnumerable<Todo> List(TodoFilter filter);
        Todo GetById(int id);
        bool Update(Todo todo);
        bool Delete(int id);
    }
}
