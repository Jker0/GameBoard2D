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

        Graphics Graphic { get; set; }      
        private List<Color> Colors { get; set; } = new List<Color>{Color.Black, Color.White, Color.Red, Color.Green}; 

        private Color[,] Cells { get; set; } = new Color[ROWS_NUMBER, COLS_NUMBER];
        

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
            Graphic = Graphics.FromImage(PBCanvas.Image);

            UpdateGrid();
        }

        public Color this[int i, int j]
        {
            get { return Cells[i, j]; }
            set { Cells[i, j] = value; }
        }

        public void UpdateCanvas()
        {
            UpdateGrid();
        }

        /// <summary>
        /// Заливаем переданным цветом квадрат решетки
        /// </summary>
        /// <param name="point"> номер ячейки в массиве </param>
        /// <param name="color"> цвет заливки </param>
        public void DrawCellByPoint(Point point, int color)
        {
            Color ColorPen = getColor(color);

            Point TargetCell = FindCell(point);
            if (TargetCell.X == -1 || TargetCell.Y == -1)
                return;

            Cells[TargetCell.X, TargetCell.Y] = ColorPen;
            Rectangle rectangle = FindRectangle(point);

            Graphic.FillRectangle(new SolidBrush(ColorPen), FindRectangle((Point)TargetCell));
            PBCanvas.Refresh();
        }

        public void SetColors(List<Color> colors)
        {
            if (colors.Count <= 2)
                return;
            Colors = colors;
        }

        /// Private

        private Color getColor(int i)
        {
            if(i >= Colors.Count)
                return Colors[0];   

            return Colors[i]; 
        }

        private Point FindCell(Point point)
        {
            int X = (point.X - FIELD_LEFT_OFFSET_PIXELS) / CELL_SIZE_PIXELS;
            int Y = (point.Y - FIELD_TOP_OFFSET_PIXELS) / CELL_SIZE_PIXELS;

            if(point.X - FIELD_LEFT_OFFSET_PIXELS < 0 || X >= ROWS_NUMBER || point.Y - FIELD_TOP_OFFSET_PIXELS < 0 || Y >= COLS_NUMBER)
                return new Point(-1, -1);

            return new Point(X, Y);
        }


        /// <summary>
        /// Находит прямоугольник по переданному номеру ячейки
        /// </summary>
        /// <param name="targetCell">номер ячейки в массиве </param>
        /// <returns></returns>
        private Rectangle FindRectangle(Point targetCell)
        {
            int X0 = (targetCell.X * CELL_SIZE_PIXELS) + FIELD_LEFT_OFFSET_PIXELS;
            int Y0 = (targetCell.Y * CELL_SIZE_PIXELS) + FIELD_TOP_OFFSET_PIXELS;

            return new Rectangle(X0, Y0, CELL_SIZE_PIXELS, CELL_SIZE_PIXELS);
        }

        private void UpdateGrid()
        {
            Graphic.Clear(Colors[0]);
            DrawGrid();
            PBCanvas.Refresh();

        }

        private void DrawGrid()
        {
            for (int row = 0; row <= ROWS_NUMBER; row++)
            {
                Graphic.DrawLine(new Pen(Colors[1], 2),
                    new Point(FIELD_LEFT_OFFSET_PIXELS, FIELD_TOP_OFFSET_PIXELS + row * CELL_SIZE_PIXELS),
                    new Point(FIELD_LEFT_OFFSET_PIXELS + CELL_SIZE_PIXELS * ROWS_NUMBER, FIELD_TOP_OFFSET_PIXELS + row * CELL_SIZE_PIXELS)
                );
            }

            for (int col = 0; col <= COLS_NUMBER; col++)
            {
                Graphic.DrawLine(new Pen(Colors[1], 2),
                    new Point(FIELD_LEFT_OFFSET_PIXELS + col * CELL_SIZE_PIXELS, FIELD_TOP_OFFSET_PIXELS),
                    new Point(FIELD_LEFT_OFFSET_PIXELS + col * CELL_SIZE_PIXELS, FIELD_TOP_OFFSET_PIXELS + CELL_SIZE_PIXELS * COLS_NUMBER)
                );
            }
        }


    }
}
