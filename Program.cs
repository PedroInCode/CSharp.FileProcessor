using ByteBank;
using ByteBank.FileManager.Banco;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                var contaCorrente = ConverterStringParaContaCorrente(linha);
               
                var mensagem = $"Conta número: {contaCorrente.Numero}, Agência: {contaCorrente.Agencia}, Titular: {contaCorrente.Titular.Nome}, Saldo: {contaCorrente.Saldo}";
                Console.WriteLine(mensagem);
                
            }
            Console.WriteLine("Chegou no final do arquivo.");
        }

        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(",");

        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace(".", ","); // .Replace() Substitui o ponto por vírgula 
        var nomeTitular = campos[3];

        var agenciaComInt = int.Parse(agencia);
        var numeroComInt = int.Parse(numero);
        var saldoComDouble = double.Parse(saldo);

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaComInt, numeroComInt);
        resultado.Depositar(saldoComDouble);
        resultado.Titular = titular;

        return resultado;
    }
}


