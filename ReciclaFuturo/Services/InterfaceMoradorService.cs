using ReciclaFuturo.Models;
using System.Collections.Generic;

namespace ReciclaFuturo.Services
{
    public interface InterfaceMoradorService
    {
            List<MoradorModel> GetAllMoradores();
            MoradorModel? GetMoradorById(int id);
            void CreateMorador(MoradorModel morador);
        }
    }


