using System.Runtime.InteropServices;

public class CharGenerator
{
    private string data;
    private int index;
    private int length;
    private Boolean reverse;

    public CharGenerator(string data, Boolean reverse = false)
    {
        this.data = data;
        this.reverse = reverse;
        this.length = data.Length;
        this.index = 0;
    }

    public char? Peek()
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

    public char Consume()
    {
        return data[index++];
    }

    public void Reset(Boolean reverse = false)
    {
        this.index = 0;
        this.reverse = reverse;
    }
}