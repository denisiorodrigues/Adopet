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
                default:
                    break;
            }
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
