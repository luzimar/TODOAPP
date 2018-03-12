using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.DomainServices.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>();
            dictionary.Add(typeof(ITodoDomainServices), typeof(TodoDomainServices));

            return dictionary;
        }
    }
}
