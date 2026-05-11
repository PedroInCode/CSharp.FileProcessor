using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Program
{
    static void UsarStreamDeEntrada()
    {
        // ANOTAÇÃO: OpenStandardInput() abre o fluxo do teclado. 
        // Para o computador, não importa se os bytes vêm de um HD ou de uma tecla pressionada; 
        // o tratamento via Stream é o mesmo.
        using (var fluxoDeEntrada = Console.OpenStandardInput())
        {
            // Criei um arquivo para salvar o que for digitado
            using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024]; // Minha "bandeja" de 1KB

                while (true) // Loop infinito: o console está sempre "aberto"
                {
                    // O programa para aqui e fica ESPERANDO o usuário digitar algo e dar Enter.
                    var byteslidos = fluxoDeEntrada.Read(buffer, 0, 1024);

                    // Assim que recebe os bytes do teclado, ele escreve no arquivo.
                    fs.Write(buffer, 0, byteslidos);

                    // ANOTAÇÃO: O Flush() aqui é essencial para que eu possa abrir o arquivo 
                    // de texto e ver o que digitei sem precisar fechar o programa.
                    fs.Flush();

                    Console.WriteLine($"Bytes lidos na console: {byteslidos}");
                }
            }
        }
    }
}
