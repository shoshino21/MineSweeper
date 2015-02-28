using System;
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
        private const int LOCATION_X = 10;
        private const int LOCATION_Y = 35;

        private int _playingTime = 0;
        //private bool _isPlaying = false;

        public MainForm() {
            InitializeComponent();

            _boardVisual = new BoardVisual(boardWidth, boardHeight, numMines, LOCATION_X, LOCATION_Y, this);

            _boardVisual.lblRemaining = this.lblRemaining;
            _boardVisual.lblTimer = this.lblTimer;
            _boardVisual.timerPlaying = this.timerPlaying;

            InitializeGame();
        }

        private void InitializeGame() {
            this.lblRemaining.Text = numMines.ToString();
            this.lblTimer.Text = "0";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {

        }

        private void restartRToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void MainForm_Load(object sender, EventArgs e) {

        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void timerPlaying_Tick(object sender, EventArgs e) {
            _playingTime++;
            lblTimer.Text = _playingTime.ToString();
        }
    }
}
