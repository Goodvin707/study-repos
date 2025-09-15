// Задание 5: Реализовать на основе приложения, использующего класс реализованный в № 3, возможность дополнения начального введённого текста.

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
 
public class Main
{
    static char[] glasnye = "аоэеиыуёюя".toCharArray();
    static char[] soglasnye = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩ".toCharArray();
    static class Searcher {
        public static void Search(String text, String findMe)
        {
            int count = 0;
            for (int i = 0; i < text.length(); i++)
            {
                int j = 0;
                while (text.charAt(i) == findMe.charAt(j))
                {
                    if (j == findMe.length() - 1)
                    {
                        System.out.println((i - findMe.length() + 1) + " -- индекс вхождения первой буквы слова");
                        System.out.println(i + " -- индекс вхождения последней буквы слова\n");
                        count++;
                        break;
                    }
                    if (i < text.length() - 1)
                        i++;
                    j++;
                }
            }
            System.out.println("Введенная строка была найдена " + count + " раз(а)");
        }
        public static void WordCount(String text)
        {
            System.out.println("Количество слов: " + text.split(" ").length);
        }
        public static void SymbolCount(String text)
        {
            System.out.println("Количество символов с учетом пробелов: " + text.length());
        }
        public static void SymbolCountWithoutSpaces(String text)
        {
            System.out.println("Количество символов без учета пробелов: " + text.replaceAll(" ", "").length());
        }
        public static void GlasnyeCount(String text)
        {
            int count = 0;
            for (int i = 0; i < text.length(); i++)
            {
                for (char x : glasnye) {
                    if (x == Character.toLowerCase(text.charAt(i))) {
                        count++;
                        break;
                    }
                }
            }
            System.out.println("Количество гласных букв: " + count);
        }
        public static void SoglasnyeCount(String text)
        {
            int count = 0;
            for (int i = 0; i < text.length(); i++)
            {
                for (char x : soglasnye) {
                    if (x == Character.toUpperCase(text.charAt(i))) {
                        count++;
                        break;
                    }
                }
            }
            System.out.println("Количество согласных букв: " + count);
        }
        public static void LongestWord(String text) {
            String words[] = text.split(" ");
            Arrays.sort(words);
             
            int len = 0;
            String longest = "";
            for (String string : words) {
                if (string.length() > len) {
                    len = string.length();
                    longest = string;
                }
            }
             
            System.out.println("Самое длинное слово: " + longest);
        }
        public static void ShortestWord(String text) {
            String words[] = text.split(" ");
            Arrays.sort(words);
             
            int len = text.length();
            String shortest = "";
            for (String string : words) {
                if (string.length() < len) {
                    len = string.length();
                    shortest = string;
                }
            }
             
            System.out.println("Самое короткое слово: " + shortest);
        }
         
        // Overrided methods for StringBuffer
        public static void Search(StringBuffer text, StringBuffer findMe)
        {
            int count = 0;
            for (int i = 0; i < text.length(); i++)
            {
                int j = 0;
                while (text.charAt(i) == findMe.charAt(j))
                {
                    if (j == findMe.length() - 1)
                    {
                        System.out.println((i - findMe.length() + 1) + " -- индекс вхождения первой буквы слова");
                        System.out.println(i + " -- индекс вхождения последней буквы слова\n");
                        count++;
                        break;
                    }
                    if (i < text.length() - 1)
                        i++;
                    j++;
                }
            }
            System.out.println("Введенная строка была найдена " + count + " раз(а)");
        }
        public static void WordCount(StringBuffer sbtext)
        {
            String text = sbtext.toString();
            System.out.println("Количество слов: " + text.split(" ").length);
        }
        public static void SymbolCount(StringBuffer sbtext)
        {
            String text = sbtext.toString();
            System.out.println("Количество символов с учетом пробелов: " + text.length());
        }
        public static void SymbolCountWithoutSpaces(StringBuffer sbtext)
        {
            String text = sbtext.toString();
            System.out.println("Количество символов без учета пробелов: " + text.replaceAll(" ", "").length());
        }
        public static void GlasnyeCount(StringBuffer sbtext)
        {
            String text = sbtext.toString();
            int count = 0;
            for (int i = 0; i < text.length(); i++)
            {
                for (char x : glasnye) {
                    if (x == Character.toLowerCase(text.charAt(i))) {
                        count++;
                        break;
                    }
                }
            }
            System.out.println("Количество гласных букв: " + count);
        }
        public static void SoglasnyeCount(StringBuffer sbtext)
        {
            String text = sbtext.toString();
            int count = 0;
            for (int i = 0; i < text.length(); i++)
            {
                for (char x : soglasnye) {
                    if (x == Character.toUpperCase(text.charAt(i))) {
                        count++;
                        break;
                    }
                }
            }
            System.out.println("Количество согласных букв: " + count);
        }
        public static void LongestWord(StringBuffer sbtext) {
            String text = sbtext.toString();
            String words[] = text.split(" ");
            Arrays.sort(words);
             
            int len = 0;
            String longest = "";
            for (String string : words) {
                if (string.length() > len) {
                    len = string.length();
                    longest = string;
                }
            }
             
            System.out.println("Самое длинное слово: " + longest);
        }
        public static void ShortestWord(StringBuffer sbtext) {
            String text = sbtext.toString();
            String words[] = text.split(" ");
            Arrays.sort(words);
             
            int len = text.length();
            String shortest = "";
            for (String string : words) {
                if (string.length() < len) {
                    len = string.length();
                    shortest = string;
                }
            }
             
            System.out.println("Самое короткое слово: " + shortest);
        }
    }
     
    public static void main(String[] args) {
        System.out.println("Используется только русский алфавит\n\n\n");
        Scanner in = new Scanner(System.in);
        System.out.print("Введите текст: ");
        String text = in.nextLine();
         
        System.out.println("Хотите дополнить текст?\n1.Да   2.Нет");
        if (in.nextLine().equals("1"))
        {
            System.out.print("Введите дополнительный текст: ");
            text += in.nextLine();
        }
        System.out.print("Введите что искать: ");
        String findMe = in.nextLine();
        Searcher.Search(text, findMe);
        Searcher.WordCount(text);
        Searcher.SymbolCount(text);
        Searcher.SymbolCountWithoutSpaces(text);
        Searcher.GlasnyeCount(text);
        Searcher.SoglasnyeCount(text);
        Searcher.LongestWord(text);
        Searcher.ShortestWord(text);
         
         
        System.out.println("-----------------Overrided methods for StringBuffer-----------------");
        StringBuffer sbtext = new StringBuffer(text);
        StringBuffer sbfindMe = new StringBuffer(findMe);
        Searcher.Search(sbtext, sbfindMe);
        Searcher.WordCount(sbtext);
        Searcher.SymbolCount(sbtext);
        Searcher.SymbolCountWithoutSpaces(sbtext);
        Searcher.GlasnyeCount(sbtext);
        Searcher.SoglasnyeCount(sbtext);
        Searcher.LongestWord(sbtext);
        Searcher.ShortestWord(sbtext);
    }
}
