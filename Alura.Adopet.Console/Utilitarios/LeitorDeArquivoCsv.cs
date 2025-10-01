using Alura.Adopet.Console.Abstracoes;
using Alura.Adopet.Console.Modelo;

namespace Alura.Adopet.Console.Utilitarios;

public class LeitorDeArquivoCsv : ILeitorDeArquivo
{
    private readonly string? caminhoDoArquivoASerLido;

    public LeitorDeArquivoCsv(string? caminhoDoArquivoASerLido)
    {
        this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
    }

    public virtual IEnumerable<Pet> RealizarLeitura()
    {
        if (string.IsNullOrEmpty(caminhoDoArquivoASerLido))
            return null;

        var pets = new List<Pet>();

        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
        {
            while (!sr.EndOfStream)
            {
               var pet = sr.ReadLine()?.ConverteDoTexto();
                pets.Add(pet);
            }

            return pets;
        }
    }
}