// Ex01: Utilizando C#, crie um algorítimo que descubra a sequência de Fibonacci e salve o resultado em um arquivo de texto no diretório "D:/OnlineTest/".

// Como a sequência de Fibonacci é infinita, vou criar uma interação com usuário para definir quantos elementos da sequência ele pretende salvar no arquivo .txt
// Interação com usuário

Console.WriteLine("----------------------------------------------------------------------");
Console.WriteLine("                  BEM VINDX A SEQUÊNCIA DE FIBONACCI                  \n");
Console.WriteLine("Esse programa irá imprimir em tela e salvar um arquivo de texto com\na quantidade de elementos que você desejar da Sequência de Fibonacci.");
Console.WriteLine("-> Sequência em ordem crescente (inicia-se no primeiro elemento)");
Console.WriteLine("-> Digite 0 para Sair");
Console.WriteLine("----------------------------------------------------------------------");

int entradaUsuario;
List<int> resultado = new List<int> {1, 1};

do
{
    Console.WriteLine("\nPor gentileza, digite quantos elementos você deseja salvar (número inteiro):");
    if (int.TryParse(Console.ReadLine(), out entradaUsuario))
    {
        break;
    }
    else
    {
        Console.WriteLine("!!! ERRO !!! O valor digitado é inválido!\nTente novamente, ex.: 7");
    }
} while(true);

// Calcular a sequência Fibonacci de acordo com usuário e salva o arquivo

switch (entradaUsuario)
{
    case 0:
        Console.WriteLine("Grato por utilizar nosso programa, até breve ;)");
        break;
    
    case 1:
        Console.WriteLine($"O primeiro elemento da sequência Fibonacci é: {resultado[0]}");
        using (StreamWriter doc = new StreamWriter("numeros.txt"))
        {
            doc.WriteLine(resultado[0]);
        }
        break;
    
    case 2:
        Console.WriteLine($"Os {entradaUsuario} primeiros elementos da sequência Fibonacci são: {resultado[0]}, {resultado[1]}");
        using (StreamWriter doc = new StreamWriter("numeros.txt"))
        {
            doc.WriteLine(resultado[0]);
            doc.WriteLine(resultado[1]);
        }
        break;        
    
    default:
        for (int i = 2; i < entradaUsuario; i++)
        {
            resultado.Add(resultado[i-1] + resultado[i-2]);
        }
        Console.WriteLine($"Os {entradaUsuario} primeiros elementos da sequência Fibonacci são:");
        for (int i = 0; i < entradaUsuario; i++)
        {
            Console.Write(resultado[i]);
            if (i < entradaUsuario - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
        using (StreamWriter doc = new StreamWriter("numeros.txt"))
        {
            foreach (int e in resultado)
            {
                doc.WriteLine(e);
            }
        }
        break;
}