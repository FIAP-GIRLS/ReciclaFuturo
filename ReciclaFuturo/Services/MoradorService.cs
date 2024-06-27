using ReciclaFuturo.Data.Contexts;
using ReciclaFuturo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ReciclaFuturo.Services
{
    public class MoradorService : InterfaceMoradorService
    {
        private readonly DatabaseContext _context;

        public MoradorService(DatabaseContext context)
        {
            _context = context;
        }

        public List<MoradorModel> GetAllMoradores()
        {
            return _context.Morador.Include(m => m.Endereco).ToList();
        }

        public MoradorModel? GetMoradorById(int id)
        {
            return _context.Morador.Include(m => m.Endereco).FirstOrDefault(m => m.MoradorId == id);
        }

        public void CreateMorador(MoradorModel morador)
        {
            _context.Morador.Add(morador);
            _context.SaveChanges();
        }
    }
}
