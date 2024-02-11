// Utilizando C#, transforme um arquivo XML ou JSON em um objeto e escreva na tela o valor de cada propriedade (ex. "Nome: João").

// Defini como premissa que já sabemos a estrutura do documento, tanto XML quanto JSON.

using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

string caminho = "Arquivos/pessoal.json"; // Colocar o caminho e extensão do arquivo

string extensao = Path.GetExtension(caminho);

switch (extensao)
{
    case ".xml":
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(caminho);
        string convert = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);
        JObject objetoXmlJson = JObject.Parse(convert);
        JArray xmlPessoas = (JArray)objetoXmlJson["Pessoas"]["Pessoa"];
        foreach (var e in xmlPessoas)
        {
            Console.WriteLine($"Nome: {e["Nome"]}");
            Console.WriteLine($"Idade: {e["Idade"]}");
            Console.WriteLine($"Telefone: {e["Telefone"]}");
            Console.WriteLine($"Email: {e["Email"]}");
            Console.WriteLine($"Pais: {e["Pais"]}");
            Console.WriteLine();
        }
        break;

    case ".json":
        string jsonDoc = File.ReadAllText(caminho);
        JObject objetoJson = JObject.Parse(jsonDoc);
        JArray jsonPessoas = (JArray)objetoJson["Pessoas"]["Pessoa"];
        foreach (var e in jsonPessoas)
        {
            Console.WriteLine($"Nome: {e["Nome"]}");
            Console.WriteLine($"Idade: {e["Idade"]}");
            Console.WriteLine($"Telefone: {e["Telefone"]}");
            Console.WriteLine($"Email: {e["Email"]}");
            Console.WriteLine($"Pais: {e["Pais"]}");
            Console.WriteLine();
        }
        break;

    default:
        Console.WriteLine("!ERRO! Formato de arquivo não suportado.");
        break;
}