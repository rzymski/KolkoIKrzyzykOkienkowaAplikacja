using System.Windows.Forms;

namespace KolkoIKrzyzykOkienkowaAplikacja
{
    public partial class Form1 : Form
    {
        private int width = 1920;
        private int height = 1080;
        List<Button> buttons = new List<Button>();

        //public Form1()
        //{
        //    InitializeComponent();

        //    width = Screen.PrimaryScreen.Bounds.Width;
        //    height = Screen.PrimaryScreen.Bounds.Height;
        //    this.Size = new Size(width, height);
        //    this.StartPosition = FormStartPosition.CenterScreen;
        //    maxScreenResolution();

        //}

        public Form1(int width, int height)
        {
            InitializeComponent();

            this.width = width;
            this.height = height;
            this.Size = new Size(width, height);
            this.StartPosition = FormStartPosition.CenterScreen;
            maxScreenResolution();
        }

        private void maxScreenResolution()
        {
            //maksymalny rozmiar ekranu bez pasku zadan
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu myForm = new Menu(width, height);
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape) 
            {
                this.TopMost = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string w = Screen.PrimaryScreen.Bounds.Width.ToString();
            string h = Screen.PrimaryScreen.Bounds.Height.ToString();
            string wh = Screen.PrimaryScreen.Bounds.Size.ToString();
            //label1.Text= w + "\n" + h + "\n" + wh;

            buttons[20].Text = "OK";

            foreach(var b in buttons)
            {
                label1.Text = label1.Text + b.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ButtonArray();
        }

        public void ButtonArray()
        {
            for(int i=0; i<25; i++)
            {
                Button btn= new Button();
                btn.Size = new Size((int)(width*6/10/5.1), (int)(height*8/10/5.1));
                btn.Text = i.ToString();
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
            btn.Text = "X";
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            flowLayoutPanel1.Location = new Point(width/5, height/7);
            flowLayoutPanel1.Size= new Size((int)(width*6/10), (int)(height*8/10));
        }
    }
}