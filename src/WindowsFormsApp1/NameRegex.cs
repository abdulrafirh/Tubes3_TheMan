using System.Diagnostics;
using System.Text.RegularExpressions;
public class NameRegex
{    
    
    public static string replaceNumbersWithChars(string input)
    {
        Dictionary<char, char> replacements = new Dictionary<char, char>
        {
            { '4', 'a' },
            { '3', 'e' },
            { '6', 'g' },
            { '1', 'i' },
            { '0', 'o' },
            { '5', 's' },
            { '2', 'z' }
        };

        return Regex.Replace(input, "[0-6]", m => replacements[m.Value[0]].ToString());
    }
    public static string convertToTitleCase(string input)
    {
        return Regex.Replace(input, @"\b(\w)(\w*)\b", m => m.Groups[1].Value.ToUpper() + m.Groups[2].Value.ToLower());
    }

    public static string addOptionalVowel(string input){
        return Regex.Replace(input, @"(\b\w|\B\w)", m => m.Value + "[aiueo]*");
    }

    public static string convertToRegexPattern(string input){
        return addOptionalVowel(convertToTitleCase(replaceNumbersWithChars(input)));
    }
    public static bool isMatch(string input, string pattern)
    {
        return Regex.IsMatch(input, pattern);
    }
    public static void regexTest()
    {

        string input = "joHn DoE";
        Stopwatch stopwatch = new Stopwatch(); 
        Stopwatch sp2 = new Stopwatch();
        stopwatch.Start();
        string pattern = convertToRegexPattern(input);
        Console.WriteLine("Pattern: " + pattern);
        // Console.WriteLine("Pattern: " + pattern);
        stopwatch.Stop();
        sp2.Start();
        for(int i = 0; i < 1000; i++){
            isMatch("john dhudawhuadwhdwygwyoe", pattern);
            
        }
        sp2.Stop();
        Console.WriteLine("Time Elapsed checking: " + sp2.ElapsedMilliseconds + " ms");
        Console.WriteLine("Time Elapsed creating pattern: " + stopwatch.ElapsedMilliseconds + " ms");
    }


}