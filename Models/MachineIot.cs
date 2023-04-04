namespace MachineWebApi.Models;

public class MachineIot
{
    public string Id { get; set; }
    
    private string _name;
    public string Name 
    { 
        get => _name; 
        set => _name =  value; 
    }
    private bool _isComlete;
    public bool IsComplete
    { 
        get => _isComlete; 
        set => _isComlete =  value; 
    }
    private string _secret;
    public string Secret
    { 
        get => _secret; 
        set => _secret = value; 
    }
}
