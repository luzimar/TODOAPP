using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.AppServices.Interfaces;

namespace ToDoApp.AppServices.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>();
            dictionary.Add(typeof(ITodoAppServices), typeof(TodoAppServices));
            return dictionary;
        }
    }
}
