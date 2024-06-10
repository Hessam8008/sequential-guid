// See https://aka.ms/new-console-template for more information

using SquentialGUID;

var person1 = new Person();
var person2 = new Person();
var person3 = new Person();

var car1 = new Car();
var car2 = new Car();
var car3 = new Car();

Console.WriteLine("Person1: {0}", person1.Id);
Console.WriteLine("Person2: {0}", person2.Id);
Console.WriteLine("Person3: {0}", person3.Id);
Console.WriteLine();
Console.WriteLine("Car1   : {0}", car1.Id);
Console.WriteLine("Car2   : {0}", car2.Id);
Console.WriteLine("Car3   : {0}", car3.Id);
Console.WriteLine();
Console.WriteLine("Press any key to end...");
Console.ReadKey();

