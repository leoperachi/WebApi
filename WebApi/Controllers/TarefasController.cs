using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Base;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : BaseController<Tarefa>
    {
        private readonly TodoContext _context;

        public TarefasController(TodoContext context)
        {
            _context = context;
        }
        
        [HttpPost("Alterar")]
        public override async Task<ActionResult<Tarefa>> Alterar(Tarefa tarefa)
        {
            if (_context.Tarefas == null)
            {
                return NotFound();
            }

            var result = await _context.Tarefas.SingleAsync(x => x.Id == tarefa.Id);
            if (result != null)
            {
                result.Descricao = tarefa.Descricao;
                result.Progresso = tarefa.Progresso;
                result.DtPrazo = tarefa.DtPrazo;
                _context.SaveChanges();
            }

            return result;
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<Tarefa>> Buscar(int id)
        {
            if (_context.Tarefas == null)
            {
                return NotFound();
            }
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }
        
        [HttpDelete("{id}")]
        public override async Task<IActionResult> Deletar(int id)
        {
            if (_context.Tarefas == null)
            {
                return NotFound();
            }
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Tarefa>>> Listar()
        {
            if (_context.Tarefas == null)
            {
                return NotFound();
            }

            return await _context.Tarefas.ToListAsync();
        }

        [HttpPost("Salvar")]
        public override async Task<ActionResult<Tarefa>> Salvar(Tarefa tarefa)
        {
            if (_context.Tarefas == null)
            {
                return Problem("Entity set 'TodoContext.TodoItems'  is null.");
            }
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        private bool TarefaExists(int id)
        {
            return (_context.Tarefas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
