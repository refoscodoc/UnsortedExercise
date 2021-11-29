namespace QuestionsWorkout;

public abstract class OopPrinciples
{
    public string Name;
    
    public DateTime dob;
    
    public OopPrinciples(string name)
    {
        
    }
    
    public virtual String GetName() {
        return Name;
    }
    
    public virtual void SetName(String name) {
        this.Name = name;
    }
    
    public virtual DateTime? GetDob() {
        return dob;
    }
    
    public virtual void SetDob(DateTime dob) {
        this.dob = dob;
    }
}