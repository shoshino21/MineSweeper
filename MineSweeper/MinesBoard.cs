using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper {
    class MinesBoard {
        public bool[,] Mines { get; private set; }          //地雷配置
        public bool[,] IsOpened { get; private set; }       //是否打開
        public bool[,] IsFlagged { get; private set; }      //是否插旗
        public int[,] AroundCount { get; private set; }     //周圍地雷數

        public int BoardWidth { get; private set; }         //盤面寬度
        public int BoardHeight { get; private set; }        //盤面高度
        public int NumMines { get; private set; }           //地雷數量

        public MinesBoard(int width, int height, int numMines) {
            this.BoardWidth = width;
            this.BoardHeight = height;

            //地雷數不可大於總格數
            /*/不知為何用Property設setter對constructor無效，只好放這/*/
            if (numMines > BoardWidth * BoardHeight) {
                this.NumMines = BoardWidth * BoardHeight;
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
            var board = new bool[BoardHeight, BoardWidth];
            var ran = new Random();
            var remainMines = NumMines;

            while (remainMines > 0) {
                int ranH = ran.Next(BoardHeight);
                int ranW = ran.Next(BoardWidth);

                if (!board[ranH, ranW]) {   //確認此格沒有地雷才放入
                    board[ranH, ranW] = true;
                    remainMines--;
                }
            }
            return board;
        }

        //繞行所有方塊用
        private void ForEachCell(Action<int, int> action) {
            for (int h = 0; h < BoardHeight; h++) {
                for (int w = 0; w < BoardWidth; w++) {
                    action(h, w);
                }
            }
        }

        //計算方塊周圍地雷數
        private int[,] CalcAroundCount() {
            int[,] results = new int[BoardHeight, BoardWidth];

            ForEachCell((h, w) => {
                int count = 0;

                for (int hh = h - 1; hh <= h + 1; hh++) {
                    for (int ww = w - 1; ww <= w + 1; ww++) {
                        bool isSelf = (hh == h && ww == w);    //是否為目標方塊本身

                        if (IsInbound(hh, ww) && !(isSelf)) {
                            if (Mines[hh, ww]) { count++; }
                        }
                    }
                }
                results[h, w] = count;
            });
            return results;
        }

        //判斷是否在盤面範圍以內
        private bool IsInbound(int h, int w) {
            return (h >= 0 && h < BoardHeight && w >= 0 && w < BoardWidth);
        }
    }
}
