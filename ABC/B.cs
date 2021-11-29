namespace ABC;

public class B : C
{
    public B() : base("Alberto")
    {
        
    }
    
    public void PrintHello()
    {
        Console.WriteLine("Hello from B");
        B derived = new B();
        derived.PrintHello("Alberto");
    }
}