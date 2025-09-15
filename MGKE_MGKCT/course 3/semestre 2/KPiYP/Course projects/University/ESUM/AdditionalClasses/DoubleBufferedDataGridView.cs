using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESUM
{
    class DoubleBufferedDataGridView : DataGridView
    {
        public DoubleBufferedDataGridView() : base() { }
        protected override bool DoubleBuffered { get => true; }
    }
}