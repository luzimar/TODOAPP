using System.Collections.Generic;
using ToDoApp.AppServices.Dtos;

namespace ToDoApp.AppServices.Interfaces
{
    public interface ITodoAppServices
    {
        TodoDto Create(TodoDto todo);
        IEnumerable<TodoDto> List(TodoFilterDto filter);
        TodoDto GetById(int id);
        bool Update(TodoDto todo);
        bool Delete(int id);
    }
}
