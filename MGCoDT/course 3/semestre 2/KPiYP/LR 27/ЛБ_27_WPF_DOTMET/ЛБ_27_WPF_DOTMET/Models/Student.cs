using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛБ_27_WPF_DOTMET.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Num_book { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public int Year { get; set; }

        public int SessionId { get; set; }
    }
}
