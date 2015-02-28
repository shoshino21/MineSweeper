using System;
using System.Windows.Forms;
using System.Drawing;

/*/ 就只是個踩地雷 by shoshino21 2015.2.27 /*/

namespace MineSweeper {
    public partial class MainForm : Form {
        private BoardVisual _boardVisual;

        /*/ 注意地雷數不能比格子數多 /*/
        int boardWidth = 10;
        int boardHeight = 10;
        int numMines = 1;

        //遊戲盤面座標
        private const int LOCATION_X = 3;
        private const int LOCATION_Y = 70;

        private int _playingTime;
        //private bool _isPlaying = false;

        public MainForm() {
            InitializeComponent();

            _boardVisual = new BoardVisual(boardWidth, boardHeight, numMines, LOCATION_X, LOCATION_Y, this);

            _boardVisual.LabelRemaining = this.lblRemaining;
            _boardVisual.LabelTimer = this.lblTimer;
            _boardVisual.TimerPlaying = this.timerPlaying;

            InitializeGame();
        }

        //遊戲初始化
        private void InitializeGame() {
            this.Width = BoardVisual.CELL_SIZE * boardWidth + LOCATION_X * 2;
            this.Height = BoardVisual.CELL_SIZE * boardHeight + LOCATION_Y;
            //this.Size = new System.Drawing.Size(newWidth, newHeight);

            lblRemaining.Text = numMines.ToString();

            timerPlaying.Enabled = false;
            _playingTime = 0;
            lblTimer.Text = _playingTime.ToString();
        }

        //private void ResetGame() {
        //    if (_boardVisual.isPlaying) {
        //        MessageBox.Show("Reset test");
        //    }
        //    //_boardVisual = new BoardVisual(boardWidth, boardHeight, numMines, LOCATION_X, LOCATION_Y, this);

        //    InitializeGame();
        //}

        private void timerPlaying_Tick(object sender, EventArgs e) {
            _playingTime++;
            lblTimer.Text = _playingTime.ToString();
        }

        //重置遊戲
        private void restartToolStripMenuItem_Click(object sender, EventArgs e) {
            //若仍在遊戲狀態則要求確認
            if (_boardVisual.isPlaying) {
                var result = MessageBox.Show("Restart?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No) { return; }
            }
            _boardVisual.ResetGame(boardWidth, boardHeight, numMines);
            //_boardVisual = new BoardVisual(boardWidth, boardHeight, numMines, LOCATION_X, LOCATION_Y, this);
            InitializeGame();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e) {
            boardWidth = 5;
            boardHeight = 5;
        }

        //離開遊戲
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            //若仍在遊戲狀態則要求確認
            if (_boardVisual.isPlaying) {
                var result = MessageBox.Show("Exit?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No) { return; }
            }
            Application.Exit();
        }
    }
}
