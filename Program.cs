using RenameProject;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Insira o caminho do projeto novo: ");
        var directory = Console.ReadLine();

        Console.Write("Insira o nome de projeto do projeto antigo: ");
        var oldName = Console.ReadLine();

        Console.Write("Insira o nome de projeto do projeto novo: ");
        var newName = Console.ReadLine();

        if (directory == null)
            throw new Exception("Insira o caminho do diretório do projeto");

        Replace replace = new Replace();

        replace.RenameFolderContent(directory, oldName, newName);
    }
}