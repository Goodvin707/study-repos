using DataTier;
using LogicTier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationTier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Магазин logicTier = new Магазин();
            logicTier.СредняяЦенаТовара();
            logicTier.СуммарнаяЦенаПоКаждомуТовару();
            this.DataContext = logicTier;
            InitializeComponent();

            StreamReader f = new StreamReader("AveragePriceByMagazin.txt");
            while (!f.EndOfStream)
                averList.Items.Add(f.ReadLine());
            f.Close();
            f = new StreamReader("SumPriceByTovar.txt");
            while (!f.EndOfStream)
                sumList.Items.Add(f.ReadLine());
            f.Close();

            FileInfo fileInf = new FileInfo("AveragePriceByMagazin.txt");
            if (fileInf.Exists)
                fileInf.Delete();
            fileInf = new FileInfo("SumPriceByTovar.txt");
            if (fileInf.Exists)
                fileInf.Delete();
        }
    }
}