using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Console.Comandos;

public static class FabricaDeComandos
{
    public static IComando CriarComando(string[] argumentos)
    {
        if (argumentos is null)
        {
            return null;
        }

        var comando = argumentos[0];
        var segundoComando = argumentos.Length > 1 ? argumentos[1] : null;

        switch (comando)
        {
            case "import":
                var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                LeitorDeArquivoCsv leitorDeArquivos = new(segundoComando);
                return new Importar(httpClientPet, leitorDeArquivos);
            case "list":
                var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                return new Listar(httpClientPetList);
            case "show":
                LeitorDeArquivoCsv leitorDeArquivosShow = new(segundoComando);
                return new Exibir(leitorDeArquivosShow);
            case "help":
                return new Ajuda(segundoComando);
            default: 
                return null;
        }
    }
}
