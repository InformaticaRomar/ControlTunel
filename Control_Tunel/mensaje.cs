using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control_Tunel
{
    public partial class mensaje : Form
    {
        public mensaje(Color colear, int segundos, string tunel)
        {
            InitializeComponent();
            this.BackColor = colear;
            timer1.Interval = segundos * 1000;    // pasamos de segundos a milisegundos
            lbTunel.Text = tunel;

            if (!timer1.Enabled)
                timer1.Enabled = true;
        }

        public void cambio_color(Color colear, string tunel)
        {
            this.BackColor = colear;
            lbTunel.Text = tunel;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();     // Se para el timer.
            this.Close();      // Cerramos el formulario.
        }
    }
}
