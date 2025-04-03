namespace API_LLM.Services.Interfaces.Carros
{
    public interface ICarrosInterface
    {
        Task<string> GetCarrosPorMarcaAsync(string marca);
    }
}
