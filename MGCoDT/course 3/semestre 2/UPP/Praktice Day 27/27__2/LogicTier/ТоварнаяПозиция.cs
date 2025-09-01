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
        private Товар _товар;
        public ТоварнаяПозиция(Товар p)
        {
            _товар = p;
        }
        public String КодТовара
        {
            get { return _товар.Код; }
            set { _товар.Код = value; }
        }
        public String НаименованиеТовара
        {
            get { return _товар.Наименование; }
            set { _товар.Наименование = value; }
        }
        public float ЦенаТовара
        {
            get { return _товар.Цена; }
            set { _товар.Цена = value; }
        }
        public int КоличествоТовара
        {
            get { return _товар.Количество; }
            set { _товар.Количество = value; }
        }
        public String ОписаниеТовара
        {
            get { return _товар.Описание; }
            set { _товар.Описание = value; }
        }
        public float СуммарнаяСтоимостьПозиции
        {
            get { return _товар.Цена * _товар.Количество; }
        }
        public String ПредставлениеТовара
        {
            get
            {
                return _товар.Код + "  :  " + _товар.Наименование + " (" + _товар.Цена.ToString("С") + ")";
            }
        }
    }
}