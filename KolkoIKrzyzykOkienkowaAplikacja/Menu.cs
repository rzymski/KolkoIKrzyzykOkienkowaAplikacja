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
            maxScreenResolution();
        }

        public Menu(int width, int height)
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
            btn.Location = new Point(btnStartWidthPosition, (int)(height * (0.4+nrPosition*0.1)));
        }

        private void btnStart_Paint(object sender, PaintEventArgs e)
        {
            btnStart.Text = "Rozpocznij grę 3x3";
            Font f = new Font("Arial", (int)(btnStart.Height * 0.5), FontStyle.Bold);
            btnStart.Font = f;
            setButtonSizeAndLocation(btnStart, 0);
        }

        private void btnStart2_Paint(object sender, PaintEventArgs e)
        {
            btnStart2.Text = "Rozpocznij grę 5x5";
            Font f = new Font("Arial", (int)(btnStart2.Height * 0.5), FontStyle.Bold);
            btnStart2.Font = f;
            setButtonSizeAndLocation(btnStart2, 1);
        }

        private void btnStart3_Paint(object sender, PaintEventArgs e)
        {
            btnStart3.Text = "Rozpocznij grę 13x13";
            Font f = new Font("Arial", (int)(btnStart3.Height * 0.5), FontStyle.Bold);
            btnStart3.Font = f;
            setButtonSizeAndLocation(btnStart3, 2);
        }

        private void btnLoad_Paint(object sender, PaintEventArgs e)
        {
            btnLoad.Text = "Wczytaj grę";
            Font f = new Font("Arial", (int)(btnLoad.Height*0.5), FontStyle.Bold);
            btnLoad.Font = f;
            setButtonSizeAndLocation(btnLoad, 3);
        }

        private void btnEnd_Paint(object sender, PaintEventArgs e)
        {
            btnEnd.Text = "Zakończ grę";
            Font f = new Font("Arial", (int)(btnEnd.Height * 0.5), FontStyle.Bold);
            btnEnd.Font = f;
            setButtonSizeAndLocation(btnEnd, 4);
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
                        Game3x3 myForm = new Game3x3(width, height, fileData);
                        this.Hide();
                        myForm.ShowDialog();
                        this.Close();
                        break;
                    case (5):
                        //Game5x5 myForm = new Game5x5(width, height, fileData);
                        break;
                    case (13):
                        //Game13x13 myForm = new Game13x13(width, height, fileData);
                        break;
                }
            }
        }
    }
}
