using BackendApi.Contracts.Book_status;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Book_statusController : ControllerBase
    {
        public Book_notesContext Context { get; }

        public Book_statusController(Book_notesContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех статусов книг
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<BookStatus> status = Context.BookStatuses.ToList();
            return Ok(status);
        }

        /// <summary>
        /// Получение статуса книги по id
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
            BookStatus? status = Context.BookStatuses.Where(x => x.Id == id).FirstOrDefault();
            if (status == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(status);
        }

        /// <summary>
        /// Добавление статуса книги
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "statusName": "Читаю сейчас"
        ///     }
        ///
        /// </remarks>
        /// <param name="Book_status"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateBook_statusRequest request) // Создание одной записи
        {
            var status = request.Adapt<BookStatus>();
            Context.BookStatuses.Add(status);
            Context.SaveChanges();
            return Ok(status);
        }

        /// <summary>
        /// Обновление существующего статуса книги
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "roleName": "Owner"
        ///     }
        ///
        /// </remarks>
        /// <param name="Book_status"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateBook_statusRequest request) // Изменение существующей записи
        {
            var status = request.Adapt<BookStatus>();
            if (status == null)
            {
                return BadRequest("Not Found");
            }
            Context.BookStatuses.Update(status);
            Context.SaveChanges();
            return Ok(status);
        }

        /// <summary>
        /// Удаление статуса книги по id
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
            BookStatus? status = Context.BookStatuses.Where(x => x.Id == id).FirstOrDefault();
            if (status == null)
            {
                return BadRequest("Not Found");
            }
            Context.BookStatuses.Remove(status);
            Context.SaveChanges();
            return Ok(status);
        }
    }
}
