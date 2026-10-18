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
        private const int FIELD_LEFT_OFFSET_PIXELS = 40;            // Отступ в пикселях от левого края формы
        private const int FIELD_TOP_OFFSET_PIXELS = 15;             // Отступ в пикселях от правого края формы

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

        private void UpdateGrid()
        {
            using (Graphics g = Graphics.FromImage(PBCanvas.Image))
            {
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
    }
}
