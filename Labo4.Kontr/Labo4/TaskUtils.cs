using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labo4
{

    class TaskUtils
    {
        /// <summary>
        /// Finds all the words that are in the data file
        /// </summary>
        /// <param name="CFd"></param>
        /// <param name="punctuation"></param>
        /// <returns></returns>
        public static List<string> GroupingWords(string CFd, char[] punctuation)
        {
            List<string> Words = new List<string>();
            using (StreamReader reader = new StreamReader(CFd))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!Words.Contains(words[i]))
                        {
                            Words.Add(words[i]);
                        }
                    }
                }
            }
            return Words;
        }
        /// <summary>
        /// Groups all separated words, that are only in book1, in to the string list
        /// </summary>
        /// <param name="book1">Data of the first data file</param>
        /// <param name="book2">Data of the second data file</param>
        /// <returns>String list of the top 10 most repeatedly words that are only in book1</returns>
        public static List<string> SeparateWords(List<string> book1, List<string> book2)
        {
            List<string> words = new List<string>();

            int index = 0;
            while (words.Count < 10 && index < book1.Count)
            {
                if (!book2.Contains(book1[index]))
                {
                    words.Add(book1[index]);
                }
                index++;
            }
            return words;
        }
        /// <summary>
        /// Finds the sum of how many times the word was repeated in the text
        /// </summary>
        /// <param name="words">string list of separated words</param>
        /// <param name="CFd">data file</param>
        /// <param name="punctuation">char array of word separators</param>
        /// <returns>the sum of how many times the word was repeated</returns>
        public static List<int> Repetition(List<string> words, string CFd, char[] punctuation)
        {
            List<string> allWords = new List<string>();
            using (StreamReader reader = new StreamReader(CFd))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] word = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < word.Length; i++)
                    {
                        allWords.Add(word[i]);
                    }
                }
            }
            List<int> repeats = new List<int>();
            for (int i = 0; i < words.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < allWords.Count; j++)
                {
                    if (words[i] == allWords[j])
                    {
                        sum++;
                    }
                }
                repeats.Add(sum);
            }

            return repeats;
        }
        /// <summary>
        /// Sorts the final data by the amount of how many times word had been repeated and by alphabeth
        /// </summary>
        /// <param name="words">list string of words</param>
        /// <param name="amount">number of how many times that word had been used in the data file</param>
        public static void Sort(List<string> words, List<int> amount)
        {
            for (int i = 0; i < words.Count; i++)
            {
                int maxAmount = amount[i];
                string maxWords = words[i];
                int index = i;
                for (int j = i; j < words.Count; j++)
                {
                    if (maxAmount < amount[j] || (maxAmount == amount[j] && maxWords.CompareTo(words[j]) > 0))
                    {
                        maxAmount = amount[j];
                        maxWords = words[j];
                        index = j;
                    }
                }
                int tempAmount = amount[i];
                amount[i] = amount[index];
                amount[index] = tempAmount;

                string tempWords = words[i];
                words[i] = words[index];
                words[index] = tempWords;
            }
        }
        /// <summary>
        /// Processes the text information to find the longest sentence
        /// and the line index of that sentence beginning
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="punctuation"></param>
        /// <param name="endOfSentence"></param>
        /// <returns>Shortest sentence and the line index to its beginning</returns>
        public static KeyValuePair<string, int> Process(string fileName, char[] punctuation, char[] endOfSentence)
        {
            string[] lines = File.ReadAllLines(fileName);
            List<string> Sentences = new List<string>();
            List<int> SentenceIndex = new List<int>();

            string beginning = "";
            SentenceIndex.Add(0);

            for (int i = 0; i < lines.Length; i++)
            {
                if (Sentences.Count >= SentenceIndex.Count)
                {
                    int temp = Sentences.Count - SentenceIndex.Count;
                    for (int j = 0; j < temp; j++)
                    {
                        SentenceIndex.Add(i - 1);
                    }
                    if (beginning == "") SentenceIndex.Add(i);
                    else SentenceIndex.Add(i - 1);
                }

                beginning = SeparateSentences(beginning, lines[i], endOfSentence, Sentences);
            }
            if (Sentences.Count >= SentenceIndex.Count)
            {
                int temp = Sentences.Count - SentenceIndex.Count;
                for (int j = 0; j < temp; j++)
                {
                    SentenceIndex.Add(lines.Length - 1);
                }
            }

            int longestIndex = LongestSentence(Sentences, punctuation);
            if (longestIndex > -1)
            {
                KeyValuePair<string, int> sentence = new KeyValuePair<string, int>(Sentences[longestIndex], SentenceIndex[longestIndex]);
                return sentence;
            }
            else
            {
                KeyValuePair<string, int> sentence = new KeyValuePair<string, int>("Tokio sakinio nėra", -1);
                return sentence;
            }
        }

        /// <summary>
        /// Separates text into sentences
        /// </summary>
        /// <param name="beginning">the beginning of the sentence from the previous line</param>
        /// <param name="line">line of text</param>
        /// <param name="ending">char array of sentence separators</param>
        /// <param name="Sentences">List of seperated sentences</param>
        /// <returns>part of the sentence in case the sentence did not end in the given line of text</returns>
        public static string SeparateSentences(string beginning, string line, char[] ending, List<string> Sentences)
        {
            string[] sentences = line.Split(ending, StringSplitOptions.RemoveEmptyEntries);

            int start;
            for (int i = 1; i < sentences.Length; i++)
            {
                int index = line.IndexOf(sentences[i]);
                start = line.IndexOf(sentences[i - 1]);
                sentences[i - 1] = line.Substring(start, index - start);
            }
            start = line.IndexOf(sentences[sentences.Length - 1]);
            sentences[sentences.Length - 1] = line.Substring(start);
            beginning += sentences[0];

            char lastSymbol = beginning[beginning.Length - 1];
            if (ending.Contains(lastSymbol))
            {
                Sentences.Add(beginning);
                beginning = "";
            }
            if (sentences.Length > 1)
            {
                for (int i = 1; i < sentences.Length - 1; i++)
                {
                    Sentences.Add(sentences[i]);
                }

                lastSymbol = sentences[sentences.Length - 1][sentences[sentences.Length - 1].Length - 1];
                if (ending.Contains(lastSymbol))
                {
                    Sentences.Add(sentences[sentences.Length - 1]);
                }
                else
                    beginning = sentences[sentences.Length - 1];
            }

            return beginning;
        }

        /// <summary>
        /// Separates string into words and gives their count
        /// </summary>
        /// <param name="sentence">line of text</param>
        /// <param name="punctuation">char array of word separators</param>
        /// <returns>number of words</returns>
        public static int WordCount(string sentence, char[] punctuation)
        {
            string[] words = sentence.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        /// <summary>
        /// Finds the longest sentence index
        /// </summary>
        /// <param name="Sentences">List of sentences</param>
        /// <param name="punctuation">char array of word separators</param>
        /// <returns>longest sentence</returns>
        public static int LongestSentence(List<string> Sentences, char[] punctuation)
        {
            int max = -1;
            int index = -1;
            for (int i = 0; i < Sentences.Count; i++)
            {
                int amount = WordCount(Sentences[i], punctuation);
                if (amount > max)
                {
                    max = amount;
                    index = i;
                }
            }
            return index;
        }
        /// <summary>
        /// Combines 2 almost similar texts from data files
        /// </summary>
        /// <param name="CFd"></param>
        /// <param name="CFd2"></param>
        /// <param name="CFr"></param>
        /// <param name="Punctuations"></param>
        public static void Combine(string CFd, string CFd2, StreamWriter CFr, string Punctuations)
        {

            string Word = "";
            StringBuilder Words = new StringBuilder();
            using (var reader2 = File.OpenText(CFd2))
            {
                while (!reader2.EndOfStream)
                {
                    char lineX = (char)reader2.Read();
                    if (!Punctuations.Contains(lineX))
                    {
                        Words.Append(lineX);
                    }
                    else
                    {
                        if (Words.ToString() != "")
                        {
                            Word = Words.ToString();
                            Words.Clear();
                            break;
                        }
                    }
                }
                using (var reader1 = File.OpenText(CFd))
                {

                Loop2:
                    bool Checker = true;
                    while (!reader1.EndOfStream)
                    {
                        char line1 = (char)reader1.Read();
                        if (Checker)
                        {
                            CFr.Write(line1);
                            if (!Punctuations.Contains(line1))
                            {
                                Words.Append(line1);
                            }
                            else
                            {
                                if ((Words.ToString().ToLower()) == (Word.ToLower()))
                                {
                                    Checker = false;
                                }
                                Words.Clear();
                            }
                        }
                        else if (!Checker)
                        {
                            if (!Punctuations.Contains(line1))
                            {
                                Words.Append(line1);
                            }
                            else
                            {
                                if (Words.ToString() != "")
                                {
                                    Word = Words.ToString();
                                    Words.Clear();
                                    goto Loop1;
                                }
                            }
                        }
                    }

                Loop1:
                    Checker = true;
                    while (!reader2.EndOfStream)
                    {
                        char line1 = (char)reader2.Read();
                        if (Checker)
                        {
                            CFr.Write(line1);
                            if (!Punctuations.Contains(line1))
                            {
                                Words.Append(line1);
                            }
                            else
                            {
                                if ((Words.ToString().ToLower()) == (Word.ToLower()))
                                {
                                    Checker = false;
                                }
                                Words.Clear();
                            }
                        }
                        else if (!Checker)
                        {
                            if (!Punctuations.Contains(line1))
                            {
                                Words.Append(line1);
                            }
                            else
                            {
                                if (Words.ToString() != "")
                                {
                                    Word = Words.ToString();
                                    Words.Clear();
                                    goto Loop2;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
