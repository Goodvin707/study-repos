using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛБ_27_WPF_DOTMET.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int Mathematics { get; set; }
        public int Informatics { get; set; }
        public int Philosophy { get; set; }

        public int StudentId { get; set; }
    }
}