// I thought custom rolling a state machiine would be fun, it was not. Did learn somethings though.
// Enumerating the state transitions was a PITA
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public enum NumberTokens : long
{
    zero = 0,
    one = 1,
    two = 2,
    three = 3,
    four = 4,
    five = 5,
    six = 6,
    seven = 7,
    eight = 8,
    nine = 9
}

public enum States
{
    inital,
    z,
    ze,
    zer,
    o,
    on,
    t,
    tw,
    th,
    thr,
    thre,
    f,
    fo,
    fou,
    fi,
    fiv,
    s,
    si,
    se,
    sev,
    seve,
    e,
    ei,
    eig,
    eigh,
    n,
    ni,
    nin,
    digit,
    end
}

public class AoCStateMachine
{
    public States currentState = States.inital;
    public Dictionary<char, int> rules;
    public List<States[]> transitionsTable;

    public AoCStateMachine()
    {
        this.rules = new(){{'e', 0}, {'f', 1}, {'g', 2}, {'h', 3}, {'i', 4},
                           {'n', 5}, {'o', 6}, {'r', 7}, {'s', 8}, {'t', 9},
                           {'u', 10},{'v', 11},{'w', 12},{'x', 13}, {'z', 14},
                           {'1', 15}, {'2', 16}, {'3', 17}, {'4', 18}, {'5', 19},
                           {'6', 20}, {'7', 21}, {'8', 22}, {'9', 23}, {'0', 24}};
        
        this.transitionsTable = new List<States[]>();    
        transitionsTable.Add(new States[]{States.e     , States.f     , States.inital, States.inital, States.inital, States.n     , States.o     , States.inital, States.s     , States.t     , States.inital, States.inital, States.inital, States.inital, States.z     , States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.ze    , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.end   , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.on,     States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.end   , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.th    , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.tw    , States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.end   , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.thr   , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.thre  , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.end   , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.fi    , States.inital, States.fo    , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.fou   , States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.end   , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.fiv   , States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.end   , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.se    , States.inital, States.inital, States.inital, States.si    , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.end   , States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.sev   , States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.seve  , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.end   , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.ei    , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.eig   , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.eigh  , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.end   , States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.ni    , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.inital, States.inital, States.inital, States.inital, States.inital, States.nin   , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.end   , States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.inital, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
        transitionsTable.Add(new States[]{States.e     , States.inital, States.inital, States.inital, States.inital, States.n     , States.o     , States.inital, States.s     , States.t     , States.inital, States.inital, States.inital, States.inital, States.z     , States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit, States.digit});
    }

    //The transition table is in the same order as the States Enum, this means the 
    //correct row of the transition table can be obtained using the Enum as an index.
    //The column of the transition tables are encoded in the rules Dictionary.
    public Boolean UpdateState(char rule)
    {
        Boolean tokenAccepted = false;
        if(this.rules.ContainsKey(rule))
        {
            int ruleAsInt = this.rules[rule];
            int currentStateAsInt = (int) this.currentState;
            currentState = transitionsTable[currentStateAsInt][ruleAsInt];
            tokenAccepted = true;
        }
        else
        {
            currentState = States.inital;
        }
        return tokenAccepted;
    }

    public void Reset()
    {
        currentState = States.inital;
    }

    //Deepcopy a instance, easy when everything is public
    public AoCStateMachine Copy()
    {
        AoCStateMachine copy = new AoCStateMachine();
        copy.currentState = this.currentState;
        return copy;
    }
}

public static class Day1P2
{
    public static void Run()
    {
        int sum = 0;

        string filePath = """C:\Users\dhaeh\Documents\AdventOfCode2023\AOCinputday1p1.txt""";
        AoCStateMachine theMachine = new AoCStateMachine();

        Boolean failed = false;
        //int ha = 0;
        foreach (string line in File.ReadLines(filePath))
        {
            theMachine.Reset();
            List<String> tokens = new List<string>();
            ForwardCharGenerator fCharGen = new ForwardCharGenerator(line);
            Queue<char> charBuffer = new Queue<char>();

            Char currentChar;
            while (fCharGen.Peek(0) != null){
                currentChar = fCharGen.Consume();
                //Console.WriteLine("Current Char: " + currentChar);

                Boolean accepted = theMachine.UpdateState(currentChar);
                //Console.WriteLine("Was Accepted?: " + accepted.ToString());
                //Console.WriteLine("theMachineState: " + theMachine.currentState);

                if (theMachine.currentState == States.digit)
                {
                    tokens.Add(Char.ToString(currentChar));
                    theMachine.Reset();
                    continue;
                }
                
                if (accepted && theMachine.currentState != States.inital)
                {
                    charBuffer.Enqueue(currentChar);
                    int i = 0;
                    Boolean scanning = true;
                    AoCStateMachine branchMachine = theMachine.Copy();
                    while(scanning)
                    {
                        //Console.WriteLine("IN SCANNING i = " + i);
                        if (fCharGen.Peek(i) == null){ break; }

                        //Console.WriteLine("Scanning char: " + (Char) fCharGen.Peek(i));
                        //Console.WriteLine("Preupdate Branch state: " + branchMachine.currentState);
                        branchMachine.UpdateState((Char) fCharGen.Peek(i));

                       
                        States currrentState = branchMachine.currentState;
                        //Console.WriteLine("Current State: " + currrentState);
                        switch (currrentState)
                        {
                            case States.digit:
                                //failed to bring Automata to end, break
                                scanning = false;
                                charBuffer.Clear();
                                theMachine.Reset();
                                break;
                            case States.end:
                                //Automata halted, consume chars and convert to string
                                //to fix a bug I wholly disagree with: eighthree = 8 not 8 and 3 but whatever
                                //we won't consume the last char and start the machine on it again.
                                //We'll add it to the buffer with a peek.
                                for(int j = 0; j < i; j++)
                                {
                                    charBuffer.Enqueue(fCharGen.Consume());
                                }
                                charBuffer.Enqueue((Char) fCharGen.Peek(0));
                                tokens.Add(String.Join("", charBuffer.ToArray()));
                                scanning = false;
                                charBuffer.Clear();
                                theMachine.Reset();
                                break;
                            case States.inital:
                                //failed to bring Automata to end, break
                                scanning = false;
                                theMachine.Reset();
                                charBuffer.Clear();
                                break;
                        }
                        i++;
                    }
                }
            }
            //Console.WriteLine("TheTokens so far: " + String.Join("", tokens.ToArray()));
            //if(++ha == 9){ break;}
            string firstNumeric = tokens[0];
            string lastNumeric = tokens[tokens.Count - 1];

            if(firstNumeric.Length > 1){
                firstNumeric = ConvertWordToNumber(firstNumeric);
            }

            if(lastNumeric.Length > 1)
            {
                lastNumeric = ConvertWordToNumber(lastNumeric);
            }

            string lineDigit = firstNumeric + lastNumeric;

            int lineValue;
            if(int.TryParse(lineDigit, out lineValue)){
                sum = sum + lineValue;
            }
            else
            {
                Console.WriteLine("Line conversiont failure: " + lineDigit);
                failed = true;
            }  

            Console.WriteLine("Line: " + line + " Digits: " + lineDigit + " Running Total: " + sum);       
        }

        Console.WriteLine("The sum we found is: " + sum + " Failed: " + failed);
        // foreach (string token in tokens)
        // {
        //     Console.WriteLine(token);
        // }
    }
    
    public static string ConvertWordToNumber(string word)
    {
        switch (word.ToLower())
        {
            case "one":
                word = "1";
                break;
            case "two":
                word = "2";
                break;
            case "three":
                word = "3";
                break;
            case "four":
                word = "4";
                break;
            case "five":
                word = "5";
                break;
            case "six":
                word = "6";
                break;
            case "seven":
                word = "7";
                break;
            case "eight":
                word = "8";
                break;
            case "nine":
                word = "9";
                break;
            case "zero":
                word = "0";
                break;
            default:
                word = "error";
                break;
        }
        return word;
    }
}