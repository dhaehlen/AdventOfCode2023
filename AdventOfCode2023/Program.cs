// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

string filePath = """C:\Users\dhaeh\Documents\AdventOfCode2023\AOCinputday1p1.txt""";

int sum = 0;
Boolean failed = false;

foreach (string line in File.ReadLines(filePath))
{
    int lineLength = line.Length;
    
    string leftDigit = String.Empty;
    string rightDigit = String.Empty;

    //iterate from left
    for(int i = 0; i < lineLength; i++){
        double conversionResult = char.GetNumericValue(line[i]);
        if (conversionResult > 0){
            leftDigit = Char.ToString(line[i]);
            break;
        }
    }

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
