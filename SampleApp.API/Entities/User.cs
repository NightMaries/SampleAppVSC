using System.ComponentModel.DataAnnotations;

namespace SampleApp.API.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [MinLength(5, ErrorMessage = "Минимальная длина имени 5")]
    [SampleApp.API.Validaitons.UserValidator.MaxLength(10)]
    public string Name { get; set; }

}
