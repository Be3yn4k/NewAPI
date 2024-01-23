using BackendApi.Contracts.Book;
using BackendApi.Contracts.Users;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public Book_notesContext Context { get; }

        public BookController(Book_notesContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех записей книг
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Book> book = Context.Books.ToList();
            return Ok(book);
        }

        /// <summary>
        /// Получение записи книги по id
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
            Book? book = Context.Books.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(book);
        }

        /// <summary>
        /// Создание новой записи книги
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         "genreId": 1,
        ///         "bookStatusId": 0,
        ///         "title": "Золотая рыбка",
        ///         "author": "А.С. Пушкин",
        ///         "publicationDate": "1835-00-00",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="Book">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Book book) // Создание одной записи
        {
            Context.Books.Add(book);
            Context.SaveChanges();
            return Ok(book);
        }

        /// <summary>
        /// Изменение существующей записи книги
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         "genreId": 1,
        ///         "bookStatusId": 0,
        ///         "title": "Золотая рыбка",
        ///         "author": "А.С. Пушкин",
        ///         "publicationDate": "1835-00-00",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="Book">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateBookRequest request) // Изменение существующей записи
        {
            var book = request.Adapt<Book>();
            Context.Books.Update(book);
            Context.SaveChanges();
            return Ok(book);
        }

        /// <summary>
        /// Удаление данных о книге по id
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
            Book? book = Context.Books.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
            {
                return BadRequest("Not Found");
            }
            Context.Books.Remove(book);
            Context.SaveChanges();
            return Ok(book);
        }
    }
}
