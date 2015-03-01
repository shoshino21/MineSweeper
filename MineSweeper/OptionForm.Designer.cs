namespace MineSweeper {
    partial class OptionForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.radioBasic = new System.Windows.Forms.RadioButton();
            this.radioAdvanced = new System.Windows.Forms.RadioButton();
            this.radioExtreme = new System.Windows.Forms.RadioButton();
            this.radioCustom = new System.Windows.Forms.RadioButton();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numMines = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMines)).BeginInit();
            this.SuspendLayout();
            // 
            // radioBasic
            // 
            this.radioBasic.AutoSize = true;
            this.radioBasic.Checked = true;
            this.radioBasic.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBasic.ForeColor = System.Drawing.Color.DarkGreen;
            this.radioBasic.Location = new System.Drawing.Point(25, 19);
            this.radioBasic.Name = "radioBasic";
            this.radioBasic.Size = new System.Drawing.Size(185, 21);
            this.radioBasic.TabIndex = 0;
            this.radioBasic.TabStop = true;
            this.radioBasic.Text = "Basic (9*9 , 10 mines)";
            this.radioBasic.UseVisualStyleBackColor = true;
            // 
            // radioAdvanced
            // 
            this.radioAdvanced.AutoSize = true;
            this.radioAdvanced.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAdvanced.ForeColor = System.Drawing.Color.Olive;
            this.radioAdvanced.Location = new System.Drawing.Point(25, 41);
            this.radioAdvanced.Name = "radioAdvanced";
            this.radioAdvanced.Size = new System.Drawing.Size(235, 21);
            this.radioAdvanced.TabIndex = 0;
            this.radioAdvanced.Text = "Advanced (16*16 , 40 mines)";
            this.radioAdvanced.UseVisualStyleBackColor = true;
            // 
            // radioExtreme
            // 
            this.radioExtreme.AutoSize = true;
            this.radioExtreme.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioExtreme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.radioExtreme.Location = new System.Drawing.Point(25, 63);
            this.radioExtreme.Name = "radioExtreme";
            this.radioExtreme.Size = new System.Drawing.Size(226, 21);
            this.radioExtreme.TabIndex = 0;
            this.radioExtreme.Text = "Extreme (30*16 , 99 mines)";
            this.radioExtreme.UseVisualStyleBackColor = true;
            // 
            // radioCustom
            // 
            this.radioCustom.AutoSize = true;
            this.radioCustom.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCustom.ForeColor = System.Drawing.Color.Black;
            this.radioCustom.Location = new System.Drawing.Point(25, 85);
            this.radioCustom.Name = "radioCustom";
            this.radioCustom.Size = new System.Drawing.Size(81, 21);
            this.radioCustom.TabIndex = 0;
            this.radioCustom.Text = "Custom";
            this.radioCustom.UseVisualStyleBackColor = true;
            this.radioCustom.CheckedChanged += new System.EventHandler(this.radioCustom_CheckedChanged);
            // 
            // numWidth
            // 
            this.numWidth.Enabled = false;
            this.numWidth.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWidth.Location = new System.Drawing.Point(119, 120);
            this.numWidth.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(100, 25);
            this.numWidth.TabIndex = 1;
            this.numWidth.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numHeight
            // 
            this.numHeight.Enabled = false;
            this.numHeight.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHeight.Location = new System.Drawing.Point(119, 147);
            this.numHeight.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(100, 25);
            this.numHeight.TabIndex = 2;
            this.numHeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numMines
            // 
            this.numMines.Enabled = false;
            this.numMines.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMines.Location = new System.Drawing.Point(119, 174);
            this.numMines.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numMines.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMines.Name = "numMines";
            this.numMines.Size = new System.Drawing.Size(100, 25);
            this.numMines.TabIndex = 2;
            this.numMines.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(43, 213);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(67, 36);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(175, 213);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mines :";
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numMines);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.radioCustom);
            this.Controls.Add(this.radioExtreme);
            this.Controls.Add(this.radioAdvanced);
            this.Controls.Add(this.radioBasic);
            this.Name = "OptionForm";
            this.Text = "Option";
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioBasic;
        private System.Windows.Forms.RadioButton radioAdvanced;
        private System.Windows.Forms.RadioButton radioExtreme;
        private System.Windows.Forms.RadioButton radioCustom;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.NumericUpDown numMines;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}