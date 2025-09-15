using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Приложение_Windows
{
    public partial class Calculator : Component
    {
        // Declares the variables you will use to hold your thread objects.
        public System.Threading.Thread FactorialThread;
        public System.Threading.Thread FactorialMinusOneThread;
        public System.Threading.Thread AddTwoThread;
        public System.Threading.Thread LoopThread;

        public int varAddTwo;
        public int varFact1;
        public int varFact2;
        public int varLoopValue;
        public double varTotalCalculations = 0;

        // This delegate will be invoked with two of your events.
        public delegate void FactorialCompleteHandler(double Factorial, double TotalCalculations);
        public delegate void AddTwoCompleteHandler(int Result, double TotalCalculations);
        public delegate void LoopCompleteHandler(double TotalCalculations, int Counter);

        public event FactorialCompleteHandler FactorialComplete;
        public event FactorialCompleteHandler FactorialMinusOneComplete;
        public event AddTwoCompleteHandler AddTwoComplete;
        public event LoopCompleteHandler LoopComplete;

        public Calculator()
        {
            InitializeComponent();
        }

        public Calculator(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        // This method will calculate the value of a number factorial.
        // (varFact1!)
        public void Factorial()
        {
            double varResult = 1;
            double varTotalAsOfNow = 0;
            for (int varX = 1; varX <= varFact1; varX++)
            {
                varResult *= varX;
                lock (this)
                {
                    varTotalCalculations += 1;
                    varTotalAsOfNow = varTotalCalculations;
                }
            }
            FactorialComplete(varResult, varTotalAsOfNow);
        }

        // This method will calculate the value of a number minus 1 factorial
        // (varFact2-1!).
        public void FactorialMinusOne()
        {
            double varTotalAsOfNow = 0;
            double varResult = 1;
            // Performs a factorial calculation on varFact2 - 1.
            for (int varX = 1; varX <= varFact2 - 1; varX++)
            {
                varResult *= varX;
                // Increments varTotalCalculations and keeps track of the current 
                // total as of this instant.
                lock (this)
                {
                    varTotalCalculations += 1;
                    varTotalAsOfNow = varTotalCalculations;
                }
            }
            // Signals that the method has completed, and communicates the 
            // result and a value of total calculations performed up to this 
            // point.
            FactorialMinusOneComplete(varResult, varTotalAsOfNow);
        }

        // This method will add two to a number (varAddTwo+2).
        public void AddTwo()
        {
            double varTotalAsOfNow = 0;
            int varResult = varAddTwo + 2;
            lock (this)
            {
                varTotalCalculations += 1;
                varTotalAsOfNow = varTotalCalculations;
            }
            AddTwoComplete(varResult, varTotalAsOfNow);
        }

        // This method will run a loop with a nested loop varLoopValue times.
        public void RunALoop()
        {
            int varX;
            double varTotalAsOfNow = 0;
            for (varX = 1; varX <= varLoopValue; varX++)
            {
                // This nested loop is added solely for the purpose of slowing down
                // the program and creating a processor-intensive application.
                for (int varY = 1; varY <= 500; varY++)
                {
                    lock (this)
                    {
                        varTotalCalculations += 1;
                        varTotalAsOfNow = varTotalCalculations;
                    }
                }
            }
            LoopComplete(varTotalAsOfNow, varLoopValue);
        }

        public void ChooseThreads(int threadNumber)
        {
            // Determines which thread to start based on the value it receives.
            switch (threadNumber)
            {
                case 1:
                    // Sets the thread using the AddressOf the subroutine where
                    // the thread will start.
                    FactorialThread = new System.Threading.Thread(new
                       System.Threading.ThreadStart(this.Factorial));
                    // Starts the thread.
                    FactorialThread.Start();
                    break;
                case 2:
                    FactorialMinusOneThread = new
                       System.Threading.Thread(new
                          System.Threading.ThreadStart(this.FactorialMinusOne));
                    FactorialMinusOneThread.Start();
                    break;
                case 3:
                    AddTwoThread = new System.Threading.Thread(new
                        System.Threading.ThreadStart(this.AddTwo));
                    AddTwoThread.Start();
                    break;
                case 4:
                    LoopThread = new System.Threading.Thread(new
                       System.Threading.ThreadStart(this.RunALoop));
                    LoopThread.Start();
                    break;
            }
        }
    }
}