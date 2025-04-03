using API_LLM.Data;
using API_LLM.Services.Interfaces.Carros;
using Microsoft.EntityFrameworkCore;

namespace API_LLM.Services.Carros
{
    public class CarroService: ICarrosInterface
    {
        private readonly ApplicationDbContext _context;

        public CarroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetCarrosPorMarcaAsync(string marca)
        {
            var carros = await _context.Carros
                .Where(c => c.Marca.ToLower() == marca.ToLower())
                .ToListAsync();

            if (!carros.Any())
                return $"Nenhum carro encontrado para a marca {marca}";

            var resposta = $"Encontrei {carros.Count} carro(s) da marca {marca}:\n";
            foreach (var carro in carros)
            {
                resposta += $"- Modelo: {carro.Modelo}, Valor: R$ {carro.Valor}\n";
            }

            return resposta;
        }
    }
}
