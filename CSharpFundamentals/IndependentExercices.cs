using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals
{
    public class IndependentExercices
    {

        public static string ReverseWordsInSentence(string sentence)
        {
            //rejoin the words splited and projected 
            //to be the reversed of the original word
            return string.Join(" ", sentence.Split(' ')
                        .Select(w => String.Join("", w.Reverse()))
                );
        }

        public static string ReverseWordsInSentenceBySteps(string sentence)
        {
            //separate words
            string[] words = sentence.Split(' ');

            //reverse each words
            for (int i = 0; i < words.Length; i++)
            {
                //string.reverse returns char[] not a string
                words[i] = string.Join("", words[i].Reverse());
            }

            //build the sentence again with the reversed words
            return string.Join(" ", words);
        }

        public static string ReverseWordsInSentenceNoHelpers(string sentence)
        {
            string curWord = string.Empty;
            string result = string.Empty;

            foreach (char c in sentence.ToArray()) {
                if (c != ' ')
                {
                    //final sentence does NOT increase.
                    //accumulate chars added in the front
                    //until the next space char
                    curWord = c + curWord;
                }
                else {
                    //update final sentence
                    result = result + curWord + c;
                    curWord = string.Empty;
                }
            }

            //add the remaining word, if any
            if (curWord.Length > 0) { result += curWord; }

            return result;
        }
    }
}
