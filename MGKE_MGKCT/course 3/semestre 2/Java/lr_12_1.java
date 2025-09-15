// Задание 1: Требуется реализовать приложение, обладающее следующими функциональными возможностями: для заданного текста, поиск подстроки в строке, получение - количества слов, количества символов с учетом пробелов, без учета пробелов, количества гласных букв, количества согласных букв, поиск слов с максимальной и минимальной длиной.  Для представления строк использовать класс java.lang.String и его методы.

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
 
public class Main
{
    static char[] glasnye = "аоэеиыуёюя".toCharArray();
    static char[] soglasnye = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩ".toCharArray();
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
     
     
    public static void main(String[] args) {
        System.out.println("Используется только русский алфавит\n\n\n");
        Scanner in = new Scanner(System.in);
        System.out.print("Введите текст: ");
        String text = in.nextLine();
        System.out.print("Введите что искать: ");
        String findMe = in.nextLine();
        Search(text, findMe);
        WordCount(text);
        SymbolCount(text);
        SymbolCountWithoutSpaces(text);
        GlasnyeCount(text);
        SoglasnyeCount(text);
        LongestWord(text);
        ShortestWord(text);
    }
}
