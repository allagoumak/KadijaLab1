// See https://aka.ms/new-console-template for more information

/*
 Kadija Allagouma
Student # 041018813
CST8359 Lab 1
Jan 25th 2023
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

/*
 * readFile() - Takes nothing, returns nothing
 * Reads content from file and stores it in a list
 */

var fileContent = new List<string>();
void readFile()
{
   // var contentInFile = new List<string>(words);
    var totalWords = 0;
    try
    {
        StreamReader reader = new StreamReader("Words.txt");
        string line;
        
        while ((line = reader.ReadLine()) != null)
        {
            fileContent.Add(line);
   
        }
    }
    catch (FileNotFoundException fnfe)
    {
        Console.WriteLine("File not found");
        Console.WriteLine(fnfe.Message);
    }
    catch(Exception ex)
    {
        Console.WriteLine("Issue finding the file or extracting its contents");
        Console.WriteLine(ex.Message);
    }

    
    foreach(var content in fileContent)
    {
        
        totalWords++;
        
    }
    Console.WriteLine("The number of words is " + totalWords);
    
    
}

/*
 * BubbleSort(IList<string> words) -Takes a list of strings, returns sorted list of strings
 * Arranges the unstored list passed in alphabetical order using bubble sort
 */

IList<string> BubbleSort(IList<string> words)
{
    var unsortedWords = new List<string>(words);
    string temp;
    
    var stopWatch = new System.Diagnostics.Stopwatch();
    stopWatch.Start();
    for (int i = 0; i < unsortedWords.Count; i++)
    {
        for(int j = 1; j < unsortedWords.Count; j++)
        {
            if (string.Compare(unsortedWords[j], unsortedWords[j-1]) < 0)
            {
                temp = unsortedWords[j];
                unsortedWords[j] = unsortedWords[j-1];
                unsortedWords[j-1] = temp;
            }
           
        }
        
    }
    stopWatch.Stop();
    Console.WriteLine("Execution Time: " + stopWatch.ElapsedMilliseconds + " ms");

 
    
    return words;
}

/*
 * LINQSort(IList<string> words) - Takes a list of strings, returns sorted list of strings
 * Arranges the unstored list passed in alphabetical order using LINQ sort
 */
IList<string> LINQSort(IList<string> words)
{
    var unsortedFile = new List<string>(words);
    var stopWatch = new System.Diagnostics.Stopwatch();
    stopWatch.Start();

    var sortedWords = from unsortedWords in unsortedFile
                      orderby unsortedWords ascending
                      select unsortedWords;

    stopWatch.Stop();
    Console.WriteLine("Execution Time: " + stopWatch.ElapsedMilliseconds + " ms");

    return words;
}

/*
 * printMenu() - Takes nothign, returns nothing
 * Prints the menu options
 */
void printMenu()
{
    Console.Write(
        "\n1. Import Words from File\n" +
        "2. Bubble Sort words\n" +
        "3. LINQ sort words\n" +
        "4. Count the distinct words\n" +
        "5. Take the last 10 words\n" +
        "6. Reverse print the words\n" +
        "7. Get and display words that end with 'd' and display the count\n" +
        "8. Get and display words that contain 'q' and display the count\n" +
        "9. Get and display words that are more than 3 characters long and start with the letter 'a', and display the count\n" +
        "x. Exit\n\n" +
        "Select an option: "

        );
}


 
    String option = null;
    Console.WriteLine("In main");

    do
    {
        var counting = 0;
        printMenu();
        try
        {
            option = Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n" + ex.Message);
        }


        switch (option)
        {
            case "1":
                readFile();
                break;
            case "2":
                BubbleSort(fileContent);
                break;
            case "3":
                LINQSort(fileContent);
                break;
            case "4":
                var count = (from distinctWords in fileContent
                             select distinctWords).Distinct().Count();

                Console.WriteLine(count);
                break;
            case "5":
                var lastTenWords = fileContent.TakeLast(10);
                /*var lastTenWords = from words in fileContent
                                   select words.TakeLast(10);*/
                foreach (string last in lastTenWords)
                {
                    Console.Write(last + " ");
                }
                Console.WriteLine("");
                break;
            case "6":
                var reversingWords = new List<string>(fileContent);
                reversingWords.Reverse();
                foreach (var reverse in reversingWords)
                {
                    Console.WriteLine(reverse);
                }
                /* var resverseWords = from words in fileContent
                               select words.Reverse();
                foreach (var reverse in reversingWords)
                {
                    Console.WriteLine(reverse);
                }*/

                break;
            case "7":
                var dWords = from words in fileContent
                             where words.EndsWith("d")
                             select words;
                foreach (string word in dWords)
                {
                    Console.WriteLine(word + " ");
                }
                break;
            case "8":
                var qWords = from words in fileContent
                             where words.Contains("q")
                             select words;
                foreach (string word in qWords)
                {
                    Console.WriteLine(word + " ");
                }
                break;
            case "9":
                var aCount = 0;
                var aWords = from words in fileContent
                             where words.StartsWith("a") && words.Length > 3
                             select words;
                foreach (string word in aWords)
                {
                    Console.WriteLine(word + " ");
                    aCount++;
                }
                Console.WriteLine("Total count of words that start with 'a': " + aCount);
                break;
            default:
                if (option != "x")
                {
                    Console.WriteLine("\nPlease select a valid option");
                }
                else
                {
                     Console.WriteLine("Thank you, bye!");
                }
                break;
        }
    } while (option != "x");









