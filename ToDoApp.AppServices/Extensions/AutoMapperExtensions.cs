using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.AppServices.Extensions
{
    internal static class AutoMapperExtensions
    {
        //Método inline baseado no C#6
        public static T MapTo<T>(this object value) => AutoMapper.Mapper.Map<T>(value);

        public static IEnumerable<T> EnumerableTo<T>(this object value) => AutoMapper.Mapper.Map<IEnumerable<T>>(value);


    }
}
