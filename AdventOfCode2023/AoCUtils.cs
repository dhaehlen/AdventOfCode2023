using System.Collections.Concurrent;
using System.Runtime.InteropServices;

public interface ICharGenerator
{
    public char? Peek();
    public char Consume();
}

public abstract class BaseCharGenerator : ICharGenerator
{
    protected string data;
    protected int length;

    public BaseCharGenerator(string data)
    {
        this.data = data;
        this.length = data.Length;
    }

    public abstract char? Peek();
    public abstract char Consume();
}

public class ForwardCharGenerator : BaseCharGenerator
{
    private int index;

    public ForwardCharGenerator(string data) : base(data)
    {
        this.index = 0;
    }

    public override char? Peek()
    {
        if(index + 1 < length)
        {
            return data[index + 1];
        }
        else
        {
            return null;
        }
    }

    public override char Consume()
    {
        return data[index++];
    }
}

public class ReverseCharGenerator : BaseCharGenerator
{
    
    private int index;

    public ReverseCharGenerator(string data) : base(data)
    {
        this.index = this.length - 1;
    }

    public override char? Peek()
    {
        if(index - 1 >= 0)
        {
            return data[index - 1];
        }
        else
        {
            return null;
        }
    }

    public override char Consume()
    {
        return data[index--];
    }
}