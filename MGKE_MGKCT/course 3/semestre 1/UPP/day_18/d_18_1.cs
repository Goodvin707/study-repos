/*Задание 1: Дан файл f, содержащий данные о постоянных магнитах: марка сплава, индукция насыщения, остаточная индукция, коэрцитивная сила. Вывести данные о постоянных магнитах, которые:
а) имеют индукцию насыщения не более 1,8 Тл и остаточную индукцию не менее 0,6 Тл;
б) имеют остаточную индукцию не более 1,2 Тл и коэрцитивную силу не менее 500кА/м;
в) имеют коэрцитивную силу не более 900 кА/м и индукцию насыщения не менее 1,3 Тл.*/

using System;
using System.IO;
using System.Collections.Generic;
namespace _18_1
{
    class PermanentMagnets
    {
        public string AlloyMark { get; set; }
        public double SaturationInduction { get; set; }
        public double ResidualInduction { get; set; }
        public int CoerciveForce { get; set; }
        public PermanentMagnets(string alloyMark, double saturationInduction, double residualInduction, int coerciveForce)
        {
            AlloyMark = alloyMark;
            SaturationInduction = saturationInduction;
            ResidualInduction = residualInduction;
            CoerciveForce = coerciveForce;
        }
        public override string ToString() => $"AlloyMark: {AlloyMark}\nSaturationInduction: {SaturationInduction} Тл\nResidualInduction: {ResidualInduction} Тл\nCoerciveForce: {CoerciveForce} кА/м\n";
    }
    class Program
    {
        static string AlloyGen() // функция для заполнения файла "f.txt" условием
        {
            Random r = new Random();
            string s = "";
            s += Convert.ToChar(r.Next(1040, 1062)) + r.Next(10, 36).ToString() + Convert.ToChar(r.Next(1072, 1096)) + "; "; // генерация марки сплава
            int sirev = r.Next(1, 10); 
            s += sirev + Math.Round(r.NextDouble(), 1) + "; "; // генерация индукции насыщения
            s += sirev - r.Next(1, sirev) + Math.Round(r.NextDouble(), 1) + "; "; // генерация остаточной индукции
            s += r.Next(100, 1000); // коэрцитивная сила
            return s;
        }
        static void Main()
        {
            List<PermanentMagnets> permanentMagnets = new List<PermanentMagnets>();
            //StreamWriter sw = new StreamWriter("f.txt"); // Заполнение файла f.txt для условия
            //for (int i = 0; i < 15; i++)
            //    sw.WriteLine(AlloyGen());
            //sw.Close();

            StreamReader sr = new StreamReader("f.txt");
            string s = sr.ReadLine();
            while (s != null)
            {
                string[] sarr = s.Split("; ");
                permanentMagnets.Add(new PermanentMagnets(sarr[0], Convert.ToDouble(sarr[1]), Convert.ToDouble(sarr[2]), Convert.ToInt32(sarr[3])));
                s = sr.ReadLine();
            }
            sr.Close();

            Console.WriteLine("Выберите, какие данные вывести");
            Console.WriteLine("1. Данные о постоянных магнитах, имеющие индукцию насыщения не более 1,8 Тл и остаточную индукцию не менее 0,6 Тл");
            Console.WriteLine("2. Данные о постоянных магнитах, имеющие остаточную индукцию не более 1,2 Тл и коэрцитивную силу не менее 500кА/м");
            Console.WriteLine("3. Данные о постоянных магнитах, имеющие коэрцитивную силу не более 900 кА/м и индукцию насыщения не менее 1,3 Тл");
            int menu = int.Parse(Console.ReadLine());
            switch (menu)
            {
                case 1:
                    for (int i = 0; i < permanentMagnets.Count; i++)
                        if (permanentMagnets[i].SaturationInduction <= 1.8 && permanentMagnets[i].ResidualInduction >= 0.6)
                            Console.WriteLine(permanentMagnets[i].ToString());
                    break;
                case 2:
                    for (int i = 0; i < permanentMagnets.Count; i++)
                        if (permanentMagnets[i].ResidualInduction <= 1.2 && permanentMagnets[i].CoerciveForce >= 500)
                            Console.WriteLine(permanentMagnets[i].ToString());
                    break;
                case 3:
                    for (int i = 0; i < permanentMagnets.Count; i++)
                        if (permanentMagnets[i].CoerciveForce <= 900 && permanentMagnets[i].SaturationInduction >= 1.3)
                            Console.WriteLine(permanentMagnets[i].ToString());
                    break;
                default:
                    Console.WriteLine("Ну лан...");
                    break;
            }
        }
    }
}
