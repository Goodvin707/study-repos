using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Приложение_Windows
{
    public partial class frmCalculations : Form
    {
        Calculator Calculator1;
        public delegate void FHandler(double Value, double Calculations);
        public delegate void A2Handler(int Value, double Calculations);
        public delegate void LDHandler(double Calculations, int Count);

        public frmCalculations()
        {
            InitializeComponent();
            Calculator1 = new Calculator();
            Calculator1.FactorialComplete += new Calculator.FactorialCompleteHandler(this.FactorialHandler);
            Calculator1.FactorialMinusOneComplete += new Calculator.FactorialCompleteHandler(this.FactorialMinusHandler);
            Calculator1.AddTwoComplete += new Calculator.AddTwoCompleteHandler(this.AddTwoHandler);
            Calculator1.LoopComplete += new Calculator.LoopCompleteHandler(this.LoopDoneHandler);
        }

        public void FactHandler(double Value, double Calculations)
        {
            lblFactorial1.Text = Value.ToString();
            // Re-enables the button so it can be used again.
            btnFactorial1.Enabled = true;
            // Updates the label that displays the total calculations performed
            lblTotalCalculations.Text = "TotalCalculations are " + Calculations.ToString();
        }
        public void Fact1Handler(double Value, double Calculations)
        {
            lblFactorial2.Text = Value.ToString();
            btnFactorial2.Enabled = true;
            lblTotalCalculations.Text = "TotalCalculations are " + Calculations.ToString();
        }
        public void Add2Handler(int Value, double Calculations)
        {
            lblAddTwo.Text = Value.ToString();
            btnAddTwo.Enabled = true;
            lblTotalCalculations.Text = "TotalCalculations are " + Calculations.ToString();
        }
        public void LDoneHandler(double Calculations, int Count)
        {
            btnRunLoops.Enabled = true;
            lblRunLoops.Text = Count.ToString();
            lblTotalCalculations.Text = "TotalCalculations are " + Calculations.ToString();
        }

        private void btnFactorial1_Click(object sender, EventArgs e)
        {
            Calculator1.varFact1 = int.Parse(txtValue.Text);
            // Disables the btnFactorial1 until this calculation is complete.
            btnFactorial1.Enabled = false;
            // Calculator1.Factorial();
            Calculator1.ChooseThreads(1);
        }

        private void btnFactorial2_Click(object sender, EventArgs e)
        {
            Calculator1.varFact2 = int.Parse(txtValue.Text);
            btnFactorial2.Enabled = false;
            // Calculator1.FactorialMinusOne();
            Calculator1.ChooseThreads(2);
        }

        private void btnAddTwo_Click(object sender, EventArgs e)
        {
            Calculator1.varAddTwo = int.Parse(txtValue.Text);
            btnAddTwo.Enabled = false;
            // Calculator1.AddTwo();
            Calculator1.ChooseThreads(3);
        }

        private void btnRunLoops_Click(object sender, EventArgs e)
        {
            Calculator1.varLoopValue = int.Parse(txtValue.Text);
            btnRunLoops.Enabled = false;
            // Lets the user know that a loop is running
            lblRunLoops.Text = "Looping";
            // Calculator1.RunALoop();
            Calculator1.ChooseThreads(4);
        }

        private void FactorialHandler(double Value, double Calculations)
        {
            // BeginInvoke causes asynchronous execution to begin at the address
            // specified by the delegate. Simply put, it transfers execution of 
            // this method back to the main thread. Any parameters required by 
            // the method contained at the delegate are wrapped in an object and 
            // passed. 
            this.BeginInvoke(new FHandler(FactHandler), new Object[]
               {Value, Calculations});
        }

        private void FactorialMinusHandler(double Value, double Calculations)
        {
            this.BeginInvoke(new FHandler(Fact1Handler), new Object[] {Value, Calculations});
        }

        private void AddTwoHandler(int Value, double Calculations)
        {
            this.BeginInvoke(new A2Handler(Add2Handler), new Object[] {Value, Calculations});
        }

        private void LoopDoneHandler(double Calculations, int Count)
        {
            this.BeginInvoke(new LDHandler(LDoneHandler), new Object[] {Calculations, Count});
        }
    }
}