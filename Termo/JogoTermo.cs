using System.Security.Cryptography;

namespace Termo;

class JogoTermo
{
    public string? PalavraTermo { get; private set; }

    public bool jogadorVenceu = false;

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
        int n = RandomNumberGenerator.GetInt32(0, palavras.Length);

        PalavraTermo = palavras[n];
    }
    public void RodarJogoTermo()
    {
        GerarPalavraTermo();

        for (int tentativas = 1; tentativas <= 5; tentativas++)
        {
            System.Console.WriteLine($"\nTENTATIVA {tentativas} de 5!");
            System.Console.Write("Digite uma palavra: ");
            string? usuarioInput = Console.ReadLine()?.ToLower();

            if (String.IsNullOrEmpty(usuarioInput) || !VerificarPalavraValida(usuarioInput))
            {
                System.Console.WriteLine("\nPalavra Inválida! Apenas palavras com 5 letras!");
                Program.PressioneEnter();
                tentativas--;
                continue;
            }
            if (PalavraTermo == usuarioInput)
            {
                jogadorVenceu = true;
                break;
            }
            // verificar se as letras tem na palavra aleatoria do TERMO 
            for (int i = 0; i < PalavraTermo?.Length; i++)
            {
                //Verificar letra por letra do input do usuario
                if (PalavraTermo[i] == usuarioInput[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.Write($"{usuarioInput[i]}");
                    Console.ResetColor();
                }
                else if (PalavraTermo.Contains(usuarioInput[i]))
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
        MensagemFinal();
    }
    public bool VerificarPalavraValida(string palavra)
    {
        if (palavra.Length != 5)
        {
            return false;
        }
        return true;
    }
    public void MensagemFinal()
    {
        if (jogadorVenceu)
        {
            System.Console.Write("\nParabens você acertou! A palavra era ");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write(PalavraTermo + "\n");
            Console.ResetColor();
            Program.PressioneEnter();
        }
        else
        {
            System.Console.Write("\nVoce perdeu! A palavra era ");
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write(PalavraTermo + "\n");
            Console.ResetColor();
            Program.PressioneEnter();
        }
        System.Console.WriteLine("Obrigado por Jogar!");
    }
}
