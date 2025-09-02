using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp9
{
    public class SpeedCommandsAdministrator
    {
        static SpeedCommandsAdministrator()
        {
            Opn = new RoutedCommand("OpnCommand", typeof(Administrator));
        }
        public static RoutedCommand Opn { get; set; }
    }
    public class SpeedCommandsChiefSpecialist
    {
        static SpeedCommandsChiefSpecialist()
        {
            Opn = new RoutedCommand("OpnCommand", typeof(ChiefSpecialist));
        }
        public static RoutedCommand Opn { get; set; }
    }
    public class SpeedCommandsHeadDepartament
    {
        static SpeedCommandsHeadDepartament()
        {
            Opn = new RoutedCommand("OpnCommand", typeof(HeadDepartament));
            Opn2 = new RoutedCommand("OpnCommand", typeof(HeadDepartament));
        }
        public static RoutedCommand Opn { get; set; }
        public static RoutedCommand Opn2 { get; set; }
    }
    public class SpeedCommandsHeadScurityDepartament
    {
        static SpeedCommandsHeadScurityDepartament()
        {
            Opn = new RoutedCommand("OpnCommand", typeof(HeadSecurityDepartament));
        }
        public static RoutedCommand Opn { get; set; }
    }
    public class SpeedCommandsSecurityGuard
    {
        static SpeedCommandsSecurityGuard()
        {
            Opn = new RoutedCommand("OpnCommand", typeof(SecurityGuard));
        }
        public static RoutedCommand Opn { get; set; }
    }
    public class SpeedCommandsLeadingSecialist
    {
        static SpeedCommandsLeadingSecialist()
        {
            Opn = new RoutedCommand("OpnCommand", typeof(leadingSecialist));
        }
        public static RoutedCommand Opn { get; set; }
    }
    public class SpeedCommandsMainWindow
    {
        static SpeedCommandsMainWindow()
        {
            Opn = new RoutedCommand("OpnCommand", typeof(MainWindow));
        }
        public static RoutedCommand Opn { get; set; }
    }

}
