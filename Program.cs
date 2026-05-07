using ByteBank;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";
        var numeroDeBytesLidos = -1; 

        var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);

        var buffer = new byte[1024]; // 1 KB

        while (numeroDeBytesLidos != 0)
        {
            numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
            EscreverBuffer(buffer);
        }


        /* Develuções:
         * O número total de bytes lidos do buffer. Isso poderá ser menor que o número de bytes solicitado se esse numero de bytes não 
         * estiver disponivel no momento, ou zero, se o final do fluxo for atingido. */

        EscreverBuffer(buffer);
        // public override int Read(byte[] array, int offset, int count);

        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer)
    {
        var utf8 = new UTF8Encoding();

        var texto = utf8.GetString(buffer);

        Console.Write(texto);

        /*foreach(byte meuByte in buffer)
        {
           Console.Write((char)meuByte);
            Console.Write(" ");
        }*/
    }
}


