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
        private BoardLogic _boardLogic;
        private PictureBox[,] _pic;

        public BoardVisual(int width, int height, int numMines, int locX, int locY, Form form) {
            _boardLogic = new BoardLogic(width, height, numMines);
            _pic = new PictureBox[_boardLogic.Height, _boardLogic.Width];

            //設定所有方塊屬性
            _boardLogic.ForEachCell((h, w) => {
                _pic[h, w] = new PictureBox();
                _pic[h, w].Image = Properties.Resources.covered;
                _pic[h, w].Location = new Point(w * CELL_SIZE + locX, h * CELL_SIZE + locY);
                _pic[h, w].Size = new Size(CELL_SIZE, CELL_SIZE);
                _pic[h, w].Parent = form;
                
                SetMouseEvent(_pic[h, w], h, w);
            });
        }

        //設定滑鼠事件
        private void SetMouseEvent(PictureBox pic, int h, int w) {
            //滑鼠按下並放開時
            pic.MouseUp += (o, e) => {
                if (e.Button == MouseButtons.Left) {
                    _boardLogic.OpenCell(h, w);     //打開方塊
                } else if (e.Button == MouseButtons.Right) {
                    _boardLogic.SwitchFlag(h, w);   //切換旗號
                }
                RedrawEachCell();   //重繪盤面
                _boardLogic.CheckForWinning();     //檢查玩家是否勝利
            };

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

        //重繪盤面
        private void RedrawEachCell() {
            _boardLogic.ForEachCell((h, w) => {
                var newImg = Properties.Resources.covered;
                bool isMines = _boardLogic.Mines[h, w];
                bool isOpened = _boardLogic.IsOpened[h, w];
                bool isFlagged = _boardLogic.IsFlagged[h, w];
                int aroundCount = _boardLogic.AroundCount[h, w];

                if (isOpened) {
                    if (isMines) {
                        newImg = Properties.Resources.mine;
                    } else {
                        switch (aroundCount) {
                            case 0: newImg = Properties.Resources.empty; break;
                            case 1: newImg = Properties.Resources.num1; break;
                            case 2: newImg = Properties.Resources.num2; break;
                            case 3: newImg = Properties.Resources.num3; break;
                            case 4: newImg = Properties.Resources.num4; break;
                            case 5: newImg = Properties.Resources.num5; break;
                            case 6: newImg = Properties.Resources.num6; break;
                            case 7: newImg = Properties.Resources.num7; break;
                            case 8: newImg = Properties.Resources.num8; break;
                            default: break;
                        }
                    }

                } else {    //未開啟方塊
                    if (isFlagged) {
                        newImg = Properties.Resources.flag;
                    } else {
                        newImg = Properties.Resources.covered;
                    }
                }
                
                _pic[h, w].Image = newImg;
            });
        }
    }
}
