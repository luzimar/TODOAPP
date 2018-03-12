using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;
using ToDoApp.Domain.Repositories;
using Dapper;

namespace ToDoApp.Data.Repositories
{
    internal class TodoRepository : RepositoryBase, ITodoRepository
    {
        public TodoRepository(IConfigurationRoot configuration) : base(configuration)
        {

        }

        public Todo Create(Todo todo)
        {
            //Usando o Dapper para comunicacao com o banco
            todo.Id = connection.QueryFirst<int>("exec todo_sp_create @Text, @IsCompleted", todo);
            return todo;
        }

        public bool Delete(int id)
        {
            //Usando o Dapper para comunicacao com o banco
            var affectedRows = connection.Execute("exec todo_sp_delete @Id", new { Id = id });
            return affectedRows > 0;
        }

        public Todo GetById(int id)
        {
            //Usando o Dapper para comunicacao com o banco
            var todo = connection.QueryFirstOrDefault<Todo>("exec todo_sp_get @Id", new { Id = id });
            return todo;
        }

        public IEnumerable<Todo> List(TodoFilter filter)
        {
            //Usando o Dapper para comunicacao com o banco
            var todos = connection.Query<Todo>("exec todo_sp_list @Id, @Text, @IsCompleted", filter);
            return todos;
        }

        public bool Update(Todo todo)
        {
            var affectedRows = connection.Execute("exec todo_sp_update @Id, @Text, @IsCompleted", todo);
            return affectedRows > 0;
        }
    }
}
