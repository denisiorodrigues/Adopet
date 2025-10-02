namespace Alura.Adopet.Console.Abstracoes;

public interface IApiService<T>
{
    Task CreateAsync(T objeto);
    Task<IEnumerable<T>?> ListAsync();
}
