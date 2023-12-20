using System.Runtime.InteropServices;

public static class Day1P1
{

    private static string FindDigit(ICharGenerator charGen)
    {
        string foundDigit = String.Empty;
        while (charGen.Peek(0) != null)
        {
            char nextChar = charGen.Consume();
            double conversionResult = char.GetNumericValue(nextChar);
            if (conversionResult > 0){
                foundDigit = Char.ToString(nextChar);
                break;
            }
        }
        return foundDigit;
    }
    public static void Run(){
        string filePath = """C:\Users\dhaeh\Documents\AdventOfCode2023\AOCinputday1p1.txt""";

        int sum = 0;
        Boolean failed = false;

        foreach (string line in File.ReadLines(filePath))
        {            
            string leftDigit = String.Empty;
            string rightDigit = String.Empty;

            ForwardCharGenerator fcharGen = new ForwardCharGenerator(line);
            leftDigit = FindDigit(fcharGen);

            ReverseCharGenerator rCharGen = new ReverseCharGenerator(line);
            rightDigit = FindDigit(rCharGen);

            if (!String.IsNullOrEmpty(leftDigit) && !String.IsNullOrEmpty(rightDigit)){
                string lineDigit = leftDigit + rightDigit;
                Console.WriteLine(line + ": " + lineDigit);
                int lineValue;
                if(int.TryParse(lineDigit, out lineValue)){
                    sum = sum + lineValue;
                }
                else{
                    Console.WriteLine("Failed Converting: " + lineDigit);
                    failed = true;
                }
            }
            else{
                Console.WriteLine("Error: " + line + " Left Digit: " + leftDigit + " Right Digit: " + rightDigit);
                failed = true;
            }  
        }

        if (failed){
            Console.WriteLine("There was an error.");
            Console.WriteLine("Sum counted: " + sum);
        }
        else{
            Console.WriteLine("No errors occured.");
            Console.WriteLine("Sum counted: " + sum);
        }
    }
}
