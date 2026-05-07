using System;
using ByteBank;
using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        var caminhoNovoArquivo = "contasExportadas.csv"; // Define o caminho do novo arquivo que será criado, nesse caso um arquivo chamado "contasExportadas.csv" localizado no mesmo diretório do programa

        using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create)) // Cria um objeto FileStream para criar o arquivo especificado no modo de criação (FileMode.Create)
        {
            var contaComoString = "456, 7895, 4785, Gustavo Santos";

            var enconding = Encoding.UTF8;

            var bytes = enconding.GetBytes(contaComoString); // Converte a string contaComoString em um array de bytes usando a codificação UTF-8

            fluxoDoArquivo.Write(bytes, 0, bytes.Length); // Escreve os bytes no arquivo usando o método Write do FileStream, especificando o array de bytes, o índice inicial (0) e a quantidade de bytes a serem escritos (bytes.Length)
        }
    }
}
