using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.AppServices.Dtos;
using ToDoApp.AppServices.Interfaces;
using ToDoApp.Extensions;
using ToDoApp.Validators;

//Controller responsável em realizar as operações de CRUD de uma tarefa

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoAppServices appServices;
        private readonly TodoValidator validator;

        public TodoController(ITodoAppServices appServices, Validators.TodoValidator validator)
        {
            this.appServices = appServices;
            this.validator = validator;
        }

        // GET: api/todo
        [HttpGet]
        public Results.GenericResult<IEnumerable<TodoDto>> Get([FromQuery]TodoFilterDto filterDto)
        {
            var result = new Results.GenericResult<IEnumerable<TodoDto>>();
            try
            {
                result.Result = appServices.List(filterDto);
                result.Sucess = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }
            return result;

        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public Results.GenericResult<TodoDto> Get(int id)
        {
            var result = new Results.GenericResult<TodoDto>();
            try
            {
                result.Result = appServices.GetById(id);
                result.Sucess = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }
            return result;
        }

        // POST api/todo
        [HttpPost]
        public Results.GenericResult<TodoDto> Post([FromBody]TodoDto model)
        {
            var result = new Results.GenericResult<TodoDto>();
            var validatorResult = validator.Validate(model);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Result = appServices.Create(model);
                    result.Sucess = true;

                }
                catch (Exception ex)
                {
                    result.Errors = new string[] { ex.Message };
                }
            }
            else
                result.Errors = validatorResult.GetErrors();

            return result;
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public Results.GenericResult Put([FromBody]TodoDto model)
        {
            var result = new Results.GenericResult();
            var validationResul = validator.Validate(model);
            if (validationResul.IsValid)
            {
                try
                {
                    result.Sucess = appServices.Update(model);
                }
                catch (Exception ex)
                {
                    result.Errors = new string[] { ex.Message };
                }
            }
            else
                result.Errors = validationResul.GetErrors();

            return result;
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public Results.GenericResult Delete(int id)
        {
            var result = new Results.GenericResult();
            try
            {
                result.Sucess = appServices.Delete(id);
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }
            return result;
        }
    }
}
