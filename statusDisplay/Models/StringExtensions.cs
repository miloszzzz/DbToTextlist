using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statusDisplay.Models
{
    internal static class StringExtensions
    {
        public static string SeparateWords(this string words)
        {
            if (words.Length <= 3) return words;

            for (int i = 2; i < words.Length; i++)
            {
                if (words[i] == '_')
                {
                    char[] letters = words.ToCharArray();
                    letters[i] = ' ';
                    words = string.Join("", letters);
                }
                if (!char.IsLetter(words[i-1]) && !char.IsDigit(words[i-1])) continue;
                if (char.IsLower(words[i]) |char.IsSeparator(words[i])) continue;

                if (IsShortcut(words[i], words[i - 1]) ||
                    IsNumber(words[i], words[i - 1])) continue;

                if (!char.IsDigit(words[i]))
                {
                    if (i + 1 <= words.Length)
                    {
                        if (!IsShortcut(words[i], words[i + 1]))
                        {
                            char[] letters = words.ToCharArray();
                            letters[i] = char.ToLower(letters[i]);
                            words = string.Join("", letters);
                        }
                    }
                }

                words = words.Insert(i++, " ");
            }

            return words;
        }


        static bool IsShortcut(char a, char b, char c)
        {
            if (char.IsUpper(a) && char.IsUpper(b) && char.IsUpper(c)) return true;
            return false;
        }


        static bool IsShortcut(char a, char b)
        {
            if (char.IsUpper(a) && char.IsUpper(b)) return true;
            return false;
        }


        static bool IsNumber(char a, char b)
        {
            if (char.IsDigit(a) && char.IsDigit(b)) return true;
            return false;
        }
    }
}
