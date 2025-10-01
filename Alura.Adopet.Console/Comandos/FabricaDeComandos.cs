using Alura.Adopet.Console.Abstracoes;
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
        ILeitorDeArquivo leitorDeArquivo;
        switch (comando)
        {
            case "import":
                var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                leitorDeArquivo = FabricaDeLeitorDeArquivo.CriarLeitor(segundoComando);
                if (leitorDeArquivo is null) return null;
                return new Importar(httpClientPet, leitorDeArquivo);

            case "list":
                var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                return new Listar(httpClientPetList);

            case "show":
                leitorDeArquivo = FabricaDeLeitorDeArquivo.CriarLeitor(segundoComando);
                if (leitorDeArquivo is null) return null;
                return new Exibir(leitorDeArquivo);
            
            case "help":
                return new Ajuda(segundoComando);
            
            default: 
                return null;
        }
    }
}
