using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Models;
using Swashbuckle.AspNetCore.Annotations;



namespace QuizAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class QuizAnswerController : ControllerBase
    {
        private IQuizService _quizService;

        public QuizAnswerController(IQuizService quizService)
        {
            _quizService = quizService;
        }


        
        [EnableCors]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(QuizSolution))]
        public IActionResult PostAnswer(QuizAnswer quizAnswer)
        {
            return Ok(_quizService.EvaluateQuizAnswer(quizAnswer));
        }
    }

}