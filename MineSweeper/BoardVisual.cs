using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MineSweeper {
    class BoardVisual {
        private BoardLogic _boardLogic;
        private PictureBox[,] _pic;

        public Form TheForm { get; set; }
        public Label LabelRemaining { get; set; }          //標記剩餘地雷數
        public Label LabelTimer { get; set; }              //標記時間
        public Timer TimerPlaying { get; set; }          //計時

        public bool isPlaying { get; private set; }         //遊戲是否在進行中
        //public int BoardOffsetX { get; set; }
        //public int BoardOffsetY { get; set; }

        public BoardVisual(int width, int height, int numMines, Form form) {
            //_boardLogic = new BoardLogic(width, height, numMines);
            //_pic = new PictureBox[_boardLogic.Height, _boardLogic.Width];
            //isPlaying = false;

            ////設定所有方塊屬性
            //_boardLogic.ForEachCell((h, w) => {
            //    _pic[h, w] = new PictureBox();
            //    _pic[h, w].Image = Properties.Resources.covered;
            //    _pic[h, w].Location = new Point(w * CELL_SIZE + locX, h * CELL_SIZE + locY);
            //    _pic[h, w].Size = new Size(CELL_SIZE, CELL_SIZE);
            //    _pic[h, w].Parent = form;

            //    SetMouseEvent(_pic[h, w], h, w);
            //});
            //this.BoardOffsetX = ;
            //this.BoardOffsetY = offsetY;
            this.TheForm = form;

            CreateBoardVisual(width, height, numMines);
        }

        private void CreateBoardVisual(int width, int height, int numMines) {
            _boardLogic = new BoardLogic(width, height, numMines);
            //_pic = null;
            _pic = new PictureBox[_boardLogic.Height, _boardLogic.Width];
            isPlaying = false;

            //MainForm.Width = BoardVisual.CELL_SIZE * width + BoardOffsetX * 2;
            //MainForm.Height = BoardVisual.CELL_SIZE * height + BoardOffsetY;
            //MainForm.Size = new System.Drawing.Size(newWidth, newHeight);

            //設定所有方塊屬性
            _boardLogic.ForEachCell((h, w) => {
                _pic[h, w] = new PictureBox();
                _pic[h, w].Image = Properties.Resources.covered;
                _pic[h, w].Location = new Point(w * MainForm.CELL_SIZE + MainForm.MARGIN_LEFT, h * MainForm.CELL_SIZE + MainForm.MARGIN_UP);
                _pic[h, w].Size = new Size(MainForm.CELL_SIZE, MainForm.CELL_SIZE);
                _pic[h, w].Parent = this.TheForm;

                SetMouseEvent(_pic[h, w], h, w);
            });

            RedrawForm();
            //MainFor
        }

        //設定滑鼠事件
        private void SetMouseEvent(PictureBox pic, int h, int w) {
            //滑鼠按下並放開時
            pic.MouseUp += (o, e) => {
                if (e.Button == MouseButtons.Left) {
                    _boardLogic.OpenCell(h, w);     //打開方塊

                    if (_boardLogic.IsExploded) {   //踩到地雷
                        Exploded(h, w);
                        return;
                    }

                } else if (e.Button == MouseButtons.Right) {
                    _boardLogic.SwitchFlag(h, w);   //切換旗號
                }

                //重繪盤面
                RedrawForm();
                //檢查玩家是否勝利
                if (_boardLogic.CheckForWinning()) {
                    Winning();
                    return;
                }
                //打開第一顆方塊時啟動Timer
                if (!isPlaying) {
                    isPlaying = true;
                    TimerPlaying.Enabled = true;
                }
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
        private void RedrawForm() {
            _boardLogic.ForEachCell((h, w) => {
                var newImg = Properties.Resources.covered;
                bool isMines = _boardLogic.Mines[h, w];
                bool isOpened = _boardLogic.IsOpened[h, w];
                bool isFlagged = _boardLogic.IsFlagged[h, w];
                int aroundCount = _boardLogic.AroundCount[h, w];
                bool isExploded = _boardLogic.IsExploded;

                if (isOpened) {
                    if (isMines) {
                        newImg = Properties.Resources.mine_exploded;
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

            //更新Counter
            //LabelRemaining.Text = _boardLogic.RemainingFlagCount.ToString();
        }

        //踩到地雷，參數 = 座標
        private void Exploded(int explodedX, int explodedY) {
            isPlaying = false;
            TimerPlaying.Enabled = false;

            _boardLogic.ForEachCell((h, w) => {
                //標示地雷
                if (h == explodedX && w == explodedY) {
                    _pic[h, w].Image = Properties.Resources.mine_exploded;
                } else if (_boardLogic.Mines[h, w]) {
                    _pic[h, w].Image = Properties.Resources.mine;
                }

                //標示插錯的旗子
                bool isMissFlag = (!_boardLogic.Mines[h, w] && _boardLogic.IsFlagged[h, w]);
                if (isMissFlag) {
                    _pic[h, w].Image = Properties.Resources.flag_missed;
                }

                _pic[h, w].Enabled = false;
            });

            //挑釁 m9(^o^)
            string suckMessage = string.Empty;
            switch (new Random().Next(5)) {
                case 0: suckMessage = "Booooooooom!!"; break;
                case 1: suckMessage = "You noob LOL"; break;
                case 2: suckMessage = "HAHA UCCU"; break;
                case 3: suckMessage = @"/(^o^)\ WTF!?"; break;
                case 4: suckMessage = @"\(^o^)/ WRYYYYY"; break;
                default: break;
            }
            MessageBox.Show(suckMessage);
        }

        //玩家勝利
        private void Winning() {
            isPlaying = false;
            TimerPlaying.Enabled = false;
            _boardLogic.ForEachCell((h, w) => { _pic[h, w].Enabled = false; });
            MessageBox.Show("You Win!");
        }

        //重置遊戲
        public void ResetGame(int width, int height, int numMines) {
            //_boardLogic.CreateBoardLogic(width, height, numMines);
            //先把舊盤面隱藏起來避免覆蓋到新盤面圖像
            _boardLogic.ForEachCell((h, w) => { _pic[h, w].Visible = false; });

            CreateBoardVisual(width, height, numMines);
            _boardLogic.ForEachCell((h, w) => { _pic[h, w].Enabled = true; });
            //RedrawForm();
        }
    }
}
