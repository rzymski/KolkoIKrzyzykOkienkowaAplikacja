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
    public partial class resultMessage : Form
    {
        int choice = -1;

        public resultMessage()
        {
            InitializeComponent();
        }

        public Image Image
        {
            get { return picBox.Image; }
            set { picBox.Image = value; }
        }
        public string Message 
        {
            get { return lblInformation.Text; }
            set { lblInformation.Text = value; } 
        }
        public int Choice
        { get { return choice; }
        }

        private void resultMessage_Load(object sender, EventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            choice= 0;
            this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            choice= 1;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            choice= 2;
            Application.Exit();
            //this.Close();
        }
    }
}
