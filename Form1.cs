using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBoard2D_Jker0
{
    public partial class Form1 : Form
    {
        BoardCanvas BoardCanvas { get; set; }
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            BoardCanvas = new BoardCanvas(pictureBox1.Image);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //BoardCanvas.UpdateCanvas();
        }

        private void ClearBt_Click(object sender, EventArgs e)
        {
            BoardCanvas.ClearCanvas();
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            BoardCanvas.DrawCellByPoint(e.Location, 2);
            pictureBox1.Refresh();
        }

        private void TestBt_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (BoardCanvas[i,j] != 0)
                        BoardCanvas[i, j] = 1;
                }

            BoardCanvas.UpdateCanvas();
            pictureBox1.Refresh();
        }

        private void RefreshBt_Click(object sender, EventArgs e)
        {
            BoardCanvas.RefreshCanvas();
            pictureBox1.Refresh();
        }
    }
}
