using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Tunel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = -1;
            //maskedTextBox1.ValidatingType = typeof(System.DateTime.hour);
        }
        public bool esHoraValida(string hora)
        {
            bool result = false;
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("([0-1][0-9]|2[0-3]):[0-5][0-9]");
            if (r.Match(hora).Success)
                result = true;
            return result;
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            /* int a = 4;
            while (a>0) ;
            System.Console.WriteLine(a);
            a--;*/
            string _SSCC = textBox_sscc.Text;
            _SSCC = _SSCC.Trim();
            _SSCC = _SSCC.TrimStart('0').Replace("91x", "").Replace("91X", "");
            int unidades = -1;
            if (txt_unidades.Text.Length>0)
                int.TryParse(txt_unidades.Text, out unidades);
            int resultado = 0;
            //int seleccio = 0;
            //int.TryParse(comboBox1.SelectedItem.ToString(), out seleccio);
            if (unidades < 0){
                MessageBox.Show("No has introducido Unidades del palet, no se va a grabar.", "Atencion!!");
            }
            else{ 
            int seleccio = comboBox1.SelectedIndex + 3;
           if (seleccio <3)
            { MessageBox.Show("Tienes que introducir un tunel", "Atencion!!");
            }else if (_SSCC.Length == 18)
            {
                Palet matricula = new Palet(_SSCC);

                if (matricula.existe() == false)
                {
                    MessageBox.Show("La matricula introducida, no existe en Quality", "Atencion!!");
                }
                else if (hora.Value.ToString("HH:mm") == "00:00")
                {
                    MessageBox.Show("Vigila hora del pack, no se va a guardar", "Atencion!!");
                }else
                {
                    if (seleccio >= 4 && seleccio <= 5 && textBox_temp.Text.Length == 0)
                    {
                        MessageBox.Show("No has introducido Temperatura, no se va a grabar.", "Atencion!!");
                    }
                    else { 

                    if (seleccio >= 4 && seleccio <= 5 && textBox_temp.Text.Length >= 1)
                    {

                        matricula.setTemperatura(textBox_temp.Text,seleccio);
                    }
                    int horas = matricula.Comprobar_horas(hora.Value.ToString("HH:mm"));

                    if (matricula.introducido() && (seleccio < 3 || seleccio==6) )
                    {

                        string mensaje = "Matricula ya Añadida!!\r\n¿Va ha volver a pasar por un tunel?";
                        DialogResult boton = MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (boton == DialogResult.Yes)
                        {
                                    resultado=matricula.Insertar_Quality(seleccio.ToString(), hora.Value.ToString("HH:mm"),unidades.ToString());
                           /* mensaje = "Matricula añadida";
                            MessageBox.Show(mensaje, "Alerta");*/
                        }
                    }
                    else if (horas >= 20)
                    {
                        message men = new message(horas.ToString());
                        men.ShowDialog();
                        if (men.DialogResult == DialogResult.Yes)
                        {
                                    resultado= matricula.Insertar_Quality(seleccio.ToString(), hora.Value.ToString("HH:mm"), unidades.ToString());
                            /*string mensaje = "Matricula añadida";
                            MessageBox.Show(mensaje, "Alerta");*/
                        }
                    }
                    else
                    {
                                resultado=matricula.Insertar_Quality(seleccio.ToString(), hora.Value.ToString("HH:mm"), unidades.ToString());
                        /*string mensaje = "Matricula añadida";
                        MessageBox.Show(mensaje, "Alerta");*/
                    }

                }
            }
                
            }
            }
            if (resultado == -1) {
                mensaje comprueba = new mensaje(Color.Red, 5, "Unidades incorrectas, no se ha grabado nada");
                comprueba.ShowDialog(this);
                comprueba.Dispose();

            } else if (resultado==1){
                string msg = " Unidades correctas ";
                mensaje comprueba = new mensaje(Color.Green, 3, msg);
                comprueba.ShowDialog(this);
                comprueba.Dispose();
                textBox_temp.Text = "";
                textBox_sscc.Text = "";
                txt_unidades.Text = "";
                hora.Value = DateTime.Parse("00:00");
            }
            else
            {
                textBox_temp.Text = "";
                textBox_sscc.Text = "";
                txt_unidades.Text = "";
                hora.Value = DateTime.Parse("00:00");
            }
            
        }

        private void textBox_sscc_Enter(object sender, EventArgs e)
        {
            textBox_sscc.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_sscc.Text.Length > 0) { 
            if(MessageBox.Show("Seguro que deseas borrar marticula "+ textBox_sscc.Text+" ?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                    Palet matricula = new Palet(textBox_sscc.Text);
                    matricula.Barrar_Ultimo_Quality();
                }
            }else { MessageBox.Show("No has borrado nada", "Alerta"); }
            textBox_sscc.SelectAll();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccion = comboBox1.SelectedIndex + 3;
            if(seleccion >= 4 && seleccion <= 5)
            {
                textBox_temp.Visible = true;
                label3.Visible = true;
                label2.Visible = true;
                textBox_temp.Text = "";
                textBox_temp.Focus();
               
            }
            else
            {
                textBox_temp.Visible = false;
                label3.Visible = false;
                label2.Visible = false;
                textBox_temp.Text = "";
              //  hora.Value = DateTime.Parse("00:00");
            }
        }
       // Semaforo semaforo1 = new Semaforo();
        private Semaforo form = null;

        private Semaforo FormInstance
        {
            get
            {
                if (form == null)
                {
                    form = new Semaforo();
                    form.MdiParent = this;

                    form.Disposed += new EventHandler(form_Disposed);
                    form.FormClosed += new FormClosedEventHandler(form_FormClosed);
                    form.Load += new EventHandler(form_Load);

                }

                return form;
            }
        }

        void form_Load(object sender, EventArgs e)
        {
            //checkBox1.Checked = true;
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
           // checkBox1.Checked = false;
        }

        void form_Disposed(object sender, EventArgs e)
        {
            form = null;
        }
       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           /* Semaforo semaforo1 = this.FormInstance;

            if (checkBox1.Checked == true) {
               // if (semaforo1.abierto==false)
                    if (semaforo1.WindowState == FormWindowState.Minimized)
                        semaforo1.WindowState = FormWindowState.Normal;

                semaforo1.Show();
                   
                
            }
            else {
                //if (semaforo1.abierto == true) { 
                    semaforo1.Hide();
                //semaforo1.Dispose();
                //}
            }
            */
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_unidades.Text, "[^0-9]"))
            {
                MessageBox.Show("Introducir solo el numero de unidades.");
                txt_unidades.Text = txt_unidades.Text.Remove(txt_unidades.Text.Length - 1);
            }
        }
    }
}
