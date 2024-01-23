using BackendApi.Contracts.Role;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public Book_notesContext Context { get; }
        
        public RoleController(Book_notesContext context) 
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех ролей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Role> role = Context.Roles.ToList();
            return Ok(role);
        }

        /// <summary>
        /// Получение роли по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         Id": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Получение одной записи
        {
            Role? role = Context.Roles.Where(x => x.Id == id).FirstOrDefault();
            if (role == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(role);
        }

        /// <summary>
        /// Добавление роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "roleName": "Owner"
        ///     }
        ///
        /// </remarks>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateRoleRequest request) // Создание одной записи
        {
            var role = request.Adapt<Role>();
            Context.Roles.Add(role);
            Context.SaveChanges();
            return Ok(role);
        }

        /// <summary>
        /// Обновление существующей роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "roleName": "Owner"
        ///     }
        ///
        /// </remarks>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateRoleRequest request) // Изменение существующей записи
        {
            var role = request.Adapt<Role>();
            if (role == null)
            {
                return BadRequest("Not Found");
            }
            Context.Roles.Update(role);
            Context.SaveChanges();
            return Ok(role);
        }

        /// <summary>
        /// Удаление роли по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         Id": 6
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id) // Удаление существующей записи
        {
            Role? role = Context.Roles.Where(x => x.Id == id).FirstOrDefault();
            if (role == null)
            {
                return BadRequest("Not Found");
            }
            Context.Roles.Remove(role);
            Context.SaveChanges();
            return Ok(role);
        }
    }
}
