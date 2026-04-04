using System.Security.Cryptography;

namespace Termo;

class JogoTermo
{
    public string? PalavraTermo { get; private set; }

    public void GerarPalavraTermo()
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

        PalavraTermo = palavras[n];
    }
}
class Program
{
    static void Main(string[] args)
    {
        ExibirMenu();

        string palavraTermo = JogoTermo.GerarPalavraTermo();

        bool jogadorVenceu = ComecarJogo(palavraTermo);

        MensagemFinal(jogadorVenceu, palavraTermo);
    }

    static void ExibirMenu()
    {
        Console.WriteLine("----------------");
        Console.WriteLine("Bem-vindo ao Termo TK");
        Console.WriteLine("----------------");
        PressioneEnter();
        Console.Clear();
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

    static bool ComecarJogo(string palavraTermo)
    {
        bool jogadorVenceu = false;

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
            if (palavraTermo == usuarioInput)
            {
                jogadorVenceu = true;
                break;
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
                else if (palavraTermo.Contains(usuarioInput[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.Write($"{usuarioInput[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Write($"{usuarioInput[i]}");
                    Console.ResetColor();
                }
            }
        }
        return jogadorVenceu;
    }

    static void MensagemFinal(bool jogadorVenceu, string palavraTermo)
    {
        if (jogadorVenceu)
        {
            System.Console.WriteLine("\nParabens você acertou! A palavra era " + palavraTermo);
            PressioneEnter();
        }
        else
        {
            System.Console.WriteLine("\nVoce perdeu! A palavra era " + palavraTermo);
            PressioneEnter();
        }
        System.Console.WriteLine("Obrigado por Jogar!");
    }
}
