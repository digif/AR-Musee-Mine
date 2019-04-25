/// <summary>
/// structure to store the description of the objects
/// </summary>
public struct Info
{
    public readonly string objectName;
    public readonly string title;
    public readonly string description;

    public Info(string name, string title, string desc)
    {
        objectName = name;
        this.title = title;
        description = desc;
    }
}

