using BackendApi.Contracts.Rating;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        public Book_notesContext Context { get; }

        public RatingController(Book_notesContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех рейтингов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Rating> rating = Context.Ratings.ToList();
            return Ok(rating);
        }

        /// <summary>
        /// Получения рейтинга по id
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
            Rating? rating = Context.Ratings.Where(x => x.Id == id).FirstOrDefault();
            if (rating == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(rating);
        }

        /// <summary>
        /// Добавление нового рейтинга
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "bookId": 1,
        ///         "usersId": 1,
        ///         "number": 5,
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="Rating"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateRatingRequest request) // Создание одной записи
        {
            var rating = request.Adapt<Rating>();
            Context.Ratings.Add(rating);
            Context.SaveChanges();
            return Ok(rating);
        }

        /// <summary>
        /// Обновление рейтинга
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "bookId": 1,
        ///         "usersId": 1,
        ///         "number": 5,
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="Rating"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateRatingRequest request) // Изменение существующей записи
        {
            var rating = request.Adapt<Rating>();
            Context.Ratings.Update(rating);
            Context.SaveChanges();
            return Ok(rating);
        }

        /// <summary>
        /// Удаление рейтинга по id
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
            Rating? rating = Context.Ratings.Where(x => x.Id == id).FirstOrDefault();
            if (rating == null)
            {
                return BadRequest("Not Found");
            }
            Context.Ratings.Remove(rating);
            Context.SaveChanges();
            return Ok(rating);
        }
    }
}
