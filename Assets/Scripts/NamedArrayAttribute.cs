using System;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public sealed class NamedArrayAttribute : Attribute
{
    public string BaseName { get; private set; }

    public NamedArrayAttribute(string baseName)
    {
        this.BaseName = baseName;
    }
}
