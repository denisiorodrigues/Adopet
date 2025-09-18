using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Modelo;
using Alura.Adopet.Console.Utilitarios;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Importar : IComando
{
    private readonly HttpClientPet _client;
    private readonly LeitorDeArquivos _leitorDeArquivos;

    public Importar(HttpClientPet client, LeitorDeArquivos leitorDeArquivos)
    {
        _client = client;
        _leitorDeArquivos = leitorDeArquivos;
    }

    public async Task<Result> ExecutarAsync(string[] args)
    {
        return await this.ArquivoPetAsync();
    }

    private async Task<Result> ArquivoPetAsync()
    {
        System.Console.WriteLine("----- Dados importados -----");
        var listDePets = _leitorDeArquivos.RealizarLeitura();

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
        return Result.Ok();
    }
}