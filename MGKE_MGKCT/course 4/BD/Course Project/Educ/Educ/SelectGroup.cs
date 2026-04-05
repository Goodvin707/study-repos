using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Educ
{
    public partial class SelectGroup : Form
    {
        public SelectGroup()
        {
            InitializeComponent();
            DataTransfer.connection.Open();
            MySqlDataReader rdr = new MySqlCommand($"SELECT Concat(id, ' ', title) FROM university.groupes", DataTransfer.connection).ExecuteReader();
            List<string> values = new List<string>();
            while (rdr.Read())
                values.Add(rdr.GetString(0));
            rdr.Close();
            listBox1.DataSource = values.ToArray();
            DataTransfer.connection.Close();
        }

        private void button1_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;
    }
}