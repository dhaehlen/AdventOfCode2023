using System.Collections.Concurrent;
using System.Runtime.InteropServices;

public interface ICharGenerator
{
    public char? Peek(int lookAhead = 1);
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

    public abstract char? Peek(int lookAhead = 1);
    public abstract char Consume();
}

public class ForwardCharGenerator : BaseCharGenerator
{
    private int index;

    public ForwardCharGenerator(string data) : base(data)
    {
        this.index = 0;
    }

    public override char? Peek(int lookAhead = 1)
    {
        if(index + lookAhead < length)
        {
            return data[index + lookAhead];
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

    public override char? Peek(int lookAhead = 1)
    {
        if(index - lookAhead >= 0)
        {
            return data[index - lookAhead];
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