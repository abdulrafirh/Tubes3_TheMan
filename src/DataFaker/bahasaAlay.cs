using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFaker
{
    public class AlayGenerator
    {
        private AlayGenerator() { }

        private static readonly AlayGenerator instance = new AlayGenerator();

        private readonly Random R = new Random();

        private readonly Dictionary<Char, Char> alayConverter = new Dictionary<Char, Char>
        {
            {'A', '4'}, {'a', '4'},
            {'b', 'b'}, {'B', 'B'},
            {'c', 'c'}, {'C', 'C'},
            {'d', 'd'}, {'D', 'D'},
            {'e', '3'}, {'E', '3'},
            {'f', 'f'}, {'F', 'F'},
            {'g', '6'}, {'G', '6'},
            {'h', 'h'}, {'H', 'H'},
            {'i', '1'}, {'I', '1'},
            {'j', 'j'}, {'J', 'J'},
            {'k', 'k'}, {'K', 'K'},
            {'l', 'l'}, {'L', 'L'},
            {'m', 'm'}, {'M', 'M'},
            {'n', 'n'}, {'N', 'N'},
            {'o', '0'}, {'O', '0'},
            {'p', 'p'}, {'P', 'P'},
            {'q', 'q'}, {'Q', 'Q'},
            {'r', 'r'}, {'R', 'R'},
            {'s', '5'}, {'S', '5'},
            {'t', 't'}, {'T', 'T'},
            {'u', 'u'}, {'U', 'U'},
            {'v', 'v'}, {'V', 'V'},
            {'w', 'w'}, {'W', 'W'},
            {'x', 'x'}, {'X', 'X'},
            {'y', 'y'}, {'Y', 'Y'},
            {'z', '2'}, {'Z', '2'}
        };

        public static AlayGenerator Instance
        {
            get { return instance; }
        }

        public string makeAlay(string name)
        {   
            StringBuilder result = new StringBuilder(name);
            for(int i = 0; i < result.Length; i++)
            {
                int roll = R.Next(0, 100);
                if (IsVowel(result[i])){
                    if (roll < 10 && i != 0)
                    {
                        result = result.Remove(i, 1);
                        i--;
                    }
                    else if (roll < 25)
                    {
                        result[i] = alayConverter[result[i]];
                    }
                    else if (roll < 50)
                    {
                        result[i] = Char.ToUpper(result[i]) == result[i] ? Char.ToLower(result[i]) : Char.ToUpper(result[i]);
                    }
                }
                else if (result[i] != ' '){
                    if (roll < 40)
                    {
                        result[i] = alayConverter[result[i]];
                    }
                    else if (roll < 70)
                    {
                        result[i] = Char.ToUpper(result[i]) == result[i] ? Char.ToLower(result[i]) : Char.ToUpper(result[i]);
                    }
                }
            }
            return result.ToString();
        }

        private bool IsVowel(char c)
        {
            return "aeiouAEIOU".IndexOf(c) >= 0;
        }
    }
}
