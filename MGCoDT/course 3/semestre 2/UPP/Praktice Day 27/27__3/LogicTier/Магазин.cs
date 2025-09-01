using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogicTier
{
    public class Магазин
    {
        List<ТоварнаяПозиция> товары = new List<ТоварнаяПозиция>();
        List<string> магазины = new List<string>();
        public Магазин()
        {
            List<Товар> tmp = ВсеТовары.ПолучитьВсеТовары();
            foreach (var t in tmp)
            {
                товары.Add(new ТоварнаяПозиция(t));
            }
        }
        public List<ТоварнаяПозиция> СписокТоваров
        {
            get { return товары; }
        }
        public String НаименованиеМагазина
        {
            get { return "27__3"; }
        }
        public double СуммарнаяСтоимость
        {
            get { return товары.Sum(p => p.СуммарнаяСтоимостьПозиции); }
        }
        public double СуммарноеКоличество
        {
            get { return товары.Sum(p => p.КоличествоТовара); }
        }
        public void СредняяЦенаТовара()
        {
            List<ТоварнаяПозиция> товарыПоМагазину = new List<ТоварнаяПозиция>();
            for (int i = 0; i < товары.Count; i++)
            {
                if (!магазины.Contains(товары[i].ОписаниеТовара))
                    магазины.Add(товары[i].ОписаниеТовара);
            }

            StreamWriter sw = new StreamWriter("AveragePriceByMagazin.txt");
            for (int i = 0; i < магазины.Count; i++)
            {
                for (int j = 0; j < товары.Count; j++)
                {
                    if (магазины[i] == товары[j].ОписаниеТовара)
                        товарыПоМагазину.Add(товары[j]);
                }
                sw.WriteLine(магазины[i] + ": " + товарыПоМагазину.Average(p => p.ЦенаТовара));
                товарыПоМагазину.Clear();
            }
            sw.Close();
        }
        public void СуммарнаяЦенаПоКаждомуТовару()
        {
            List<ТоварнаяПозиция> товарыПоМагазину = new List<ТоварнаяПозиция>();
            List<string> названияТоваров = new List<string>();
            for (int i = 0; i < товары.Count; i++)
            {
                if (!названияТоваров.Contains(товары[i].НаименованиеТовара))
                    названияТоваров.Add(товары[i].НаименованиеТовара);
            }
            StreamWriter sw = new StreamWriter("SumPriceByTovar.txt");
            for (int i = 0; i < названияТоваров.Count; i++)
            {
                for (int j = 0; j < товары.Count; j++)
                {
                    if (названияТоваров[i] == товары[j].НаименованиеТовара)
                        товарыПоМагазину.Add(товары[j]);
                }
                sw.WriteLine(названияТоваров[i] + ": " + товарыПоМагазину.Sum(p => p.ЦенаТовара));
                товарыПоМагазину.Clear();
            }
            sw.Close();
        }
    }
}