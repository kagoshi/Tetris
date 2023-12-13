using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Controllers;

namespace Tetris
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SaveContoller.Load();

            listView1.Items.Clear();

            string[] items = new string[2];
            foreach (Dictionary<string, int> pairs in SaveContoller.gameData["goose"])
            {
                foreach (KeyValuePair<string, int> pair in pairs)
                {
                    items[0] = pair.Key;
                    items[1] = pair.Value.ToString();
                    ListViewItem lvi = new ListViewItem(items);
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BezRaznici.MainMenu.Hide();
            new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
