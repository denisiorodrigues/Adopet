using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Console.Comandos;

public class ComandosDoSistema
{
    private HttpClientPet httpClientPet;
    private Importar importar;
    private Listar listar;
    private IDictionary<string, IComando> comandos;
    public ComandosDoSistema()
    {
        httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
        comandos = new Dictionary<string, IComando>()
        {
            {"import", new Importar(httpClientPet)},
            {"help", new Ajuda()},
            {"show", new Exibir()},
            {"list", new Listar(httpClientPet)},
        };
    }
    
    public IComando? this[string comando] => comandos.ContainsKey(comando) ? comandos[comando] : null;
}