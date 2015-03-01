using System;
using System.Windows.Forms;
using System.Drawing;

/*/ 就只是個踩地雷 written by shoshino21 2015.3.1 /*/

namespace MineSweeper {
    public partial class MainForm : Form {
        private BoardVisual _boardVisual;
        private OptionForm _optionForm;
        private AboutForm _aboutForm;
        private double _playingTime;            //遊戲時間

        public int BoardWidth { get; set; }     //盤面寬度
        public int BoardHeight { get; set; }    //盤面高度
        public int NumMines { get; set; }       //地雷數量

        public const int CELL_SIZE = 30;        //方塊大小，配合圖片大小所以不能亂改
        public const int MARGIN_UP = 70;        //盤面和視窗邊緣的間距，沒事別亂改
        public const int MARGIN_BOTTOM = 50;
        public const int MARGIN_LEFT = 5;
        public const int MARGIN_RIGHT = 25;

        public MainForm() {
            InitializeComponent();
            _optionForm = new OptionForm();
            _aboutForm = new AboutForm();

            _optionForm.ShowDialog();       //遊戲開始時先Show Option
            GetOptionSetting();

            _boardVisual = new BoardVisual(this.BoardWidth, this.BoardHeight, this.NumMines, this);
            _boardVisual.LabelRemaining = this.lblRemaining;
            _boardVisual.LabelTimer = this.lblTimer;
            _boardVisual.TimerPlaying = this.timerPlaying;

            InitializeGame();
        }

        //取得難度設定
        private void GetOptionSetting() {
            this.BoardWidth = _optionForm.BoardWidth;
            this.BoardHeight = _optionForm.BoardHeight;
            this.NumMines = _optionForm.NumMines;
        }

        //遊戲初始化
        private void InitializeGame() {
            //畫面大小隨盤面調整
            this.Width = CELL_SIZE * this.BoardWidth + MARGIN_LEFT + MARGIN_RIGHT;
            this.Height = CELL_SIZE * this.BoardHeight + MARGIN_UP + MARGIN_BOTTOM;
            //重置計數器
            lblRemaining.Text = NumMines.ToString();
            timerPlaying.Enabled = false;
            _playingTime = 0;
            lblTimer.Text = _playingTime.ToString();
        }

        private void timerPlaying_Tick(object sender, EventArgs e) {
            _playingTime += 0.1D;
            lblTimer.Text = _playingTime.ToString("F1");    //小數點一位
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e) {
            //若仍在遊戲狀態則要求確認
            if (_boardVisual.IsPlaying) {
                var result = MessageBox.Show("Restart?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No) { return; }
            }
            GetOptionSetting();
            _boardVisual.ResetBoard(this.BoardWidth, this.BoardHeight, this.NumMines);
            InitializeGame();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e) {
            _optionForm.ShowDialog();
            //若還沒開始遊戲則直接產生新盤面
            if (!_boardVisual.IsPlaying) {
                restartToolStripMenuItem_Click(sender, e);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            //若仍在遊戲狀態則要求確認
            if (_boardVisual.IsPlaying) {
                var result = MessageBox.Show("Exit?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No) { return; }
            }
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            _aboutForm.ShowDialog();
        }
    }
}
