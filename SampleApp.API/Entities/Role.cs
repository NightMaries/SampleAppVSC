namespace SampleApp.API.Entities;

public class Role: Base
{   
    public string? Name { get; set;} 

    public IEnumerable<User>? Users {get; set;}
}
