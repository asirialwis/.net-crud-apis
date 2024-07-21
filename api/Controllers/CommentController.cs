using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class  CommentController:ControllerBase
    {
        private ICommentRepository _commentRepo;
        private IStockRepository _stockRepo;

        public CommentController(ICommentRepository commentRepo , IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
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
        [HttpPost("stockId")]
        public async Task<IActionResult> Create([FromRoute] int stockId , CreateCommentDto commentDto)
        {
            // if (!await _stockRepo.StockExists(stockId))
            // {
            //     return BadRequest("StockDoes Not Exist");   
            // }
            var commentModel = commentDto.ToCommentFromCreate(stockId);
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new {id = commentModel.Id}, commentModel.ToCommentDto());

        }
        
    }
}