namespace Control_Tunel
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_sscc = new System.Windows.Forms.TextBox();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.label_sscc = new System.Windows.Forms.Label();
            this.label_temp = new System.Windows.Forms.Label();
            this.msg_insert = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.hora = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_temp = new System.Windows.Forms.TextBox();
            this.txt_unidades = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_sscc
            // 
            this.textBox_sscc.Location = new System.Drawing.Point(85, 25);
            this.textBox_sscc.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_sscc.Name = "textBox_sscc";
            this.textBox_sscc.Size = new System.Drawing.Size(157, 22);
            this.textBox_sscc.TabIndex = 0;
            this.textBox_sscc.Enter += new System.EventHandler(this.textBox_sscc_Enter);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(510, 92);
            this.Btn_Guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(100, 28);
            this.Btn_Guardar.TabIndex = 8;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // label_sscc
            // 
            this.label_sscc.AutoSize = true;
            this.label_sscc.Location = new System.Drawing.Point(5, 34);
            this.label_sscc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_sscc.Name = "label_sscc";
            this.label_sscc.Size = new System.Drawing.Size(73, 17);
            this.label_sscc.TabIndex = 2;
            this.label_sscc.Text = "Matricula: ";
            // 
            // label_temp
            // 
            this.label_temp.AutoSize = true;
            this.label_temp.Location = new System.Drawing.Point(457, 33);
            this.label_temp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_temp.Name = "label_temp";
            this.label_temp.Size = new System.Drawing.Size(78, 17);
            this.label_temp.TabIndex = 3;
            this.label_temp.Text = "Hora Pack:";
            // 
            // msg_insert
            // 
            this.msg_insert.AutoSize = true;
            this.msg_insert.Location = new System.Drawing.Point(20, 98);
            this.msg_insert.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.msg_insert.Name = "msg_insert";
            this.msg_insert.Size = new System.Drawing.Size(0, 17);
            this.msg_insert.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tunel:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "3 | PRE ENFRIA.",
            "4 | TEMPORAL",
            "5 | CAMARA",
            "TUNELES"});
            this.comboBox1.Location = new System.Drawing.Point(309, 23);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // hora
            // 
            this.hora.CustomFormat = "HH:mm";
            this.hora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hora.Location = new System.Drawing.Point(536, 27);
            this.hora.Margin = new System.Windows.Forms.Padding(4);
            this.hora.Name = "hora";
            this.hora.ShowUpDown = true;
            this.hora.Size = new System.Drawing.Size(71, 22);
            this.hora.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(402, 92);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Borrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(5, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Al escoger este tunel tienes que introducir temperatura";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Temperatura:";
            this.label3.Visible = false;
            // 
            // textBox_temp
            // 
            this.textBox_temp.Location = new System.Drawing.Point(107, 86);
            this.textBox_temp.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_temp.Name = "textBox_temp";
            this.textBox_temp.Size = new System.Drawing.Size(59, 22);
            this.textBox_temp.TabIndex = 4;
            this.textBox_temp.Visible = false;
            // 
            // txt_unidades
            // 
            this.txt_unidades.Location = new System.Drawing.Point(536, 57);
            this.txt_unidades.Margin = new System.Windows.Forms.Padding(4);
            this.txt_unidades.Name = "txt_unidades";
            this.txt_unidades.Size = new System.Drawing.Size(71, 22);
            this.txt_unidades.TabIndex = 5;
            this.txt_unidades.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Unidades:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 130);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_unidades);
            this.Controls.Add(this.textBox_temp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hora);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msg_insert);
            this.Controls.Add(this.label_temp);
            this.Controls.Add(this.label_sscc);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.textBox_sscc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control del Tunel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_sscc;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Label label_sscc;
        private System.Windows.Forms.Label label_temp;
        private System.Windows.Forms.Label msg_insert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker hora;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_temp;
        private System.Windows.Forms.TextBox txt_unidades;
        private System.Windows.Forms.Label label4;
    }
}

