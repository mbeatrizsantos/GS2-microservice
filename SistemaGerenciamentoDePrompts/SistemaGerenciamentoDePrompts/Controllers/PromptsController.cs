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
            try
            {
                var prompts = await _promptService.GetAllPromptsAsync();
                return Ok(prompts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var prompt = await _promptService.GetByIdAsync(id);
                if (prompt == null)
                {
                    return NotFound($"Prompt com id {id} não encontrado.");
                }
                return Ok(prompt);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Prompt newPrompt)
        {
            try
            {
                newPrompt.DataCriacao = DateTime.Now;
                var newId = await _promptService.CreatePromptAsync(newPrompt);

                return CreatedAtAction(nameof(GetById), new { id = newId }, newPrompt);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}