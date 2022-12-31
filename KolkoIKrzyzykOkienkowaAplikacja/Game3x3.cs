using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace KolkoIKrzyzykOkienkowaAplikacja
{
    public partial class Game3x3 : Form
    {
        private int width = 1920;
        private int height = 1080;
        private string symbol = "X";
        private int symbolValue = 1; //0-kolko 1-krzyz 
        private int[,] board2D = new int[3, 3];
        private int chessSize = 3;
        private List<int> listWinnerPositions = new List<int>();
        private int moveCount = 0;
        private bool availableMoves = true;

        public Game3x3()
        {
            InitializeComponent();
            this.width = Screen.PrimaryScreen.Bounds.Width;
            this.height = Screen.PrimaryScreen.Bounds.Height;
            setStartedParameters();
        }

        public Game3x3(int width, int height)
        {
            InitializeComponent();
            this.width = width;
            this.height = height;
            setStartedParameters();
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

        private void Game3x3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape) 
            {
                this.TopMost = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Game3x3_Load(object sender, EventArgs e)
        {
            ButtonArray();
        }

        public void ButtonArray()
        {
            for(int i=0; i< chessSize*chessSize; i++)
            {
                Button btn= new Button();
                btn.Size = new Size((int)(width*6/10/(chessSize+0.1)), (int)(height*8/10/(chessSize+0.1)));
                btn.Text = "";
                btn.Click += btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
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

            int nr = btn.TabIndex;
            Console.WriteLine(nr);
            board2D[nr/chessSize, nr% chessSize] = symbolValue;
            int choice = -1;
            int wayToWin = Check.checkIfEndGame(board2D, ++moveCount, chessSize, nr%chessSize, nr/chessSize, 3, ref listWinnerPositions);
            if(wayToWin != 0)
            {
                availableMoves = false;
                for (int i = 0; i < listWinnerPositions.Count; i += 2)
                {
                    int x = listWinnerPositions[i]* chessSize + listWinnerPositions[i+1];
                    foreach(Button b in flowLayoutPanel1.Controls)
                    {
                        if(b.TabIndex == x)
                            b.ForeColor = Color.Red;
                    }
                }
                this.TopMost= false;
                if(wayToWin == -1)
                {
                    lblTurnDisplay.Text = "Gra zakonczona remisem.";
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
            symbolValue = (symbolValue + 1) % 2;
            
            if(choice == 0) 
            {
                Game3x3 myForm = new Game3x3(width, height);
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
            flowLayoutPanel1.Location = new Point(width/5, height/7);
            flowLayoutPanel1.Size= new Size((int)(width*6/10), (int)(height*8/10));
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
            btnMenu.Location = new Point(30, 30);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            goToMenu();
        }
    }
}