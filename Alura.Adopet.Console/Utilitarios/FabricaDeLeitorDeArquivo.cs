using Alura.Adopet.Console.Abstracoes;

namespace Alura.Adopet.Console.Utilitarios;

public class FabricaDeLeitorDeArquivo
{
    public static ILeitorDeArquivo? CriarLeitor(string? caminhoArquivo)
    {
        if (string.IsNullOrEmpty(caminhoArquivo))
        {
            return null;
        }
        var extensao = Path.GetExtension(caminhoArquivo).ToLower();
        return extensao switch
        {
            ".csv" => new LeitorDeArquivoCsv(caminhoArquivo),
            ".json" => new LeitorDeArquivoJson(caminhoArquivo),
            _ => null
        };
    }
}
