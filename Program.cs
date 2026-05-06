using ByteBank;

class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";
        var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);
        // public override int Read(byte[] array, int offset, int count);


        Console.ReadLine();
    }

    private static object ContaCorrente(int v1, int v2)
    {
        throw new NotImplementedException();
    }
}
