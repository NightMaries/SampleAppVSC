using System.ComponentModel.DataAnnotations;

namespace SampleApp.API.Entities;

public class User: Base
{
    
    [MinLength(5, ErrorMessage = "Минимальная длина имени 5")]
    [SampleApp.API.Validaitons.UserValidator.MaxLength(10)]
    public string? Name { get; set; }

    public string? Login {get; set;}

    public required byte[] PasswordHash { get; set; } 
    public required byte[] PasswordSalt { get; set; } 

    public int RoleId {get;set;}

    public Role? Role {get; set;}
}
