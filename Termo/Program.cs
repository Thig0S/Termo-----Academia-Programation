using System.Security.Cryptography;

namespace Termo;

class Program
{
    static void Main(string[] args)
    {
        ExibirMenu();
        PressioneEnter();
        Console.Clear();

        string palavraTermo = GerarPalavraTermo();
        System.Console.WriteLine(palavraTermo);

        for (int tentativas = 1; tentativas <= 5; tentativas++)
        {
            System.Console.WriteLine($"\nTENTATIVA {tentativas} de 5!");
            System.Console.Write("Digite uma palavra: ");
            string? usuarioInput = Console.ReadLine()?.ToLower();

            if (String.IsNullOrEmpty(usuarioInput) || !VerificarPalavraValida(usuarioInput))
            {
                System.Console.WriteLine("Palavra Inválida! Apenas palavras com 5 letras!");
                PressioneEnter();
                tentativas--;
                continue;
            }

            // verificar se as letras tem na palavra aleatoria do TERMO 
            for (int i = 0; i < palavraTermo.Length; i++)
            {
                //Verificar letra por letra do input do usuario
                if (palavraTermo[i] == usuarioInput[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.Write($"{usuarioInput[i]}");
                    Console.ResetColor();
                }
            }
            for (int i = 0; i < palavraTermo.Length; i++)
            {
                if (palavraTermo.Contains(usuarioInput[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.Write(usuarioInput[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Write(usuarioInput[i]);
                    Console.ResetColor();
                }
            }
        }
    }

    static void ExibirMenu()
    {
        Console.WriteLine("----------------");
        Console.WriteLine("Bem-vindo ao Termo TK");
        Console.WriteLine("----------------");
    }
    static string GerarPalavraTermo()
    {
        string[] palavras = {
                "amigo",
                "casas",
                "livro",
                "praia",
                "verde",
                "nuvem",
                "carta",
                "festa",
                "pedra",
                "fruta",
                "sonho",
                "folha",
                "porta",
                "campo",
                "trigo",
                "piano",
                "mundo",
                "linha",
                "plano",
                "chave"
};
        int n = RandomNumberGenerator.GetInt32(1, palavras.Length);

        return palavras[n];
    }

    static bool VerificarPalavraValida(string palavra)
    {
        if (palavra.Length != 5)
        {
            return false;
        }
        return true;
    }

    static void PressioneEnter()
    {
        System.Console.WriteLine("Pressione ENTER para continuar");
        Console.ReadLine();
    }
}
