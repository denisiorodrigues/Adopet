using Alura.Adopet.Console.Modelo;

namespace Alura.Adopet.Console.Abstracoes;

public interface ILeitorDeArquivo
{
    IEnumerable<Pet> RealizarLeitura();
}
