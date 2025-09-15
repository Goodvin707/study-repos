// Задание 21: В толковом словаре слова определяются с помощью других слов. Если слово v определено с помощью другого слова w, мы обозначим это как v<w .Топологическая сортировка слов в словаре означает расположение их в таком порядке, чтобы все слова, участвующие в определении данного слова, находились раньше его в словаре.
using System;
using System.Collections.Generic;
using System.Linq;

namespace Praktice_Day_9
{
    class Interpretation
    {
        string meaning;
        string interpretat; // на какое слово ссылается
        public string Meaning { get => meaning; set => meaning = value; }
        public string Interpretat { get => interpretat; set => interpretat = value; }
    }
    class Word // описание слова толкового словаря
    {
        public List<Interpretation> interpretation = new List<Interpretation>(); //спиок толкований (описания для слова)
        string word;// слово
        Interpretation Interpretation1; // на случай если новое слово будет толкованием старого (указывает на слово описуемое)
        public string GetWord() { return word; }
        public void SetWord(string value) { word = value; }
        public void explain(string str) // добавить толкование к слову word
        {
            Interpretation addDLS = new Interpretation();
            addDLS.Meaning = str;
            interpretation.Add(addDLS);
        }
        public string[] getFullInfo()
        {
            string[] array = new string[interpretation.Count];
            for (int i = 0; i < interpretation.Count; i++)
                array[i] = interpretation[i].Meaning;
            return array;
        }
        public string GetInterpretation()
        {
            return Interpretation1.Interpretat;
        }
        public void SetInterpretation(string inter)
        {
            Interpretation i = new Interpretation();
            i.Interpretat = inter;
            this.Interpretation1 = i;
        }
    }
    class Dictionary // словарь
    {
        List<Word> dictionary = new List<Word>(); // список слов словаря
        public void add(Word word) // добавить слово в слварь
        {
            dictionary.Add(word);
        }
        public string getWordinfo(int i)// достать слово из словаря под номером  i
        {
            return dictionary[i].GetWord();
        }
        public Word getWord(int i)
        {
            return dictionary[i];
        }
        public void explain(Word word, string Meaning)// добавить толкование к слову word (+ к этому добавляет толкование в словарь в ввиде полноправного слова)
        {
            Word word1 = new Word();
            word1.SetInterpretation(word.GetWord());
            word1.SetWord(Meaning);
            add(word1);
            word.explain(Meaning);
        }
        public int Count()
        {
            return dictionary.Count;
        }
        public void TopologicalSorting()
        {
            Word temp = new Word();
            temp = dictionary[0];
            dictionary.Reverse();
            dictionary[dictionary.Count - 1] = temp;
        }
    }
    class Program
    {
        static void Main()
        {
            Word word1 = new Word();
            Word word2 = new Word();
            Word word3 = new Word();
            word1.SetWord("1");
            word2.SetWord("2");
            word3.SetWord("3");
            Dictionary dictionary = new Dictionary();
            //Console.WriteLine(word1.GetWord());

            dictionary.add(word1);
            dictionary.add(word2);
            dictionary.add(word3);
            dictionary.explain(word1, "1.1");
            dictionary.explain(word1, "1.2");
            dictionary.explain(word1, "1.3");
            dictionary.explain(word2, "2.1");
            dictionary.explain(word2, "2.2");
            dictionary.explain(word2, "2.3");
            string[] array = new string[dictionary.Count()];
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(dictionary.getWord(i).GetWord());
            Console.WriteLine();
            dictionary.TopologicalSorting();
            for (int i = 0; i < dictionary.Count(); i++)
                Console.WriteLine(dictionary.getWord(i).GetWord());
            Console.WriteLine();
        }
    }
}
