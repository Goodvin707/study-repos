/*Задание 1:
1. Реализовать многопоточное приложение, реализующее поиск подстроки в файлах. Список файлов передается в качестве параметра командной строки. Для каждого файла выделяется отдельный поток. Для вывода результатов поиска в консоль создается отдельный поток, считывающий данные по мере поступления из разделяемого списка объектов класса SearchResult, имеющего следующего поля «имя файла», «индекс вхождения».
2. Реализовать многопоточное приложение, реализующее вывод всех четных слов из списка файлов. Для каждого файла создается новый поток, но общее число потоков не должно превышать 10.*/

package com.company;
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Stream;

class SearchResult2 implements Runnable{

    Scanner file;
    String string = "";

    public SearchResult2(FileReader file){
        this.file = new Scanner(file);

    }

    public void run(){

        while(file.hasNextLine())
            string += file.nextLine() + " ";
        var array = string.split(" ");
        for(int i = 0; i < array.length;i++){
            if(i % 2 == 0)
                System.out.print(array[i] + "\t");
        }
    }
}

class SearchResult implements Runnable{

    Scanner file;
    String findString;
    String string = "";

    public SearchResult(String findString, FileReader file){
        this.file = new Scanner(file);
        this.findString = findString;

    }

    public void run(){
        while(file.hasNextLine())
            string += file.nextLine() + " ";
            Pattern pattern = Pattern.compile("(\\w+)");
            Matcher matcher = pattern.matcher(string);
            while (matcher.find())
                System.out.println(matcher.group());
    }
}

public class Main {
    public static void main(String[] args) throws FileNotFoundException {
        System.out.println("Лабораторная работа №14 Часть 1");

        System.out.println("Перечень файлов:");
        System.out.println("file1.txt \t file6.txt \n" +
                            "file2.txt \t file7.txt \n" +
                            "file3.txt \t file8.txt \n" +
                            "file4.txt \t file9.txt \n" +
                            "file5.txt \t file10.txt \n" +
                            "file11.txt");

        var scan = new Scanner(System.in);
        String openFileString="";
        int selectFile = 0;
        int fileCount = 0;
        List<FileReader> readLineList = new ArrayList();

        while(true){
            System.out.println("continue - Начать работу с файлами");
            System.out.print("Чтобы окрыть файл, введите его имя: ");
            openFileString = scan.nextLine();
            if(openFileString.equals("continue")){
                break;
            }
            else try{
                readLineList.add(new FileReader(openFileString));
            }catch (FileNotFoundException e){
                System.out.println("Файл не был найден");
            }
        }

        System.out.print("Введите искомое слово: ");
        var findeString = scan.nextLine();

        for(int i = 0 ;i < readLineList.size();i++){
            var test = new Thread(new SearchResult(findeString, readLineList.get(i)));
            test.start();
        }
        System.out.println("Лабораторная работа №14 Часть 2");

        System.out.println("Перечень файлов:");
        System.out.println("file1.txt \t file7.txt \n" +
                "file2.txt \t file8.txt \n" +
                "file3.txt \t file9.txt \n" +
                "file4.txt \t file10.txt \n" +
                "file5.txt \t file111.txt \n" +
                "file6.txt");

        int threadCount = 0;
        while(true){
            System.out.println("continue - Начать работу с файлами");
            System.out.print("Чтобы окрыть файл, введите его имя: ");
            openFileString = scan.nextLine();
            threadCount+=1;
            if(openFileString.equals("continue") || threadCount == 10){
                break;
            }
            else try{
                readLineList.add(new FileReader(openFileString));
            }catch (FileNotFoundException e){
                System.out.println("Файл не был найден");
            }
        }
        System.out.println("Спсиок четных слов из выбранных файлов:");
        for(int i = 0 ;i < readLineList.size();i++){
            var test = new Thread(new SearchResult2(readLineList.get(i)));
            test.start();
        }
    }
}