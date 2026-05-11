using ByteBank;
using ByteBank.FileManager.Banco;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

partial class Program
{
    static void StreamReaderExample(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";

        // ANOTAÇÃO: Abrir o arquivo com FileStream é o método seguro, 
        // mas o StreamReader é o "especialista em texto". 
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            // ANOTAÇÃO: O StreamReader facilita a vida porque ele já sabe lidar com Encoding (UTF8)
            // e nos dá métodos como ReadLine(), que "entende" onde termina uma linha.
            var leitor = new StreamReader(fluxoDoArquivo);

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();

                if (string.IsNullOrWhiteSpace(linha))
                {
                    continue; // Ignora linhas em branco para evitar erros no Split
                }

                // ANOTAÇÃO: Aqui estou fazendo um "Parsing". 
                // É exatamente o que uma API faz quando recebe um JSON e transforma em Objeto.
                var contaCorrente = ConverterStringParaContaCorrente(linha);

                if (contaCorrente != null)
                {
                    var mensagem = $"Conta número: {contaCorrente.Numero}, Agência: {contaCorrente.Agencia}, Titular: {contaCorrente.Titular.Nome}, Saldo: {contaCorrente.Saldo}";
                    Console.WriteLine(mensagem);
                }
            }
            Console.WriteLine("Processamento concluído.");
        }
        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        // ANOTAÇÃO: O Split por vírgula transforma o texto em um arquivo CSV (Comma Separated Values).
        var campos = linha.Split(",");

        if (campos.Length != 4)
        {
            Console.WriteLine($"[LOG DE ERRO]: Linha mal formatada -> {linha}");
            return null;
        }

        try
        {
            var agencia = campos[0];
            var numero = campos[1];

            // ANOTAÇÃO: O Replace aqui é um tratamento de cultura. 
            // Em sistemas globais, o ponto (.) e a vírgula (,) mudam de função (separador decimal vs milhar).
            var saldo = campos[2].Replace(".", ",");
            var nomeTitular = campos[3];

            var agenciaComInt = int.Parse(agencia);
            var numeroComInt = int.Parse(numero);
            var saldoComDouble = double.Parse(saldo);

            // ANOTAÇÃO: Aqui estou "Inflando" o objeto. 
            // Eu crio o Cliente e a Conta separadamente e depois vinculo os dois.
            var titular = new Cliente { Nome = nomeTitular };
            var resultado = new ContaCorrente(agenciaComInt, numeroComInt);

            resultado.Depositar(saldoComDouble);
            resultado.Titular = titular;

            return resultado;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao converter dados: {ex.Message}");
            return null;
        }
    }
}