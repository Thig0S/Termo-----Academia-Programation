using System.Security.Cryptography;

namespace Termo;

class Program
{
    static void Main(string[] args)
    {
        ExibirMenu();

        string palavraTermo = GerarPalavraTermo();

        string placeholder = "_ _ _ _ _";

        for (int tentativas = 1; tentativas <= 5; tentativas++)
        {
            System.Console.Write("Digite uma palavra: ");
            string? usuarioInput = Console.ReadLine()?.ToLower();

            if (String.IsNullOrEmpty(usuarioInput) || !VerificarPalavraValida(usuarioInput))
            {
                System.Console.WriteLine("Palavra Inválida! Apenas palavras com 5 letras!");
                PressioneEnter();
                tentativas--;
                continue;
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

        return palavras[0];
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
        Console.Clear();
    }
}
