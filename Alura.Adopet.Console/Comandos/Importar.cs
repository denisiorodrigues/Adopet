using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Utilitarios;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Importar : IComando
{
    private readonly HttpClientPet _client;

    public Importar()
    {
        _client = new  HttpClientPet();
    }
    
    public async Task ExecutarAsync(string[] args)
    {
        await this.ArquivoPetAsync(args[1].Trim());
    }

    private async Task ArquivoPetAsync(string caminhoDoArquivoParaImportacao)
    {
        System.Console.WriteLine("----- Dados importados -----");
        var leitorDeArquivos = new LeitorDeArquivos();
        var listDePets = leitorDeArquivos.RealizarLeitura(caminhoDoArquivoParaImportacao);

        foreach (Pet pet in listDePets)
        {
            System.Console.WriteLine(pet);
            try
            {
                var resposta = await _client.CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        System.Console.WriteLine("Importação concluída!");
    }
}