using System;
using System.Collections.Generic;

namespace AnagramsBuilder
{
    class Program
    {
        static void Main()
        {
            var validWords = new HashSet<string> {"dog", "god"};
            var builder = new AnagramBuilder(validWords);
            builder.Process();
            builder.Dump();
        }
    }

    // signature('dog') === signature('god')  <- dog and god are words
    // signature('dog') !== signature('odg')

    internal class AnagramBuilder
    {
        private readonly HashSet<string> _validWords;
        private readonly Dictionary<string, HashSet<string>> _anagrams = new Dictionary<string, HashSet<string>>();

        public AnagramBuilder(HashSet<string> validWords)
        {
            _validWords = validWords;
        }

        public void Process()
        {
            foreach (string word in _validWords)
            {
                string signature = CalculateSignature(word);
                HashSet<string> hashSet;
                if (_anagrams.ContainsKey(signature))
                {
                    hashSet = _anagrams[signature];
                }
                else
                {
                    hashSet = new HashSet<string>();
                    _anagrams.Add(signature, hashSet);
                }
                hashSet.Add(word);
            }
        }


        private static string CalculateSignature(string validWord)
        {
            char[] charArray = validWord.ToCharArray();
            Array.Sort(charArray);
            return new string(charArray);
        }

        public void Dump()
        {
            foreach (var anagram in _anagrams)
            {
                Console.Write("{0}: [", anagram.Key);
                Console.Write(string.Join(",", anagram.Value));
                Console.WriteLine("]");
            }
        }
    }
}
