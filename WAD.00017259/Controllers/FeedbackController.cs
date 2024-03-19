using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00017259.DAL.DTOs;
using WAD._00017259.DAL.Interfaces;
using WAD._00017259.Models;

namespace WAD._00017259.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackController(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        [HttpGet("product/{productId}")]
        public IActionResult GetFeedbackByProductId(int productId)
        {
            var feedbacks = _feedbackRepository.GetAllByProductId(productId);
            var feedbackDTOs = _mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks);
            return Ok(feedbackDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetFeedback(int id)
        {
            var feedback = _feedbackRepository.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            var feedbackDTO = _mapper.Map<FeedbackDTO>(feedback);
            return Ok(feedbackDTO);
        }

        [HttpPost]
        public IActionResult CreateFeedback(FeedbackDTO feedbackDTO)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDTO);
            _feedbackRepository.Add(feedback);
            return CreatedAtAction(nameof(GetFeedback), new { id = feedback.Id }, feedbackDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFeedback(int id, FeedbackDTO feedbackDTO)
        {
            var feedback = _feedbackRepository.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _mapper.Map(feedbackDTO, feedback);
            _feedbackRepository.Update(feedback);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeedback(int id)
        {
            var feedback = _feedbackRepository.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _feedbackRepository.Delete(feedback);
            return NoContent();
        }
    }
}
