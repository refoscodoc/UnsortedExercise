namespace QuestionsWorkout;

public class Program : OopPrinciples
{
    public Program() : base("any") {}
    
    
    private static void Main()
    {
        var exec = new Program();
        exec.Run();
        DataTypes();
    }

    // Data Types
    void Run()
    {
        Console.WriteLine("Enter name");
        _name = Console.ReadLine();

        Console.WriteLine("Enter DOB");
        _dob = DateTime.Parse(Console.ReadLine() ?? string.Empty);

        if (_name is not null || _dob is not null)
        {
            PrintName(_name, _dob);
        }
        else if (_name is not null || _dob is null)
        {
            PrintName(_name);
        }
        else
        {
            PrintName();
        }
    }

    static void DataTypes()
    {
        // Data types can be of three types: Value, Reference and Pointer
        // Variables of reference types store references to their data (objects),
        // while variables of value types directly contain their data. 
        // Two Ref types can point at the same data, hence one could modify the value of the other.
        // Each Value types stores the data value within itself and they're therefore unique. 

        //Value Data Type:
        int integer = 1024;
        char character = 'j';
        double doubleVariable = 5.0 * (10 ^ 4);

        //Reference Data Type
        string text = "The Brown Fox Thing";
        object objectType = new object();
        // and Class and Interface too

        unsafe
        {
            //Pointer Type
            int* integerPointer = &integer;
            IntPtr ptr = (IntPtr) integerPointer;

            Console.WriteLine("An Unsafe Pointer: ");
            Console.WriteLine(*integerPointer);
            Console.WriteLine("At Memory Address: ");
            Console.WriteLine("0x" + ptr);
        }

        Console.WriteLine("--------");
        Console.WriteLine(integer + " + " + character + " + " + doubleVariable + " + " + text);
    }

    public void OopPrinciplesDemonstration()
    {
        // There are four main pillars in OOP:

        //Abstraction, meaning that a concept is applied to something without a particular instance.

        //Encapsulation
        //Encapsulation is the mechanism of hiding
        //of data implementation by restricting access to public methods.
        //Instance variables are kept private and accessor methods are made
        //public to achieve this.

        //Inheritance happens when a class inherits from a super class. Interfaces/Abstract Classes

        //Polymorphism refers to the ability of having multiple methods or classes with different
        //functionalities. In methods it refers to Overloading and in classes to Inheritance
    }

    private string? _name;
    private DateTime? _dob = new DateTime();

    public override string GetName()
    {
        return _name;
    }

    public override void SetName(String name)
    {
        this._name = name;
    }

    public override DateTime? GetDob()
    {
        return _dob;
    }

    public override void SetDob(DateTime dob)
    {
        this._dob = dob;
    }

    void PrintName()
    {
        Console.WriteLine("Didn't receive any name");
    }

    // void PrintName(string? name)
    // {
    //     Console.WriteLine(name);
    // }

    void PrintName(string? name, DateTime? dob = null)
    {
        Console.WriteLine(name + " was born on " + dob);
    }
}