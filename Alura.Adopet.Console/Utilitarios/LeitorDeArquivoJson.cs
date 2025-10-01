
using Alura.Adopet.Console.Abstracoes;
using Alura.Adopet.Console.Modelo;
using System.Text.Json;

namespace Alura.Adopet.Console.Utilitarios;

public class LeitorDeArquivoJson : ILeitorDeArquivo
{
    private string? caminhoDoArquivoASerLido;
    public LeitorDeArquivoJson(string? caminhoDoArquivoASerLido)
    {
        this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
    }

    public IEnumerable<Pet> RealizarLeitura()
    {
        using var stream = new FileStream(caminhoDoArquivoASerLido, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream)!;
    }
}
