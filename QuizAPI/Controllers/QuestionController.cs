using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Models;
using Swashbuckle.AspNetCore.Annotations;
using QuizAPI.Services;



namespace QuizAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class QuestionController : ControllerBase
    {
        private QuestionService _service; 

        public QuestionController(QuestionService service)
        {
            _service = service;
        }


        
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Question>))]
        public IActionResult Get()
        {
            
            return Ok(_service.Get());
        }

        
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Question))]
        public IActionResult Get(Guid id)
        {
            
            var question = _service.Get(id);
            if (question == null)
            {
                return NotFound("Id not found");
            }
            return Ok(question);
        }

        
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Question>))]
        public IActionResult Post([FromBody] Question question) 
        {
            return Ok(_service.Post(question));
        }

        
        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Question>))]
        public IActionResult Put([FromBody] Question question) 
        {
            var questions = _service.Put(question); 

            if (questions == null)
            {
                return NotFound("Question not found");
            }
            return Ok(questions);
        }


        
        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        public IActionResult Delete([FromBody] Question question) 
        {
            var success = _service.Delete(question);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
