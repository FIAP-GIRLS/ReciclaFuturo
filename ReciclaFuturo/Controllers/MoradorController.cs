using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReciclaFuturo.Data.Contexts;
using ReciclaFuturo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReciclaFuturo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoradorController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<MoradorController> _logger;

        public MoradorController(DatabaseContext context, ILogger<MoradorController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoradorModel>>> GetMoradores()
        {
            return await _context.Morador.Include(m => m.Endereco).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoradorModel>> GetMorador(int id)
        {
            var morador = await _context.Morador.Include(m => m.Endereco).FirstOrDefaultAsync(m => m.MoradorId == id);

            if (morador == null)
            {
                return NotFound();
            }

            return morador;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMorador([FromBody] MoradorModel morador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (morador.Endereco == null)
            {
                return BadRequest("Endereço não pode ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(morador.Endereco.NomeEndereco))
            {
                return BadRequest("Nome do Endereço é obrigatório.");
            }

            await _context.Morador.AddAsync(morador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMorador), new { id = morador.MoradorId }, morador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMorador(int id, [FromBody] MoradorModel morador)
        {
            if (morador == null)
            {
                return BadRequest("Os dados do morador são obrigatórios.");
            }

            if (id != morador.MoradorId)
            {
                return BadRequest("O ID fornecido não corresponde ao ID do morador.");
            }

            var moradorExistente = await _context.Morador.Include(m => m.Endereco).FirstOrDefaultAsync(m => m.MoradorId == id);
            if (moradorExistente == null)
            {
                return NotFound();
            }

            moradorExistente.Nome = morador.Nome;
            moradorExistente.Cpf = morador.Cpf;
            moradorExistente.Email = morador.Email;
            moradorExistente.Senha = morador.Senha;
            moradorExistente.ContatoNr = morador.ContatoNr;

            if (moradorExistente.Endereco != null)
            {
                moradorExistente.Endereco.NomeEndereco = morador.Endereco.NomeEndereco;
                moradorExistente.Endereco.NumeroEndereco = morador.Endereco.NumeroEndereco;
                moradorExistente.Endereco.Bairro = morador.Endereco.Bairro;
                moradorExistente.Endereco.Cep = morador.Endereco.Cep;
                moradorExistente.Endereco.Cidade = morador.Endereco.Cidade;
                moradorExistente.Endereco.Estado = morador.Endereco.Estado;
            }
            else
            {
                moradorExistente.Endereco = morador.Endereco;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }





        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMorador(int id)
        {
            var morador = await _context.Morador.FindAsync(id);
            if (morador == null)
            {
                return NotFound();
            }

            _context.Morador.Remove(morador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoradorExists(int id)
        {
            return _context.Morador.Any(e => e.MoradorId == id);
        }
    }
}
