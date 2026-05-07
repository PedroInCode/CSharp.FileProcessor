# ByteBank: Gestão de Arquivos e Streams em C#

Este projeto foi desenvolvido durante o curso de manipulação de fluxos de dados (I/O) no .NET. O foco principal foi aprender como transitar entre a manipulação "raiz" de bytes e o uso de abstrações modernas para processamento eficiente de arquivos.

## 🧠 Aprendizados Fundamentais

### 1. Entender a "Matrix" (Leitura de Bytes)
Aprendi que, no nível mais baixo, o computador não lê texto, mas sim bytes. Implementei a leitura manual usando `FileStream` e um `buffer` (balde) de memória, entendendo que:
- O **FileStream** é o cano que liga o ficheiro ao programa.
- O **Buffer** é o espaço temporário onde guardamos pedaços do ficheiro para não sobrecarregar a RAM.

### 2. A Abstração com StreamReader
Evoluí o código para usar o `StreamReader`, que automatiza a conversão de bytes para caracteres. Isso permitiu:
- Usar o método `ReadLine()` para ler o ficheiro linha a linha.
- Processar ficheiros gigantes de forma leve (o consumo de memória RAM mantém-se baixo, independentemente do tamanho do ficheiro).

## 🛠️ Boas Práticas e Programação Defensiva

Durante o desenvolvimento, "blindei" o código contra erros comuns de produção:

* **Bloco `using`:** Garante que o ficheiro seja fechado e os recursos libertados automaticamente (chama o `Dispose`).
* **Tratamento de Exceções:** Implementei verificações de `null` e de tamanho de array (`campos.Length`) para evitar que o programa crashe com linhas vazias ou formatos inesperados.
* **Mapeamento CSV:** Aprendi a identificar o delimitador correto (vírgula vs espaço) e a tratar padrões de decimais (ponto vs vírgula).

## 🚀 Como usar este repositório como Guia

Este repositório é o meu **"Cérebro Externo"**. Usei-o para fixar os seguintes conceitos:

| Conceito | Onde encontrar no código |
| :--- | :--- |
| **Leitura Raiz** | Método `LidandoComFileStreamDiretamente` |
| **Leitura Eficiente** | Uso do `StreamReader` dentro de um `while (!leitor.EndOfStream)` |
| **Conversão de Dados** | Método `ConverterStringParaContaCorrente` |
| **Segurança** | Uso de blocos `using` e validações de strings |

---
> *"Dominar a lógica de fluxos de dados é o que separa um programador que apenas copia código de um que constrói sistemas escaláveis."*