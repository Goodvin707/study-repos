using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DataTier
{
    public class ВсеТовары
    {
        public static List<Товар> ПолучитьВсеТовары()
        {
            List<Товар> list = new List<Товар>();
            StreamReader f = new StreamReader("input.txt");
            int i = 0;
            string[] s;
            while (!f.EndOfStream)
            {
                s = f.ReadLine().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                list.Add(
                    new Товар()
                    {
                        Код = (i + 1).ToString(),
                        Наименование = s[0].Trim(),
                        Цена = Convert.ToDouble(s[1].Trim()),
                        Количество = Convert.ToInt32(s[2].Trim()),
                        Магазин = s[3].Trim()
                    });
                i++;
            }
            f.Close();
            return list;
        }
    }
}