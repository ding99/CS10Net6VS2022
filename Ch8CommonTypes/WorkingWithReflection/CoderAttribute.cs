namespace Packt.Shared;

[AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true)]
public class CoderAttribute : Attribute
{
    public string Coder { get; set; }
    public DateTime LastModified { get; set; }
    public CoderAttribute(string code, string lastModified)
    {
        this.Coder = code;
        this.LastModified = DateTime.Parse(lastModified);
    }
}

