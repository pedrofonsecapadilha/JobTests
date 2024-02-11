// // Utilizando C#, me passe a lista de arquivos de texto contido em um diretório específico e que possuem em seu conteúdo números de telefone em um formato específico.
// Premissa: Defini o formato dos telefones dos arquivos como: (92) 2254-1417 ou (85) 98455-6483 para definir a expressão regular de busca.

using System.Text.RegularExpressions;

string pasta = "DiretórioEspecífico"; // Alterar o texto para o caminho do diretório específico.
List<string> telefones = new List<string>();

if (Directory.Exists(pasta))
{
    string[] arquivos = Directory.GetFiles(pasta, "*.txt"); // Alterar o texto para o formato dos arquivos que se deseja verificar.
    foreach (string arq in arquivos)
    {
        string conteudo = File.ReadAllText(arq);
        MatchCollection verificacao = Regex.Matches(conteudo, @"\(\d{2}\) \d{4,5}-\d{4}"); // Alterar a Regex de acordo com padrão dos telefones.
        foreach (Match texto in verificacao)
        {
            telefones.Add(texto.Value);
        }
    }
    Console.WriteLine("Os números de telefone encontrados nos arquivos são:");
    foreach (string e in telefones)
    {
        Console.WriteLine(e);
    }
}
else
{
    Console.WriteLine("! ERRO ! Confira o caminho da pasta!");
}