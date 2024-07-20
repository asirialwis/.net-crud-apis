using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class  CommentController:ControllerBase
    {
        private ICommentRepository _commentRepo;

        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo; 
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var comment = await _commentRepo.GetAllAsync();
            var commentDto = comment.Select(s=>s.ToCommentDto());

            return Ok(commentDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if(comment == null)
            {
                return NotFound();
            }
            var commentDto = comment.ToCommentDto();
            return Ok(commentDto);
        }
        
    }
}