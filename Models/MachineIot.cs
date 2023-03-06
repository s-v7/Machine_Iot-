namespace MachineWebApi.Models;

public class MachineIot
{
    public string Id { get; set; }

    public string Name { get; set; }

    public bool IsComplete { get; set; }

    public string Secret { get; set; }

    public MachineIot(string id, string name, bool isComplete, string secret)
    {
        this.Id = id;
        this.Name = name;
        this.IsComplete = isComplete;
        this.Secret = secret;
    }

}