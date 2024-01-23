using BackendApi.Contracts.Genre;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public Book_notesContext Context { get; }

        public GenreController(Book_notesContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех жанров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Genre> genre = Context.Genres.ToList();
            return Ok(genre);
        }

        /// <summary>
        /// Получение жанра по id
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
            Genre? genre = Context.Genres.Where(x => x.Id == id).FirstOrDefault();
            if (genre == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(genre);
        }

        /// <summary>
        /// Добавление жанра
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "genreName": "Horror"
        ///     }
        ///
        /// </remarks>
        /// <param name="Genre"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateGenreRequest request) // Создание одной записи
        {
            var genre = request.Adapt<Genre>();
            Context.Genres.Add(genre);
            Context.SaveChanges();
            return Ok(genre);
        }

        /// <summary>
        /// Обновление существующего жанра
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "genreName": "Horror"
        ///     }
        ///
        /// </remarks>
        /// <param name="Genre"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateGenreRequest request) // Изменение существующей записи
        {
            var genre = request.Adapt<Genre>();
            Context.Genres.Update(genre);
            Context.SaveChanges();
            return Ok(genre);
        }

        /// <summary>
        /// Удаление жанра по id
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
            Genre? genre = Context.Genres.Where(x => x.Id == id).FirstOrDefault();
            if (genre == null)
            {
                return BadRequest("Not Found");
            }
            Context.Genres.Remove(genre);
            Context.SaveChanges();
            return Ok(genre);
        }
    }
}
