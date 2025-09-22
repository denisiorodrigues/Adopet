using Alura.Adopet.Console.Utilitarios;
using FluentResults;

namespace Alura.Adopet.Console.Utilitariosç
{
    public static class ConsoleUI
    {
        public static void ExibeResultadoNaTela(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            try
            {
                if (result.IsFailed)
                {
                    ExibeFalha(result);
                }
                else
                {
                    ExibeSucesso(result);
                }
            }
            finally
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ExibeSucesso(Result result)
        {
            var sucesso = result.Successes.First();

            switch (sucesso)
            {
                case SucessoComPet sucessoComPet:
                    ExibirPets(sucessoComPet);
                    break;
                case SucessoComDocumentacao sucessoComDocumentacao:
                    ExibirDocumentacoSistema(sucessoComDocumentacao);
                    break;
                default:
                    break;
            }
        }

        private static void ExibirDocumentacoSistema(SucessoComDocumentacao sucessoComDocumentacao)
        {
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: \n");

            foreach (var doc in sucessoComDocumentacao.Documentacoes)
            {
                System.Console.WriteLine("\t"+ doc);
            }

            System.Console.WriteLine("\n");
        }

        private static void ExibirPets(SucessoComPet sucessoComPet)
        {
            foreach (var pet in sucessoComPet.Data)
            {
                System.Console.WriteLine(pet);
            }

            System.Console.WriteLine(sucessoComPet.Message);
        }

        private static void ExibeFalha(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            var mensageDeErro = result.Errors.First();
            System.Console.WriteLine($"Aconteceu um exceção: {mensageDeErro.Message}");
        }
    }
}
