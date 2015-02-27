using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper {
    class BoardLogic {
        public bool[,] Mines { get; private set; }          //地雷配置
        public bool[,] IsOpened { get; private set; }       //是否打開
        public bool[,] IsFlagged { get; private set; }      //是否插旗
        public int[,] AroundCount { get; private set; }     //周圍地雷數

        public int Width { get; private set; }              //盤面寬度
        public int Height { get; private set; }             //盤面高度
        public int NumMines { get; private set; }           //地雷數量
        public bool IsExploded { get; private set; }        //是否GameOver

        public BoardLogic(int width, int height, int numMines) {
            this.Width = width;
            this.Height = height;
            this.IsExploded = false;

            //地雷數不可大於總格數
            if (numMines > Width * Height) {
                this.NumMines = Width * Height;
            } else {
                this.NumMines = numMines;
            }

            this.Mines = SetMines();
            this.IsOpened = new bool[height, width];
            this.IsFlagged = new bool[height, width];
            this.AroundCount = CalcAroundCount();
        }

        //隨機配置地雷
        private bool[,] SetMines() {
            var board = new bool[Height, Width];
            var ran = new Random();
            var remainMines = NumMines;

            while (remainMines > 0) {
                int ranH = ran.Next(Height);
                int ranW = ran.Next(Width);

                if (!board[ranH, ranW]) {   //確認此格沒有地雷才放入
                    board[ranH, ranW] = true;
                    remainMines--;
                }
            }
            return board;
        }

        //計算方塊周圍地雷數
        private int[,] CalcAroundCount() {
            int[,] aroundCountArr = new int[Height, Width];

            //繞行各個方塊
            ForEachCell((h, w) => {
                int count = 0;
                //繞行該方塊周圍所有方塊並計算地雷數
                ForEachAroundCell(h, w, (ah, aw) => {
                    if (Mines[ah, aw]) { count++; }
                });
                aroundCountArr[h, w] = count;
            });
            return aroundCountArr;
        }

        //點開方塊
        public void OpenCell(int h, int w) {
            if (IsOpened[h, w]) { return; }
            if (IsFlagged[h, w]) { return; }

            if (Mines[h, w]) {  //踩到地雷
                IsOpened[h, w] = true;
                IsExploded = true;
            } else {
                IsOpened[h, w] = true;

                if (AroundCount[h, w] == 0) {   //周圍沒地雷則開啟周圍所有方塊
                    OpenCellContinued(h, w);
                }
            }
        }

        //連續開啟方塊
        private void OpenCellContinued(int h, int w) {
            ForEachAroundCell(h, w, (ah, aw) => {
                if (!IsOpened[ah, aw] && !IsFlagged[ah, aw]) {
                    IsOpened[ah, aw] = true;

                    if (AroundCount[ah, aw] == 0) {
                        OpenCellContinued(ah, aw);
                    }
                }
            });
        }

        //切換旗子
        public void SwitchFlag(int h, int w) {
            if (!IsOpened[h, w]) {
                IsFlagged[h, w] = !IsFlagged[h, w];
            }
        }

        //檢查玩家是否勝利
        public bool CheckForWinning() {
            bool isWinning = true;

            ForEachCell((h, w) => {
                bool minesNotFlagged = (Mines[h, w] && !IsFlagged[h, w]);
                bool safeCellNotOpened = (!Mines[h, w] && !IsOpened[h, w]);

                if (minesNotFlagged || safeCellNotOpened) { isWinning = false; }
            });
            return isWinning;
        }

        #region HelperMethod
        //繞行所有方塊
        public void ForEachCell(Action<int, int> action) {
            for (int h = 0; h < Height; h++) {
                for (int w = 0; w < Width; w++) {
                    action(h, w);
                }
            }
        }

        //繞行周圍所有方塊並判定邊界
        public void ForEachAroundCell(int h, int w, Action<int, int> action) {
            for (int hh = h - 1; hh <= h + 1; hh++) {
                for (int ww = w - 1; ww <= w + 1; ww++) {
                    //是否在界內
                    bool isInbound = (hh >= 0 && hh < Height && ww >= 0 && ww < Width);
                    //是否為目標方塊本身
                    bool isSelf = (hh == h && ww == w);

                    if (isInbound && !isSelf)
                        action(hh, ww);
                }
            }
        }
        #endregion
    }
}
