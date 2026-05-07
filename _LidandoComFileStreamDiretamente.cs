using ByteBank;
using ByteBank.FileManager.Banco;
using System.Text;

partial class Program
{
    static void LidandoComFileStreamDiretamente(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";

        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var numeroDeBytesLidos = -1;

            var buffer = new byte[1024]; // 1 KB

            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");

                EscreverBuffer(buffer, numeroDeBytesLidos);
            }

            fluxoDoArquivo.Close();

            Console.ReadLine();
        }
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = new UTF8Encoding();

        var texto = utf8.GetString(buffer, 0, bytesLidos);

        Console.Write(texto);
    }

    
}
