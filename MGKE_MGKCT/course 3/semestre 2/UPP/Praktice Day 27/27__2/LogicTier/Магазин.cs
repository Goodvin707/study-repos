using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier
{
    public class Магазин
    {
        List<ТоварнаяПозиция> _товары = new List<ТоварнаяПозиция>();
        public Магазин()
        {
            List<Товар> tmp = ВсеТовары.ПолучитьВсеТовары();
            foreach (var t in tmp)
            {
                _товары.Add(new ТоварнаяПозиция(t));
            }
        }
        public List<ТоварнаяПозиция> СписокТоваров
        {
            get { return _товары; }
        }
        public String НаименованиеМагазина
        {
            get { return "Наш магазин"; }
        }
        public float СуммарнаяСтоимость
        {
            get
            {
                return _товары.Sum(p => p.СуммарнаяСтоимостьПозиции);
            }
        }
        public float СуммарноеКоличество
        {
            get
            {
                return _товары.Sum(p => p.КоличествоТовара);
            }
        }
    }
}