using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MineSweeper {
    class BoardVisual : UserControl {
        private const int CELL_SIZE = 30;       //方塊大小
        //public BoardLogic BoardLogic { get; set; }
        //public Panel Panel { get; set; }
        private BoardLogic _boardLogic;
        //private Panel _panel;
        private PictureBox[,] _pic;

        public BoardVisual(int width, int height, int numMines, Form form) {
            //public BoardVisual(Panel panel, int width, int height, int numMines) {
            //this._panel = panel;
            this._boardLogic = new BoardLogic(width, height, numMines);
            this.Size = new Size(_boardLogic.Width * CELL_SIZE, _boardLogic.Height * CELL_SIZE);

            _pic = new PictureBox[_boardLogic.Height, _boardLogic.Width];

            _boardLogic.ForEachCell((h, w) => {
                _pic[h, w] = new PictureBox();
                _pic[h, w].Image = Properties.Resources.covered;
                _pic[h, w].Location = new Point(w * CELL_SIZE, h * CELL_SIZE);
                _pic[h, w].Size = new Size(CELL_SIZE, CELL_SIZE);
                _pic[h, w].MouseUp += Pic_MouseUp;
                _pic[h, w].Parent = form;
            });

            //_panel.MouseUp += _panel_MouseUp;

        }

        private void Pic_MouseUp(object sender, MouseEventArgs e) {
            //MessageBox.Show(e.X.ToString());
            //MessageBox.Show(e.Y.ToString());
            if (sender is PictureBox) {
                PictureBox pic = sender as PictureBox;
                if (e.Button == MouseButtons.Left) {
                    pic.Image = Properties.Resources.empty;
                }
            }

        }
    }
}
