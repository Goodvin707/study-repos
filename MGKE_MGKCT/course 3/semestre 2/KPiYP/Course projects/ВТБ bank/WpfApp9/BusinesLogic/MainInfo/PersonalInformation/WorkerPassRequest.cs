using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9.BusinesLogic.MainInfo.PersonalInformation
{
    internal class WorkerPassRequest
    {
        public string RequestNumber { get; set; }
        public string NameCreator { get; set; }
        public string SurnameCreator { get; set; }
        public string PatronymicCreator { get; set; }
        public string LeadName { get; set; }
        public string LeadSurnam { get; set; }
        public string LeadPatronymic { get; set; }
        public string Reason { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string RoomNumber { get; set; }
        public string AdressPass { get; set; }
        public string StartTimeWork { get; set; }
        public string StartDateWork { get; set; }
        public string EndTimeWork { get; set; }
        public string EndDateWork { get; set; }
        public bool In { get; set; }
        public bool Out { get; set; }
    }
}
