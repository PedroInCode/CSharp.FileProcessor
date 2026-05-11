using ByteBank;
using ByteBank.FileManager.Banco;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

partial class Program
{
    static void Main(string[] args)
    {

        var linhas = File.ReadAllLines("contas.txt");
        Console.WriteLine(linhas.Length); // Quantidade de Linhas 

        /*
        foreach (var line in linhas)
        {
            Console.WriteLine(line);
        }
        */

        var bytesArquivo = File.ReadAllBytes("contas.txt");
        Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes."); // Quantidade de Bytes

        File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText"); // Criando arquivo e armazenando informação

        Console.WriteLine("Aplicação Finalizada...");

        Console.ReadLine();
    }
}



