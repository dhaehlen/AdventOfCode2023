using System.Runtime.InteropServices;

public static class Day1P1
{

    private static string FindDigit(CharGenerator charGen)
    {
        string foundDigit = String.Empty;
        while (charGen.Peek != null)
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
            int lineLength = line.Length;
            
            string leftDigit = String.Empty;
            string rightDigit = String.Empty;

            CharGenerator charGen = new CharGenerator(line);
            leftDigit = FindDigit(charGen);

            CharGenerator charGen


            //iterate from right
            for(int i = lineLength - 1; i >=0; i--){
                double conversionResult = char.GetNumericValue(line[i]);
                if (conversionResult > 0){
                    rightDigit = Char.ToString(line[i]);
                    break;
                }
            }

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
                Console.WriteLine("Error: " + line);
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
