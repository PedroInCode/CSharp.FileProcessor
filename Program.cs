using ByteBank;

class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";
        var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);
        // public override int Read(byte[] array, int offset, int count);

        var buffer = new byte[1024]; // 1 KB
        fluxoDoArquivo.Read(buffer, 0, 1024);


        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer)
    {
        foreach(byte meuByte in buffer)
        {
            Console.Write(meuByte);
            Console.Write(" ");
        }
    }
}


