using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*/ 就只是個踩地雷 by shoshino21 2015.2.24 /*/

namespace MineSweeper {
    public partial class MainForm : Form {
        private BoardVisual _boardVisual;

        /*/ 注意地雷數不能比格子數多 /*/
        int boardWidth = 10;
        int boardHeight = 8;
        int numMines = 10;

        private const int LOCATION_X = 50;
        private const int LOCATION_Y = 50;

        public MainForm() {
            InitializeComponent();

            _boardVisual = new BoardVisual(boardWidth, boardHeight, numMines, LOCATION_X, LOCATION_Y, this);

            //for (int bh = 0; bh < boardHeight; bh++) {
            //    for (int bw = 0; bw < boardWidth; bw++) {
            //        pics[bw, bh] = new PictureBox();
            //        pics[bw, bh].Image = Properties.Resources.covered;
            //        pics[bw, bh].Location = new Point(bw * CELL_SIZE, bh * CELL_SIZE);
            //        pics[bw, bh].Size = new Size(CELL_SIZE, CELL_SIZE);
            //        //pics[bw, bh].Name = "Cell";
            //        pics[bw, bh].Parent = panelBoard;

            //        PictureBox pic = pics[bw, bh];

            //        if (minesBoard.Mines[bh, bw]) {
            //            pic.Image = Properties.Resources.mine;
            //        } else {
            //            switch (minesBoard.AroundCount[bh, bw]) {
            //                case 0: pic.Image = Properties.Resources.empty; break;
            //                case 1: pic.Image = Properties.Resources.num1; break;
            //                case 2: pic.Image = Properties.Resources.num2; break;
            //                case 3: pic.Image = Properties.Resources.num3; break;
            //                case 4: pic.Image = Properties.Resources.num4; break;
            //                case 5: pic.Image = Properties.Resources.num5; break;
            //                case 6: pic.Image = Properties.Resources.num6; break;
            //                case 7: pic.Image = Properties.Resources.num7; break;
            //                case 8: pic.Image = Properties.Resources.num8; break;
            //                default: break;
            //            }
            //        }

            //        pics[bw, bh].MouseUp += panel1_MouseUp;
            //    }
            //}
            //panel1.BringToFront();
            //panel1.MouseUp += panel1_MouseUp;
        }

    }

    #region Recycled

    //public partial class Form1 : Form {
    //    Cell[,] cells;


    //    int boardWidth = 3;
    //    int boardHeight = 5;
    //    const int CELL_SIZE = 30;

    //    public Form1() {
    //        InitializeComponent();

    //        panel1.BringToFront();
    //        cells = new Cell[boardWidth, boardHeight];
    //        for (int bh = 0; bh < boardHeight; bh++) {
    //            for (int bw = 0; bw < boardWidth; bw++) {
    //                cells[bw, bh] = new Cell(bw * CELL_SIZE, bh * CELL_SIZE, CELL_SIZE);
    //                cells[bw, bh].Pic.Parent = panel1;
    //                cells[bw, bh].SendToBack();
    //                panel1.Controls.Add(this.cells[0, 0]);
    //            }
    //        }
    //    }

    //    private void panel1_MouseUp(object sender, MouseEventArgs e) {
    //        cells[1, 1].Open();
    //        cells[2, 2].Open();
    //        Application.DoEvents();
    //    }

    //    private void panel1_MouseMove(object sender, MouseEventArgs e) {
    //        var x = (panel1.Left - e.X) / CELL_SIZE;
    //        var y = (panel1.Top - e.Y) / CELL_SIZE;

    //        cells[1, 2].MoveOn();
    //    }
    //}

    //class Cell : UserControl {
    //    public PictureBox Pic { get; set; }
    //    public bool IsMine { get; set; }

    //    public Cell(int x, int y, int size) {
    //        Pic = new PictureBox();
    //        Pic.Image = global::WindowsFormsApplication1.Properties.Resources.covered;
    //        Pic.Location = new Point(x, y);
    //        Pic.Size = new Size(size, size);
    //        Pic.Name = "Cell";
    //    }

    //    public void Open() {
    //        Pic.Image = global::WindowsFormsApplication1.Properties.Resources.num2;
    //    }
    //    public void MoveOn() {
    //        Pic.Image = global::WindowsFormsApplication1.Properties.Resources.covered_moveon;
    //    }
    //}

    //private void panel1_MouseUp(object sender, MouseEventArgs e) {

    //    Panel test = sender as Panel;
    //    PictureBox pic = sender as PictureBox;

    //    //this.panel1.Controls.Remove(pic);

    //    int h = e.X;
    //    int w = e.Y;


    //    //if (pic is PictureBox) {
    //    //    if (e.Button == MouseButtons.Left) {
    //    //        if (minesBoard.Mines[h, w]) {
    //    //            pic.Image = Properties.Resources.mine;
    //    //        } else {
    //    //            switch (minesBoard.AroundCount[h, w]) {
    //    //                case 0: pic.Image = Properties.Resources.empty; break;
    //    //                case 1: pic.Image = Properties.Resources.num1; break;
    //    //                case 2: pic.Image = Properties.Resources.num2; break;
    //    //                case 3: pic.Image = Properties.Resources.num3; break;
    //    //                case 4: pic.Image = Properties.Resources.num4; break;
    //    //                case 5: pic.Image = Properties.Resources.num5; break;
    //    //                case 6: pic.Image = Properties.Resources.num6; break;
    //    //                case 7: pic.Image = Properties.Resources.num7; break;
    //    //                case 8: pic.Image = Properties.Resources.num8; break;
    //    //                default: break;
    //    //            }
    //    //        }
    //    //    } else if (e.Button == MouseButtons.Right) {
    //    //        pic.Image = Properties.Resources.flag;
    //    //    }

    //    //}
    //    MessageBox.Show(h.ToString());
    //    MessageBox.Show(w.ToString());
    //}
    #endregion

}
