using BackendApi.Contracts.Comment;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public Book_notesContext Context { get; }

        public CommentController(Book_notesContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех комментариев
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Comment> comment = Context.Comments.ToList();
            return Ok(comment);
        }

        /// <summary>
        /// Получение комментария
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
            Comment? comment = Context.Comments.Where(x => x.Id == id).FirstOrDefault();
            if (comment == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(comment);
        }

        /// <summary>
        /// Создание нового комментария
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "bookId": 1,
        ///         "userId": 1,
        ///         "commentText": "Хорошая книга",
        ///         "commentDate": "2024-01-21T18:57:41.342Z",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="Comment"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateCommentRequest request) // Создание одной записи
        {
            var comment = request.Adapt<Comment>();
            Context.Comments.Add(comment);
            Context.SaveChanges();
            return Ok(comment);
        }

        /// <summary>
        /// Обновление данных комментария
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "bookId": 1,
        ///         "userId": 1,
        ///         "commentText": "Хорошая книга",
        ///         "commentDate": "2024-01-21T18:57:41.342Z",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="Comment"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateCommentRequest request) // Изменение существующей записи
        {
            var comment = request.Adapt<Comment>();
            Context.Comments.Update(comment);
            Context.SaveChanges();
            return Ok(comment);
        }

        /// <summary>
        /// Удаление комментария по id
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
            Comment? comment = Context.Comments.Where(x => x.Id == id).FirstOrDefault();
            if (comment == null)
            {
                return BadRequest("Not Found");
            }
            Context.Comments.Remove(comment);
            Context.SaveChanges();
            return Ok(comment);
        }
    }
}
