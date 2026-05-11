using System;
using ByteBank;
using System.Text;

using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        // ANOTAÇÃO: O FileMode.Create cria o arquivo se não existir e SOBRESCREVE se já existir.
        // Se eu quisesse apenas adicionar texto ao final sem apagar o que já existe, usaria FileMode.Append.
        using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var contaComoString = "456, 7895, 4785, Gustavo Santos";
            var enconding = Encoding.UTF8;

            // ANOTAÇÃO: Novamente, o computador não entende letras, então "traduzimos" a string
            // para uma sequência de números (bytes) antes de enviar para o disco.
            var bytes = enconding.GetBytes(contaComoString);

            fluxoDoArquivo.Write(bytes, 0, bytes.Length);
        }
    }

    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        // ANOTAÇÃO: Note como eu empilhei dois 'using'. 
        // O StreamWriter é como uma "caneta": ele escreve o texto e ele mesmo cuida 
        // de converter para bytes e mandar para o FileStream (o papel).
        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoDeArquivo))
        {
            // Muito mais simples! Não precisamos lidar com arrays de bytes.
            escritor.Write("456,65465,456.0,Pedro");
        }
    }

    static void TestaEscrita()
    {
        var caminhoNovoArquivo = "teste.txt";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoDeArquivo))
        {
            for (int i = 0; i < 100; i++)
            {
                escritor.WriteLine($"Linha {i}");

                /* ANOTAÇÃO CRÍTICA: O Flush(). 
                Por padrão, o C# guarda os dados em memória (buffer) e só escreve no HD 
                quando o buffer enche ou o arquivo fecha. O Flush() "força" a escrita imediata.
                Use com cuidado: usar Flush() dentro de um loop muito grande pode deixar o sistema lento.
                escritor.Flush();
                */

                Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter...");
                Console.ReadLine();
            }
        }
    }
}
