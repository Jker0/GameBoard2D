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
            //BoardCanvas.UpdateCanvas();
        }

        private void ClearBt_Click(object sender, EventArgs e)
        {
            BoardCanvas.ClearCanvas();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            BoardCanvas.DrawCellByPoint(e.Location, 2);
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
        }
    }
}
