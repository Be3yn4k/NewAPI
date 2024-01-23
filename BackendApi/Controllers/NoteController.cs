using BackendApi.Contracts.Note;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        public Book_notesContext Context { get; }

        public NoteController(Book_notesContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех заметок
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Note> note = Context.Notes.ToList();
            return Ok(note);
        }

        /// <summary>
        /// Получение заметки по id
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
            Note? note = Context.Notes.Where(x => x.Id == id).FirstOrDefault();
            if (note == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(note);
        }

        /// <summary>
        /// Создание заметки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "usersId": 1,
        ///         "booksId": 1,
        ///         "noteText": "...",
        ///         "noteDate": "12345",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="Note"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateNoteRequest request) // Создание одной записи
        {
            var note = request.Adapt<Note>();
            Context.Notes.Add(note);
            Context.SaveChanges();
            return Ok(note);
        }

        /// <summary>
        /// Обновление заметки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "usersId": 1,
        ///         "booksId": 1,
        ///         "noteText": "...",
        ///         "noteDate": "12345",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="Note"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateNoteRequest request) // Изменение существующей записи
        {
            var note = request.Adapt<Note>();
            Context.Notes.Update(note);
            Context.SaveChanges();
            return Ok(note);
        }

        /// <summary>
        /// Удаление заметки по id
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
            Note? note = Context.Notes.Where(x => x.Id == id).FirstOrDefault();
            if (note == null)
            {
                return BadRequest("Not Found");
            }
            Context.Notes.Remove(note);
            Context.SaveChanges();
            return Ok(note);
        }
    }
}
