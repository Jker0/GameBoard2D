using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBoard2D
{
    internal class BoardCanvas
    {
        private const int CELL_SIZE_PIXELS = 30;                    // Размер клетки игрового поля, в пикселях
        private const int ROWS_NUMBER = 15;                         // Количество рядов в игровом поле
        private const int COLS_NUMBER = 15;                         // Количество столбцов в игровом поле
        private const int FIELD_LEFT_OFFSET_PIXELS = 30;            // Отступ в пикселях от левого края формы
        private const int FIELD_TOP_OFFSET_PIXELS = 15;             // Отступ в пикселях от верхнего края формы

        private Color[] Colors { get; set; } = {Color.Black, Color.White, Color.Red, Color.Green};

        private int[,] Cells { get; set; } = new int[ROWS_NUMBER, COLS_NUMBER];

        /// <summary>
        /// Main board
        /// </summary>
        PictureBox PBCanvas {  get; set; }  

        public BoardCanvas(PictureBox pbCanvas)
        {
            PBCanvas = pbCanvas;            

            Bitmap buf;
            buf = new Bitmap(PBCanvas.Width, PBCanvas.Height);
            PBCanvas.Image = buf;

            UpdateGrid();
        }

        public int this[int i, int j]
        {
            get { return Cells[i, j]; }
            set { Cells[i, j] = value; }
        }

        private void UpdateGrid()
        {
            using (Graphics g = Graphics.FromImage(PBCanvas.Image))
            {
                g.Clear(Colors[0]);
                DrawGrid(g);
                PBCanvas.Refresh();
            }
        }

        private void DrawGrid(Graphics g)
        {
            for (int row = 0; row <= ROWS_NUMBER; row++)
            {
                g.DrawLine(Pens.Cyan,
                    new Point(FIELD_LEFT_OFFSET_PIXELS, FIELD_TOP_OFFSET_PIXELS + row * CELL_SIZE_PIXELS),
                    new Point(FIELD_LEFT_OFFSET_PIXELS + CELL_SIZE_PIXELS * ROWS_NUMBER, FIELD_TOP_OFFSET_PIXELS + row * CELL_SIZE_PIXELS)
                );
            }

            for (int col = 0; col <= COLS_NUMBER; col++)
            {
                g.DrawLine(Pens.Cyan,
                    new Point(FIELD_LEFT_OFFSET_PIXELS + col * CELL_SIZE_PIXELS, FIELD_TOP_OFFSET_PIXELS),
                    new Point(FIELD_LEFT_OFFSET_PIXELS + col * CELL_SIZE_PIXELS, FIELD_TOP_OFFSET_PIXELS + CELL_SIZE_PIXELS * COLS_NUMBER)
                );
            }
        }

        public void UpdateCanvas()
        {
            UpdateGrid();
        }

        private Point FindCell(Point point)
        {           
            return new Point((point.X - FIELD_LEFT_OFFSET_PIXELS) / CELL_SIZE_PIXELS, (point.Y - FIELD_TOP_OFFSET_PIXELS) / CELL_SIZE_PIXELS);
        }

        public int DrawCellByPoint(Point point, int color)
        {
            if (color >= Colors.Length)
                return -1;
            
            Point TargetCell = FindCell(point);


            return Cells[TargetCell.X, TargetCell.Y]; 
        }


    }
}
