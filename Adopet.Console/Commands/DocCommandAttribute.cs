namespace Adopet.Console.Classes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DocCommandAttribute : Attribute
{
    public string Instruction { get; }
    public string Documentation { get; }

    public DocCommandAttribute(string instruction, string documentation)
    {
        Instruction = instruction;
        Documentation = documentation;
    }
}