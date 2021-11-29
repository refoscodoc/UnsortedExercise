namespace ABC;

public abstract class C
{
    public C(string name)
    {
        
    }
    
    public void PrintHello(string name = "Filippo")
    {
        Console.WriteLine($"Hello {name} from C");
    }
}