using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class Товар
    {
        public String Код { get; set; }
        public String Наименование { get; set; }
        public float Цена { get; set; }
        public int Количество { get; set; }
        public String Описание { get; set; }
    }
}