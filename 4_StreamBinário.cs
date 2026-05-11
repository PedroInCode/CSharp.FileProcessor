using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank;

partial class Program
{
    static void EscritaBinaria()
    {
        // ANOTAÇÃO: Arquivos binários são muito menores e mais rápidos de ler/escrever 
        // do que arquivos de texto (CSV/JSON), pois não precisam de tradução UTF-8 constante.
        using (var fs = new FileStream("contaCorrente.bin", FileMode.Create)) 
        using (var escritor = new BinaryWriter(fs))
        {
            // O escritor identifica o tipo de dado automaticamente. 
            // Ele sabe que 456 é um Int32 (4 bytes) e que 4000.50 é um Double (8 bytes).
            escritor.Write(456);       // número da agência
            escritor.Write(546544);   // número da conta
            escritor.Write(4000.50); // saldo
            escritor.Write("Gustavo Braga"); // Strings em binário guardam o tamanho antes do texto
        }
    }

    static void LeituraBinaria()
    {
        using (var fs = new FileStream("contaCorrente.bin", FileMode.Open))
        {
            using (var leitor = new BinaryReader(fs))
            {
                /* ANOTAÇÃO CRÍTICA: Na leitura binária, a ORDEM importa 100%. 
                Se eu tentar ler um Double onde escrevi um Int, o leitor vai 
                pegar os bytes errados e o valor será um lixo completo.
                */

                var agencia = leitor.ReadInt32();      // Lê exatamente os próximos 4 bytes
                var numeroConta = leitor.ReadInt32();  // Lê os próximos 4 bytes
                var saldo = leitor.ReadDouble();       // Lê os próximos 8 bytes
                var titular = leitor.ReadString();     // Lê a string baseada no tamanho gravado

                Console.WriteLine($"{agencia}/{numeroConta} {saldo} {titular}");
            }
        }
    }
}
