namespace CIA0008_ORM
{
    partial class TymyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datum_od = new System.Windows.Forms.DateTimePicker();
            this.datum_do = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.NovyTymButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NazevTB = new System.Windows.Forms.TextBox();
            this.SmenyCB = new System.Windows.Forms.ComboBox();
            this.DatumKopie = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seznam týmů podle časového období";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Od:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Do:";
            // 
            // datum_od
            // 
            this.datum_od.Location = new System.Drawing.Point(64, 36);
            this.datum_od.Name = "datum_od";
            this.datum_od.Size = new System.Drawing.Size(170, 20);
            this.datum_od.TabIndex = 3;
            // 
            // datum_do
            // 
            this.datum_do.Location = new System.Drawing.Point(64, 63);
            this.datum_do.Name = "datum_do";
            this.datum_do.Size = new System.Drawing.Size(170, 20);
            this.datum_do.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Vyhledat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NovyTymButton
            // 
            this.NovyTymButton.Location = new System.Drawing.Point(167, 486);
            this.NovyTymButton.Name = "NovyTymButton";
            this.NovyTymButton.Size = new System.Drawing.Size(75, 23);
            this.NovyTymButton.TabIndex = 7;
            this.NovyTymButton.Text = "Vytvořit";
            this.NovyTymButton.UseVisualStyleBackColor = true;
            this.NovyTymButton.Click += new System.EventHandler(this.NovyTymButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(17, 119);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(302, 160);
            this.listBox1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(263, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Vytvoření kopie stávajícího týmu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 306);
            this.label5.MaximumSize = new System.Drawing.Size(200, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 39);
            this.label5.TabIndex = 10;
            this.label5.Text = "Pro vybrání týmu, který chcete zkopírovat, klikněte na tým ze seznamu výše a dopl" +
    "ňte dodatečné informace";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Název:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 379);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Směna:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 405);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Datum:";
            // 
            // NazevTB
            // 
            this.NazevTB.Location = new System.Drawing.Point(64, 348);
            this.NazevTB.Name = "NazevTB";
            this.NazevTB.Size = new System.Drawing.Size(178, 20);
            this.NazevTB.TabIndex = 14;
            // 
            // SmenyCB
            // 
            this.SmenyCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SmenyCB.FormattingEnabled = true;
            this.SmenyCB.Location = new System.Drawing.Point(64, 371);
            this.SmenyCB.Name = "SmenyCB";
            this.SmenyCB.Size = new System.Drawing.Size(178, 21);
            this.SmenyCB.TabIndex = 16;
            // 
            // DatumKopie
            // 
            this.DatumKopie.Location = new System.Drawing.Point(64, 399);
            this.DatumKopie.Name = "DatumKopie";
            this.DatumKopie.Size = new System.Drawing.Size(178, 20);
            this.DatumKopie.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 426);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Vytvořit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(12, 452);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Vytvoření nového týmu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 472);
            this.label10.MaximumSize = new System.Drawing.Size(150, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 26);
            this.label10.TabIndex = 20;
            this.label10.Text = "Spustit formulář pro vytvoření nového týmu";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(12, 523);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(259, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "Přiřazení zaměstnance do týmu";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 543);
            this.label12.MaximumSize = new System.Drawing.Size(150, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 26);
            this.label12.TabIndex = 22;
            this.label12.Text = "Spustit formulář pro přiřazení zaměstnance do týmu";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 556);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Vytvořit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TymyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 586);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DatumKopie);
            this.Controls.Add(this.SmenyCB);
            this.Controls.Add(this.NazevTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.NovyTymButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datum_do);
            this.Controls.Add(this.datum_od);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TymyForm";
            this.Text = "Týmy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datum_od;
        private System.Windows.Forms.DateTimePicker datum_do;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button NovyTymButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NazevTB;
        private System.Windows.Forms.ComboBox SmenyCB;
        private System.Windows.Forms.DateTimePicker DatumKopie;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button3;
    }
}