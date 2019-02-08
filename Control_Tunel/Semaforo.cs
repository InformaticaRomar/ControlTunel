using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utiles;

namespace Control_Tunel
{


    public partial class Semaforo : Form
    {
        public int color;
        public System.Drawing.Graphics graphics;
        public System.Drawing.Graphics graphics2;
        public bool abierto;
        public Semaforo()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            graphics2 = this.CreateGraphics();
            this.button1.Enabled = false;
            abierto = false;
            timer1.Enabled = true;
            color = 0;

        }
        private DataTable Obtener_Tiempo()
        {
            string sql = @"select  max (fecha_creacion) as Fecha,
DATEDIFF( minute, max(fecha_creacion),GETDATE())/60 as Horas,
 DATEDIFF( minute, max(fecha_creacion),GETDATE())%60 as Minutos,
  DATEDIFF( minute, max(fecha_creacion),GETDATE()) as tiempo,
 TUNEL from CONTROL_TUNEL group by TUNEL";
            Quality con = new Quality();
             return con.Sql_Datatable(sql);
        }
        private void process()
        {
            DataTable datos = Obtener_Tiempo();
            int tunel = -9999;
            int minutos = -9999;
            foreach (DataRow a in datos.AsEnumerable())
            {
                int.TryParse(a[4].ToString(), out tunel);
                int.TryParse(a[3].ToString(), out minutos);
               // abierto = true;
                if (tunel == 1)
                {
                   
                    label1.Text = "";
                    label3.Text = "TUNEL 1";
                    label3.Location = new System.Drawing.Point(20, 181);
                    label1.Location = new System.Drawing.Point(0, 0);
                    label1.Text = a[0].ToString();
                    if (minutos >= 10)
                    {
                        graphics.FillEllipse(System.Drawing.Brushes.Green, 20, 120, 50, 50);
                    }
                    else if (minutos == 9)
                    {
                        graphics.FillEllipse(System.Drawing.Brushes.Yellow, 20, 70, 50, 50);
                    }
                    else
                    {
                        graphics.FillEllipse(System.Drawing.Brushes.Red, 20, 20, 50, 50);
                    }
                }
                else if (tunel == 2)
                {
                    label2.Text = "";
                    label4.Text = "TUNEL 2";
                    label2.Location = new System.Drawing.Point(130, 0);
                    label4.Location = new System.Drawing.Point(130, 181);
                    label2.Text = a[0].ToString();
                    if (minutos >= 10)
                    {
                        graphics2.FillEllipse(System.Drawing.Brushes.Green, 130, 120, 50, 50);
                    }
                    else if (minutos == 9)
                    {
                        graphics2.FillEllipse(System.Drawing.Brushes.Yellow, 130, 70, 50, 50);
                    }
                    else
                    {
                        graphics2.FillEllipse(System.Drawing.Brushes.Red, 130, 20, 50, 50);
                    }

                }

            }
        }
        private void drawEmpty()
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(20, 20, 50, 150);
            graphics.DrawRectangle(System.Drawing.Pens.Black, rectangle);
            graphics.FillEllipse(System.Drawing.Brushes.Gray, 20, 20, 50, 50);
            graphics.DrawEllipse(System.Drawing.Pens.Black, 20, 20, 50, 50);
            graphics.FillEllipse(System.Drawing.Brushes.Gray, 20, 70, 50, 50);
            graphics.FillEllipse(System.Drawing.Brushes.Gray, 20, 120, 50, 50);

            
            System.Drawing.Rectangle rectangle2 = new System.Drawing.Rectangle(130, 20, 50, 150);
            graphics2.DrawRectangle(System.Drawing.Pens.Black, rectangle2);
            graphics2.FillEllipse(System.Drawing.Brushes.Gray, 130, 20, 50, 50);
            graphics2.DrawEllipse(System.Drawing.Pens.Black, 130, 20, 50, 50);
            graphics2.FillEllipse(System.Drawing.Brushes.Gray, 130, 70, 50, 50);
            graphics2.FillEllipse(System.Drawing.Brushes.Gray, 130, 120, 50, 50);
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = DateTime.Now.ToShortTimeString(); // Rutina para visualizar la hora
            drawEmpty();

            /* switch (color)
             {
                 case 0:
                     graphics.FillEllipse(System.Drawing.Brushes.Red, 20, 20, 50, 50);
                     timer1.Interval = 5000;
                     color = 2;
                     break;
                 case 1:
                     graphics.FillEllipse(System.Drawing.Brushes.Yellow, 20, 70, 50, 50);
                     timer1.Interval = 2000;
                     color = 0;
                     break;
                 case 2:
                     graphics.FillEllipse(System.Drawing.Brushes.Green, 20, 120, 50, 50);
                     timer1.Interval = 3000;
                     color = 1;
                     break;
             }*/
            process();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // drawEmpty();
            timer1.Stop();
            timer1.Enabled = false;
            this.button1.Enabled = false;
            this.button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.button2.Enabled = false;
            this.button1.Enabled = true;

        }

        private void Semaforo_FormClosed(object sender, FormClosedEventArgs e)
        {
            abierto = false;
        }
    }
}
