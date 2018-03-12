using System;
using System.Collections.Generic;
using ToDoApp.Data.Repositories;
using ToDoApp.Domain.Repositories;

namespace ToDoApp.Data.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>();
            dictionary.Add(typeof(ITodoRepository), typeof(TodoRepository));
            return dictionary;
        }
    }
}
