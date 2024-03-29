using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace KolkoIKrzyzykOkienkowaAplikacja
{
    public partial class Game5x5 : Form
    {
        private int width = 1920;
        private int height = 1080;
        private string symbol = "X";
        private int symbolValue = 1; //0-kolko 1-krzyz 
        private int[,] board2D = new int[5, 5];
        private int chessSize = 5;
        private List<int> listWinnerPositions = new List<int>();
        private int moveCount = 0;
        private bool availableMoves = true;
        private List<Button> buttons = new List<Button>();

        public Game5x5()
        {
            InitializeComponent();
            this.width = Screen.PrimaryScreen.Bounds.Width;
            this.height = Screen.PrimaryScreen.Bounds.Height;
            setStartedParameters();
        }

        public Game5x5(int width, int height)
        {
            InitializeComponent();
            this.width = width;
            this.height = height;
            setStartedParameters();
        }

        public Game5x5(int width, int height, NecessaryData startData)
        {
            InitializeComponent();
            this.width = width;
            this.height = height;
            setStartedParameters(startData);
        }

        private void setStartedParameters(NecessaryData data)
        {
            this.Size = new Size(width, height);
            this.StartPosition = FormStartPosition.CenterScreen;
            maxScreenResolution();
            board2D = data.board;
            moveCount = data.pmoveCount;
            symbolValue = data.psymbolValue;
            if (symbolValue == 0)
                symbol = "O";
            else
                symbol = "X";
            lblTurnDisplay.Text = "Ruch: " + symbol;
        }

        private void setStartedParameters()
        {
            this.Size = new Size(width, height);
            this.StartPosition = FormStartPosition.CenterScreen;
            maxScreenResolution();
            for (int i = 0; i < chessSize; i++)
                for (int j = 0; j < chessSize; j++)
                    board2D[i, j] = -1;
        }

        private void maxScreenResolution()
        {
            //maksymalny rozmiar ekranu bez pasku zadan
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void goToMenu()
        {
            Menu myForm = new Menu(width, height);
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void Game5x5_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape) 
            {
                this.TopMost = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Game5x5_Load(object sender, EventArgs e)
        {
            ButtonArray();
            //przerysowanie tablicy buttonow
            for (int i = 0; i < chessSize; i++)
            {
                for (int j = 0; j < chessSize; j++)
                {
                    if (board2D[i, j] == 1)
                        buttons[i * chessSize + j].Text = "X";
                    else if (board2D[i, j] == 0)
                        buttons[i * chessSize + j].Text = "O";
                }
            }
            for (int i = 0; i < buttons.Count; i++)
                buttons[i].Font = new Font("Arial", buttons[i].Height / 2, FontStyle.Bold);
        }

        public void ButtonArray()
        {
            for(int i=0; i< chessSize*chessSize; i++)
            {
                Button btn= new Button();
                btn.Size = new Size((int)(width*6/10/(chessSize+0.2)), (int)(height*8/10/(chessSize+0.1)));
                btn.Text = "";//i.ToString();
                btn.Click += btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
                buttons.Add(btn);
            }
        }

        public void btn_Paint(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
        }

        public void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text != "" || !availableMoves)
                return;
            //btn.Enabled= false;
            btn.Text = symbol;
            btn.Font = new Font("Arial", btn.Height/2, FontStyle.Bold);
            if (symbol == "X")
                symbol = "O";
            else
                symbol = "X";
            lblTurnDisplay.Text = "Ruch: " + symbol;

            int nr = btn.TabIndex;//Int32.Parse(btn.Text);
            Console.WriteLine(nr);
            board2D[nr/ chessSize, nr% chessSize] = symbolValue; // nr/5 to wiersz, a nr%5 to kolumna
            int choice = -1;
            int wayToWin = Check.checkIfEndGame(board2D, ++moveCount, chessSize, nr%chessSize, nr/chessSize, 4, ref listWinnerPositions);
            if(wayToWin != 0)
            {
                availableMoves = false;
                //label1.Text = string.Join(",", listWinnerPositions);
                for (int i = 0; i < listWinnerPositions.Count; i += 2)
                {
                    int x = listWinnerPositions[i]*chessSize + listWinnerPositions[i+1];
                    foreach(Button b in flowLayoutPanel1.Controls)
                    {
                        if(b.TabIndex == x)
                            b.ForeColor = Color.Red;
                    }
                }
                this.TopMost= false;
                if(wayToWin == -1)
                {
                    lblTurnDisplay.Text = "Remis";
                    choice = MyOwnMessageClass.ShowMessage("Remis", "Wynik gry");
                }
                else if (symbolValue == 0)
                {
                    lblTurnDisplay.Text = "Wygraly: O";
                    choice = MyOwnMessageClass.ShowMessage("O", "Wynik gry");
                }
                else
                {
                    lblTurnDisplay.Text = "Wygraly: X";
                    choice = MyOwnMessageClass.ShowMessage("X", "Wynik gry");
                }
            }
            symbolValue = (symbolValue + 1) % 2; //zmiana symbolu
            
            if(choice == 0) 
            {
                Game5x5 myForm = new Game5x5(width, height);
                this.Hide();
                myForm.ShowDialog();
                this.Close();
            }
            if(choice == 1)
            {
                goToMenu();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            flowLayoutPanel1.Location = new Point((int)(width/5), height/7);
            flowLayoutPanel1.Size= new Size((int)(width*6/10), (int)(height*85/100));
        }

        private void lblTurnDisplay_Paint(object sender, PaintEventArgs e)
        {
            lblTurnDisplay.Font = new Font("Arial", height/12, FontStyle.Bold);
            lblTurnDisplay.Location = new Point((width-lblTurnDisplay.Width)/2, 0);
        }

        private void btnExit_Paint(object sender, PaintEventArgs e)
        {
            btnExit.Size = new Size(50, 50);
            btnExit.Location = new Point(width - btnExit.Width - 30, 30);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenu_Paint(object sender, PaintEventArgs e)
        {
            btnMenu.Size = new Size(100, 50);
            btnMenu.Location = new Point(width - 50 - 30 - btnMenu.Width, 30);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            goToMenu();
        }

        private void btnSave_Paint(object sender, PaintEventArgs e)
        {
            btnSave.Size = new Size(250, 50);
            btnSave.Location = new Point(30, 30);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NecessaryData saveData = new NecessaryData
            {
                board = board2D,
                pchessSize = chessSize,
                psymbolValue = symbolValue,
                pmoveCount = moveCount,
            };

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "My own extension (*.moe)|*.moe";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                FileWithData.Save(saveFileDialog.FileName, saveData);
        }
    }
}