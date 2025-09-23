using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Console.Comandos;

public class ComandosDoSistema
{
    private HttpClientPet httpClientPet;
    private IDictionary<string, IComando> comandos;
    private LeitorDeArquivos leitorDeArquivos;

    public ComandosDoSistema(string[] args)
    {
        httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
        leitorDeArquivos = args.Length == 2 ? new LeitorDeArquivos(args[1]) : null;

        comandos = new Dictionary<string, IComando>()
        {
            {"import", new Importar(httpClientPet, leitorDeArquivos)},
            {"help", new Ajuda(comandoASerExibido: args[1])},
            {"show", new Exibir(leitorDeArquivos)},
            {"list", new Listar(httpClientPet)},
        };
    }
    
    public IComando? this[string comando] => comandos.ContainsKey(comando) ? comandos[comando] : null;
}