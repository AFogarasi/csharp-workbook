using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
    // your code goes here

    // Enter one word, translate it to Piglatin and print the translation to the screen
    // Rules:
    // 1) any letters before the first vowel get moved to the end of the word
    // 2) if the updated word ends in a vowel add "yay" to the end
    // 3) if the updated word ends in a consonant add "ay" to the end
    // 4) Translator must pass the following tests:
    //  - elephant -> elephantay
    //  - fox -> oxfay
    //  - tsk -> tskay
    //  - are -> areyay
    //  - mine -> inemay
    //  - thing -> ingthay

    //  Enter a word and assign it to a variable
        Console.WriteLine("Please enter a word to translate to Pig Latin: ");
        string englishWord = Console.ReadLine();

    //  Search word for the first vowel and identify its index
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        int letterIdx = englishWord.IndexOfAny(vowels);
        // exception if there are no vowels
        if (letterIdx < 0) {
             letterIdx = 0;
        }

    //  Assign beginning of new Pigword to a variable, assign letters before first vowel to a different variable, and joing them.
        string pigWord = englishWord.Substring(letterIdx); 
        string firstHalf = englishWord.Substring(0,letterIdx);
        pigWord = pigWord + firstHalf;

    // If last letter in pigWord assembly is a vowel add "yay". If not add "ay". Then Print.
        char lastLetter = pigWord[pigWord.Length - 1];
        string last = char.ToString(lastLetter);
        int lastIdx = last.IndexOfAny(vowels);

        // if pigWord ends in a consonant
        if (lastIdx < 0) {
            pigWord = pigWord + "ay";
        }
        // if pigWord ends in a vowel
        else {
            pigWord = pigWord + "yay";
        }
        
        Console.WriteLine(pigWord);
        }
    }
}
