using System.Collections.ObjectModel;
using Alura.Adopet.Console.Modelo;

namespace Alura.Adopet.Console.Utilitarios;

public class LeitorDeArquivos
{
    private readonly string? caminhoDoArquivoASerLido;

    public LeitorDeArquivos(string? caminhoDoArquivoASerLido)
    {
        this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
    }

    public virtual List<Pet> RealizarLeitura()
    {
        if (string.IsNullOrEmpty(caminhoDoArquivoASerLido))
            return null;

        var pets = new List<Pet>();

        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
        {
            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
               var pet = sr.ReadLine()?.ConverteDoTexto();
                pets.Add(pet);
            }

            return pets;
        }
    }
}