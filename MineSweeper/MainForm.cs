using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*/ 就只是個踩地雷 by shoshino21 2015.2.27 /*/

namespace MineSweeper {
    public partial class MainForm : Form {
        private BoardVisual _boardVisual;

        /*/ 注意地雷數不能比格子數多 /*/
        int boardWidth = 10;
        int boardHeight = 8;
        int numMines = 10;

        //遊戲盤面座標
        private const int LOCATION_X = 50;
        private const int LOCATION_Y = 50;

        public MainForm() {
            InitializeComponent();

            _boardVisual = new BoardVisual(boardWidth, boardHeight, numMines, LOCATION_X, LOCATION_Y, this);
        }
    }
}
