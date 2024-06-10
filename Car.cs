using System.ComponentModel.DataAnnotations;

namespace SquentialGUID;

public class Car : SuperClass
{
    [AllowedValues("Benz", "BMW", "Toyota", "Ford")]
    public string Brand { get; set; }

    public string Model { get; set; }

    [Range(1990, 2024)]
    public int Year { get; set; }
}

