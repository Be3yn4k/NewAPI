using BackendApi.Contracts.Users;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public Book_notesContext Context { get; }

        public UsersController(Book_notesContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех записей пользователей 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<User> user = Context.Users.ToList();
            return Ok(user);
        }

        /// <summary>
        /// Получение записи пользователя по id
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
            User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(user);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         "roleId": 1,
        ///         "username": "Bebrik",
        ///         "email": "Bebrik@gmail.com",
        ///         "password": "12345",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateUserRequest request) //добавление записей 
        {
            var user = request.Adapt<User>();

            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "roleId": 1,
        ///         "username": "Bebrik",
        ///         "email": "Bebrik@gmail.com",
        ///         "password": "12345",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateUserRequest request) // Изменение существующей записи
        {
            var user = request.Adapt<User>();
            Context.Users.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }

        /// <summary>
        /// Удаление данных пользователя по id
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
            User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }
}
