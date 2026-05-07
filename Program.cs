using ByteBank;
using System.Text;

partial class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";

        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDoArquivo);

            //var linha = leitor.ReadLine(); // Lê uma linha do arquivo

            //var texto = leitor.ReadToEnd(); // Lê o restante do arquivo a partir da posição atual - Lê o arquivo inteiro de uma vez!!!

            // var numero = leitor.Read(); // Lê o próximo caractere do arquivo e retorna seu código Unicode

            while (!leitor.EndOfStream) // Enquanto não(!) chegar no final do arquivo
            {
                var linha = leitor.ReadLine();
                Console.WriteLine(linha);
            }
            Console.WriteLine("Chegou no final do arquivo.");
        }

        Console.ReadLine();
    }
}


