using ByteBank;
using ByteBank.FileManager.Banco;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

partial class Program
{
    static void StreamReaderExample(string[] args)
    {
        var enderecoDoArquivo = "contas.txt"; // Define o caminho do arquivo que será lido, nesse caso um arquivo chamado "contas.txt" localizado no mesmo diretório do programa

        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open)) // Cria um objeto FileStream para abrir o arquivo especificado no modo de leitura (FileMode.Open)
        {
            var leitor = new StreamReader(fluxoDoArquivo);

            //var linha = leitor.ReadLine(); // Lê uma linha do arquivo

            //var texto = leitor.ReadToEnd(); // Lê o restante do arquivo a partir da posição atual - Lê o arquivo inteiro de uma vez!!!

            // var numero = leitor.Read(); // Lê o próximo caractere do arquivo e retorna seu código Unicode

            while (!leitor.EndOfStream) // Enquanto não(!) chegar no final do arquivo
            {
                var linha = leitor.ReadLine(); // Lê uma linha do arquivo e armazena na variável linha

                if (string.IsNullOrWhiteSpace(linha))
                {
                    continue; // Se a linha for nula, vazia ou contiver apenas espaços em branco, o loop continua para a próxima iteração, ignorando o processamento da linha atual
                }

                var contaCorrente = ConverterStringParaContaCorrente(linha); // Chama o método ConverterStringParaContaCorrente para converter a linha lida do arquivo em um objeto ContaCorrente

                if (contaCorrente != null)
                {
                    var mensagem = $"Conta número: {contaCorrente.Numero}, Agência: {contaCorrente.Agencia}, Titular: {contaCorrente.Titular.Nome}, Saldo: {contaCorrente.Saldo}"; // Cria uma mensagem formatada com as informações da conta corrente, incluindo número, agência, nome do titular e saldo

                    Console.WriteLine(mensagem);
                }
            }
            Console.WriteLine("Chegou no final do arquivo.");
        }
        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(","); // .Split() Divide a string em um array de substrings com base em um delimitador, nesse caso a vírgula

        if (campos.Length != 4) // Verifica se o número de campos resultantes da divisão da linha é diferente de 4, o que indica que a linha não está no formato esperado
        {
            Console.WriteLine($"A linha '{linha}' não está no formato esperado."); // Exibe uma mensagem de erro indicando que a linha não está no formato esperado
            return null; // Retorna null para indicar que a conversão falhou
        }

        var agencia = campos[0]; // campos[0] Acessa o primeiro elemento do array, que é a agência
        var numero = campos[1]; // campos[1] Acessa o segundo elemento do array, que é o número da conta
        var saldo = campos[2].Replace(".", ","); // .Replace() Substitui o ponto por vírgula 
        var nomeTitular = campos[3]; // campos[3] Acessa o quarto elemento do array, que é o nome do titular da conta

        var agenciaComInt = int.Parse(agencia); // int.Parse() Converte a string da agência para um número inteiro
        var numeroComInt = int.Parse(numero); // int.Parse() Converte a string do número da conta para um número inteiro
        var saldoComDouble = double.Parse(saldo); // double.Parse() Converte a string do saldo para um número de ponto flutuante (double), considerando a vírgula como separador decimal

        var titular = new Cliente(); // Cria uma nova instância da classe Cliente para representar o titular da conta
        titular.Nome = nomeTitular; // Atribui o nome do titular à propriedade Nome do objeto Cliente

        var resultado = new ContaCorrente(agenciaComInt, numeroComInt); // Cria uma nova instância da classe ContaCorrente usando o construtor que recebe a agência e o número da conta como parâmetros

        resultado.Depositar(saldoComDouble); // Chama o método Depositar da classe ContaCorrente para adicionar o saldo convertido à conta corrente

        resultado.Titular = titular; // Atribui o objeto Cliente criado anteriormente à propriedade Titular da conta corrente, associando o titular à conta

        return resultado;
    }
}
