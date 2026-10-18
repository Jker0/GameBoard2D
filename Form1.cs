using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBoard2D
{
    public partial class Form1 : Form
    {
        BoardCanvas BoardCanvas { get; set; }
        public Form1()
        {
            InitializeComponent();
            BoardCanvas = new BoardCanvas(this.pictureBox1);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            BoardCanvas.UpdateCanvas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(BoardCanvas[0,3].ToString());
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(BoardCanvas.DrawCellByPoint(e.Location, 1).ToString());
        }
    }
}
