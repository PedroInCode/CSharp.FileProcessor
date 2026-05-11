using ByteBank;
using ByteBank.FileManager.Banco;
using System.Text;

using System.Text;

partial class Program
{
    static void LidandoComFileStreamDiretamente(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";

        // ANOTAÇÃO: O 'using' garante que o arquivo seja fechado e liberado pelo Windows 
        // mesmo se o programa travar. É uma boa prática de segurança de memória.
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var numeroDeBytesLidos = -1;

            // ANOTAÇÃO: O buffer é como uma "bandeja". Em vez de ler o arquivo 1 por 1, 
            // a gente pega 1024 bytes (1KB) de uma vez para ser mais rápido.
            var buffer = new byte[1024];

            // Enquanto o número de bytes lidos for diferente de 0, significa que ainda há dados.
            while (numeroDeBytesLidos != 0)
            {
                // .Read preenche o buffer e nos diz quantos bytes ele realmente conseguiu pegar.
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);

                Console.WriteLine($"\n[Sistema: {numeroDeBytesLidos} bytes lidos]");

                // Chamamos o método para transformar esses bytes em texto legível.
                EscreverBuffer(buffer, numeroDeBytesLidos);
            }

            // ANOTAÇÃO: Com o 'using', o .Close() manual é opcional, mas deixá-lo aqui 
            // reforça a intenção de encerrar o acesso ao arquivo.
            fluxoDoArquivo.Close();

            Console.WriteLine("\n--- Fim da leitura do arquivo ---");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// Transforma uma sequência de bytes (números) em caracteres (texto) usando o padrão UTF8.
    /// </summary>
    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        // ANOTAÇÃO: Computadores só entendem números. O UTF8Encoding funciona como um 
        // "tradutor" que sabe que o número 65, por exemplo, é a letra 'A'.
        var utf8 = new UTF8Encoding();

        // É crucial passar o 'bytesLidos', senão ele tentaria traduzir o buffer inteiro (1024), 
        // incluindo os espaços vazios do final.
        var texto = utf8.GetString(buffer, 0, bytesLidos);

        Console.Write(texto);
    }
}
