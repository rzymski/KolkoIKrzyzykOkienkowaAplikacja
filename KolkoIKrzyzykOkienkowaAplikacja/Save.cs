using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KolkoIKrzyzykOkienkowaAplikacja
{
    public partial class Save : Form
    {
        private int width = 1920;
        private int height = 1080;

        public Save()
        {
            InitializeComponent();
        }

        public Save(int width, int height)
        {
            InitializeComponent();
            this.width = width;
            this.height = height;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.LoadFile(openFileDialog.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SaveFile(saveFileDialog.FileName);
            }
        }

        private void btnSaveVariable_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Normal text file (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog.FileName, "Ala ma kota");
        }

        private void btnOpenVariable_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Normal text file (*.txt)|*.txt";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.RestoreDirectory = true;
            string text = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                text = File.ReadAllText(openFileDialog.FileName);
            Console.WriteLine(text);
        }
    }
}
