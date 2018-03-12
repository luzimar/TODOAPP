using System.Collections.Generic;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;
using ToDoApp.Domain.Repositories;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.DomainServices
{
    internal class TodoDomainServices : ITodoDomainServices
    {
        private readonly ITodoRepository repository;

        public TodoDomainServices(ITodoRepository repository)
        {
            this.repository = repository;
        }

        public Todo Create(Todo todo) => repository.Create(todo);

        public bool Delete(int id) => repository.Delete(id);


        public Todo GetById(int id) => repository.GetById(id);

        public IEnumerable<Todo> List(TodoFilter filter) => repository.List(filter);

        public bool Update(Todo todo) => repository.Update(todo);

    }
}
