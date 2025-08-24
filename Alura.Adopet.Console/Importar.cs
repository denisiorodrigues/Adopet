using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Alura.Adopet.Console;

[DocComando(comando: "import", instrucao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Importar
{
    private HttpClient client;

    public Importar()
    {
        client = ConfiguraHttpClient("http://localhost:5057");
    }

    public async Task ArquivoPetAsync(string caminhoDoArquivoParaImportacao)
    {
        System.Console.WriteLine("----- Dados importados -----");
        var leitorDeArquivos = new LeitorDeArquivos();
        var listDePets = leitorDeArquivos.RealizarLeitura(caminhoDoArquivoParaImportacao);

        foreach (var pet in listDePets)
        {
            System.Console.WriteLine(pet);
            try
            {
                var resposta = await CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        System.Console.WriteLine("Importação concluída!");
    }

    Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }
    }

    HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }
}