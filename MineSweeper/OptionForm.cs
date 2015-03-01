using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper {
    public partial class OptionForm : Form {
        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }
        public int NumMines { get; private set; }

        public OptionForm() {
            InitializeComponent();

            //預設值
            this.BoardWidth = 9;
            this.BoardHeight = 9;
            this.NumMines = 10;
        }

        private void radioCustom_CheckedChanged(object sender, EventArgs e) {
            numWidth.Enabled = radioCustom.Checked;
            numHeight.Enabled = radioCustom.Checked;
            numMines.Enabled = radioCustom.Checked;
        }

        //設定難度
        private void btnOK_Click(object sender, EventArgs e) {
            if (radioBasic.Checked) {
                BoardWidth = 9;
                BoardHeight = 9;
                NumMines = 10;

            } else if (radioAdvanced.Checked) {
                BoardWidth = 16;
                BoardHeight = 16;
                NumMines = 40;

            } else if (radioExtreme.Checked) {
                BoardWidth = 30;
                BoardHeight = 16;
                NumMines = 99;

            } else if (radioCustom.Checked) {
                BoardWidth = (int)numWidth.Value;
                BoardHeight = (int)numHeight.Value;

                //地雷數不可超過方塊數
                if (numMines.Value > numWidth.Value * numHeight.Value) {
                    MessageBox.Show("Too much mines!");
                } else {
                    NumMines = (int)numMines.Value;
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
