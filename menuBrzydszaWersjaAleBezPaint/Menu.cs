using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolkoIKrzyzykOkienkowaAplikacja
{
    public partial class Menu : Form
    {
        //domyślnie Full HD
        private int width=1920;
        private int height=1080;

        public Menu()
        {
            InitializeComponent();

            this.width = Screen.PrimaryScreen.Bounds.Width;
            this.height = Screen.PrimaryScreen.Bounds.Height;
            this.Size = new Size(width, height);
            this.StartPosition = FormStartPosition.CenterScreen;
            setButtons();
            maxScreenResolution();
            //setButtons();
        }

        public Menu(int width, int height)
        {
            InitializeComponent();

            this.width = width;
            this.height = height;
            this.Size = new Size(width, height);
            this.StartPosition = FormStartPosition.CenterScreen;
            setButtons();
            maxScreenResolution();
            //setButtons();
        }

        private void maxScreenResolution()
        {
            //maksymalny rozmiar ekranu bez pasku zadan
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Game3x3 myForm = new Game3x3(width, height);
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            Game5x5 myForm = new Game5x5(width, height);
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void btnStart3_Click(object sender, EventArgs e)
        {
            Game13x13 myForm = new Game13x13(width, height);
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.TopMost = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void setButtonSizeAndLocation(Button btn, int nrPosition)
        {
            int btnWidth = (int)(width * 0.8);
            int btnHeight = (int)(height * 0.1);
            int btnStartWidthPosition = (width - btnWidth) / 2;
            btn.Size = new Size(btnWidth, btnHeight);
            btn.Location = new Point(btnStartWidthPosition, (int)(height * (0.3+nrPosition*0.13)));
            Font f = new Font("Arial", (int)(btn.Height * 0.5), FontStyle.Bold);
            btn.Font = f;
        }

        private void setButtons()
        {
            setButtonSizeAndLocation(btnStart, 0);
            btnStart.Text = "Rozpocznij grę 3x3";
            setButtonSizeAndLocation(btnStart2, 1);
            btnStart2.Text = "Rozpocznij grę 5x5";
            setButtonSizeAndLocation(btnStart3, 2);
            btnStart3.Text = "Rozpocznij grę 13x13";
            setButtonSizeAndLocation(btnLoad, 3);
            btnLoad.Text = "Wczytaj grę";
            setButtonSizeAndLocation(btnEnd, 4);
            btnEnd.Text = "Zakończ grę";
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LabelTitle_Paint(object sender, PaintEventArgs e)
        {
            LabelTitle.Location = new Point((width-LabelTitle.Width)/2, (int)(height * 0.1));
            LabelTitle.Text = "KÓŁKO I KRZYŻYK";
            LabelTitle.Font = new Font("Arial", height/10, FontStyle.Bold);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "My own extension (*.moe)|*.moe";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                NecessaryData fileData = FileWithData.Load<NecessaryData>(openFileDialog.FileName);
                switch(fileData.pchessSize) 
                {
                    case (3):
                        Game3x3 game3x3 = new Game3x3(width, height, fileData);
                        this.Hide();
                        game3x3.ShowDialog();
                        this.Close();
                        break;
                    case (5):
                        Game5x5 game5x5 = new Game5x5(width, height, fileData);
                        this.Hide();
                        game5x5.ShowDialog();
                        this.Close();
                        break;
                    case (13):
                        Game13x13 game13x13 = new Game13x13(width, height, fileData);
                        this.Hide();
                        game13x13.ShowDialog();
                        this.Close();
                        break;
                }
            }
        }
    }
}
