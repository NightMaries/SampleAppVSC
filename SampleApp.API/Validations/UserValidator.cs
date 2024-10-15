using System.ComponentModel.DataAnnotations;

namespace SampleApp.API.Validaitons.UserValidator;


public class MaxLengthAttribute : ValidationAttribute
{
    private readonly int _maxLength;
    public MaxLengthAttribute(int maxLength) : base($"Name max {maxLength} ")
    {
        _maxLength = maxLength;
    }
    public override bool IsValid(object? value)
    {
        return ((String)value!).Length <= _maxLength;
    }

}