/*Задание 3: Родительский класс - партия:
• Константа const int XX=10000 - необходимая численность для того, чтобы партия могла послать своего представителя в парламент;
• Поле текущая численность;
• Поле процент голосов на последних выборах;
• Метод Q=0,3*численность+0,7*процент
Дочерний класс:
• Дополнительное логическое поле p - партия посылает своего представителя в парламент или нет;
• Метод: если посылает, то Qp=Q*1,2, В противном случае Qp=Q*0,8*/
using System;
using System.Collections.Generic;

namespace PrakticeDay_7
{
    class Program
    {
        class Party
        {
            const int XX = 10000;
            int currentX;
            int percentOfVotes;
            public double Qproc()
            {
                return 0.3 * currentX + 0.7 * percentOfVotes;
            }
        }
        class Kavo : Party
        {
            bool p;
            public Kavo(bool p)
            {
                this.p = p;
            }
            public double ЕщеОдноQproc()
            {
                if (p)
                    return Qproc() * 1.2;
                return Qproc() * 0.8;
            }
        }
        static void Main()
        {

        }
    }
}
