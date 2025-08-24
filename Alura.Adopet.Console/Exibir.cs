namespace Alura.Adopet.Console;

public class Exibir
{
    public void ItensDoArquivo(string caminhoDoArquivoASerExibido)
    {
        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerExibido))
        {
            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            var leitorDeArquivos =  new LeitorDeArquivos();
            var pets = leitorDeArquivos.RealizarLeitura(caminhoDoArquivoASerExibido);
            foreach (var pet in pets) 
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}