using Alura.Adopet.Console.Modelo;

namespace Alura.Adopet.Console.Abstracoes;

public interface IApiService
{
    Task CreateAsync(Pet pet);
    Task<IEnumerable<Pet>?> ListAsync();
}
