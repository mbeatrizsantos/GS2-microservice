using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaGerenciamentoDePrompts.Models;
using SistemaGerenciamentoDePrompts.Services.Interfaces;

namespace SistemaGerenciamentoDePrompts.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class PromptsController : ControllerBase
    {
        private readonly IPromptService _promptService;

        public PromptsController(IPromptService promptService)
        {
            _promptService = promptService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prompts = await _promptService.GetAllPromptsAsync();
            return Ok(prompts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var prompt = await _promptService.GetPromptByIdAsync(id);
            if (prompt == null)
            {
                return NotFound(); 
            }
            return Ok(prompt);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Prompt newPrompt)
        {
            newPrompt.DataCriacao = DateTime.Now;

            var newId = await _promptService.CreatePromptAsync(newPrompt);

            return CreatedAtAction(nameof(GetById), new { id = newId }, newPrompt);
        }
    }
}