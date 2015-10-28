using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankV1
{
    public partial class Illustrate : Form
    {
        public Illustrate()
        {
            InitializeComponent();
        }



        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.W:
                    {
                        MessageBox.Show("you pressed w");
                        break;
                    }
                case Keys.B:
                    {
                        MessageBox.Show("you pressed b");
                        break;
                    }
                case Keys.F11:
                    {
                        MessageBox.Show("you pressed F11");
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("you pressed "+e.KeyData);
                        break;
                    }
            }
        }
    }
}
