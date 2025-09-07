using System.Collections.ObjectModel;
using Alura.Adopet.Console.Modelo;

namespace Alura.Adopet.Console.Utilitarios;

public class LeitorDeArquivos
{
    public ICollection<Pet> RealizarLeitura(string? caminhoDoArquivoASerLido)
    {
        var pets = new Collection<Pet>();

        if(string.IsNullOrEmpty(caminhoDoArquivoASerLido))
            return null;
        
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