using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier
{
    public class ТоварнаяПозиция
    {
        private Товар товар;
        public ТоварнаяПозиция(Товар p)
        {
            товар = p;
        }
        public String КодТовара
        {
            get { return товар.Код; }
            set { товар.Код = value; }
        }
        public String НаименованиеТовара
        {
            get { return товар.Наименование; }
            set { товар.Наименование = value; }
        }
        public double ЦенаТовара
        {
            get { return товар.Цена; }
            set { товар.Цена = value; }
        }
        public int КоличествоТовара
        {
            get { return товар.Количество; }
            set { товар.Количество = value; }
        }
        public String ОписаниеТовара
        {
            get { return товар.Магазин; }
            set { товар.Магазин = value; }
        }
        public double СуммарнаяСтоимостьПозиции
        {
            get { return товар.Цена * товар.Количество; }
        }
        public String ПредставлениеТовара
        {
            get
            {
                return товар.Код + "  :  " + товар.Наименование + "  :  " + ЦенаТовара;
            }
        }
    }
}