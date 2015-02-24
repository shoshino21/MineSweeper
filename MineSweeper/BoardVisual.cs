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

        public BoardVisual(int width, int height, int numMines, int locX, int locY, Form form) {
            _boardLogic = new BoardLogic(width, height, numMines);
            _pic = new PictureBox[_boardLogic.Height, _boardLogic.Width];
            //Size = new Size(_boardLogic.Width * CELL_SIZE, _boardLogic.Height * CELL_SIZE);
            //Location = new Point(locX, locY);

            //對所有方塊設定屬性
            _boardLogic.ForEachCell((h, w) => {
                _pic[h, w] = new PictureBox();
                _pic[h, w].Image = Properties.Resources.covered;
                _pic[h, w].Location = new Point(w * CELL_SIZE + locX, h * CELL_SIZE + locY);
                _pic[h, w].Size = new Size(CELL_SIZE, CELL_SIZE);
                _pic[h, w].Parent = form;

                SetMouseEvent(_pic[h, w], h, w);


                //滑鼠移至未開啟方塊上時變色
                //_pic[h, w].MouseMove += (o, e) => {
                //    bool cellIsOpened = _boardLogic.IsOpened[h, w];
                //    bool cellIsFlagged = _boardLogic.IsFlagged[h, w];

                //    if (!cellIsOpened) {
                //        (o as PictureBox).Image = Properties.Resources.covered_moveon;
                //    } else if (cellIsFlagged) {
                //        (o as PictureBox).Image = Properties.Resources.flag_moveon;
                //    }
                //};
                //_pic[h, w].MouseMove += Pic_MouseMove;
                //_pic[h, w].MouseLeave += Pic_MouseLeave;
                //_pic[h, w].MouseUp += Pic_MouseUp;
            });
        }

        //設定各項滑鼠事件
        private void SetMouseEvent(PictureBox pic, int h, int w) {
            //滑鼠按下並放開時
            pic.MouseUp += (o, e) => {
                PictureBox currPic = (o as PictureBox);
                bool isMines = _boardLogic.Mines[h, w];
                bool isOpened = _boardLogic.IsOpened[h, w];
                bool isFlagged = _boardLogic.IsFlagged[h, w];
                int aroundCount = _boardLogic.AroundCount[h, w];

                if (e.Button == MouseButtons.Left) {
                    if (isFlagged) { return; }  //有插旗則左鍵無效

                    if (_boardLogic.OpenCell(h, w)) {
                        RedrawEachCell();
                    }

                    if (isMines) {
                        //踩到地雷
                        currPic.Image = Properties.Resources.mine;
                    } else {
                        //顯示方塊周圍地雷數
                        switch (aroundCount) {
                            case 0: currPic.Image = Properties.Resources.empty; break;
                            case 1: currPic.Image = Properties.Resources.num1; break;
                            case 2: currPic.Image = Properties.Resources.num2; break;
                            case 3: currPic.Image = Properties.Resources.num3; break;
                            case 4: currPic.Image = Properties.Resources.num4; break;
                            case 5: currPic.Image = Properties.Resources.num5; break;
                            case 6: currPic.Image = Properties.Resources.num6; break;
                            case 7: currPic.Image = Properties.Resources.num7; break;
                            case 8: currPic.Image = Properties.Resources.num8; break;
                            default: break;
                        }
                    }
                    //_boardLogic.IsOpened[h, w] = true;  /*/之後改boardLogic處理/*/

                } else if (e.Button == MouseButtons.Right) {
                    if (isOpened) { return; }    //已打開則右鍵無效

                    _boardLogic.SwitchFlag(h, w);    //切換旗號
                    isFlagged = _boardLogic.IsFlagged[h, w];

                    if (isFlagged) {
                        currPic.Image = Properties.Resources.flag;
                    } else {
                        currPic.Image = Properties.Resources.covered;
                    }

                    _boardLogic.CheckWinning();     //檢查玩家是否勝利
                }
            };

            ////滑鼠按下時顯示按下圖樣
            //pic.MouseDown += (o, e) => {
            //    bool isOpened = _boardLogic.IsOpened[h, w];
            //    bool isFlagged = _boardLogic.IsFlagged[h, w];

            //    if (isOpened || isFlagged || e.Button == MouseButtons.Right) { return; }  //已開啟or插旗則無效
            //    (o as PictureBox).Image = Properties.Resources.covered_press;
            //};

            //滑鼠移至未開啟方塊上時變色
            pic.MouseMove += (o, e) => {
                bool isOpened = _boardLogic.IsOpened[h, w];
                bool isFlagged = _boardLogic.IsFlagged[h, w];

                if (isOpened) { return; }
                if (isFlagged) {
                    (o as PictureBox).Image = Properties.Resources.flag_moveon;
                } else {
                    (o as PictureBox).Image = Properties.Resources.covered_moveon;
                }
            };

            //滑鼠離開未開啟方塊上時回復原色
            pic.MouseLeave += (o, e) => {
                bool isOpened = _boardLogic.IsOpened[h, w];
                bool isFlagged = _boardLogic.IsFlagged[h, w];

                if (isOpened) { return; }
                if (isFlagged) {
                    (o as PictureBox).Image = Properties.Resources.flag;
                } else {
                    (o as PictureBox).Image = Properties.Resources.covered;
                }
            };
        }

        private void RedrawEachCell() {
            _boardLogic.ForEachCell((h, w) => {
                bool isMines = _boardLogic.Mines[h, w];
                bool isOpened = _boardLogic.IsOpened[h, w];
                bool isFlagged = _boardLogic.IsFlagged[h, w];
                int aroundCount = _boardLogic.AroundCount[h, w];
                
                var img = Properties.Resources.covered;

                if (isOpened) {
                    if (isMines) {
                        //踩到地雷
                        img = Properties.Resources.mine;
                    } else {
                        //顯示方塊周圍地雷數
                        switch (aroundCount) {
                            case 0: img = Properties.Resources.empty; break;
                            case 1: img = Properties.Resources.num1; break;
                            case 2: img = Properties.Resources.num2; break;
                            case 3: img = Properties.Resources.num3; break;
                            case 4: img = Properties.Resources.num4; break;
                            case 5: img = Properties.Resources.num5; break;
                            case 6: img = Properties.Resources.num6; break;
                            case 7: img = Properties.Resources.num7; break;
                            case 8: img = Properties.Resources.num8; break;
                            default: break;
                        }
                    }
                } else {
                    if (isFlagged) {
                        img = Properties.Resources.flag;
                    } else {
                        img = Properties.Resources.covered;
                    }
                }
                _pic[h, w].Image = img;
            });
        }

        //private void Pic_MouseMove(object sender, EventArgs e) {
        //    if ()

        //    (sender as PictureBox).Image = Properties.Resources.covered_moveon;
        //    //Image img = (sender as PictureBox).Image;
        //    //img = Properties.Resources.covered_moveon;
        //}

        //private void Pic_MouseLeave(object sender, EventArgs e) {
        //    (sender as PictureBox).Image = Properties.Resources.covered;
        //}

        ////
        //private void Pic_MouseUp(object sender, MouseEventArgs e) {
        //    //MessageBox.Show(e.X.ToString());
        //    //MessageBox.Show(e.Y.ToString());
        //    //if (sender is PictureBox) {

        //    PictureBox pic = sender as PictureBox;
        //    if (e.Button == MouseButtons.Left) {
        //        pic.Image = Properties.Resources.empty;
        //    }

        //}
    }
}
