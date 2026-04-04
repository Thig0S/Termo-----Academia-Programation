namespace Termo;

class Program
{
    static void Main(string[] args)
    {
        JogoTermo jogoTermo = new JogoTermo();
        ExibirMenu();
        jogoTermo.RodarJogoTermo();
    }
    static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("----------------");
        Console.WriteLine("Bem-vindo ao Termo TK");
        Console.WriteLine("----------------");
        PressioneEnter();
        Console.Clear();
    }
    public static void PressioneEnter()
    {
        System.Console.WriteLine("Pressione ENTER para continuar");
        Console.ReadLine();
    }

}
