using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Paint2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize();
            this.Size = new Size(800, 600);



        }
        private PictureBox pictureBox;
        private bool isResizing = false;
        private Point lastMousePosition;
    


        private class ArrayPoints
        {
            private int index = 0;
            private Point[] points;

            public ArrayPoints(int size)
            {
                if (size <= 0)
                {
                    size = 2;
                }
                points = new Point[size];
            }

            public void SetPoint(int x, int y)
            {
                if (index >= points.Length)
                {
                    index = 0;
                }
                points[index] = new Point(x, y);
                index++;
            }

            public void ResetPoints()
            {
                index = 0;
            }

            public int GetCountPoints()
            {
                return index;
            }

            public Point[] GetPoints()
            {
                return points;
            }
        }

        private bool isMouse = false;
        private ArrayPoints arrayPoints = new ArrayPoints(2);

        Bitmap map = new Bitmap(100, 100);
        Graphics graphics;

        Pen pen = new Pen(Color.Black, 3f);

        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(map);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Проверяем, находится ли курсор у границы для изменения размера
                int resizeMargin = 10;
                if (e.X >= pictureBox.Width - resizeMargin || e.Y >= pictureBox.Height - resizeMargin)
                {
                    isResizing = true;
                    pictureBox.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    lastMousePosition = e.Location;
                    pictureBox.Cursor = Cursors.SizeAll;
                }
            }
            isMouse = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouse)
            {
                return;
            }
            arrayPoints.SetPoint(e.X, e.Y);
            if (arrayPoints.GetCountPoints() >= 2)
            {
                graphics.DrawLines(pen, arrayPoints.GetPoints());
                pictureBox1.Image = map;
                arrayPoints.SetPoint(e.X, e.Y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
            arrayPoints.ResetPoints();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }

        //Color SelectedColor 
        //{ 
        //    get 
        //    {
        //        return colorDialog1.Color;
        //    } 
        //}

        private void button8_Click(object sender, EventArgs e)
        {
            //if(colorDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    pen.Color = colorDialog1.Color;
            //    ((Button)sender).BackColor = colorDialog1.Color;
            //}
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
        private void button10_Click(object sender, EventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.Clear(this.BackColor); // Очищаем предыдущие рисунки

                    // Рисуем снежинку в центре формы
                    DrawSnowflake(g, this.ClientSize.Width / 2, this.ClientSize.Height / 2, 50);
                
            }
        }
        private void DrawSnowflake(Graphics g, int centerX, int centerY, int size)
        {
            using (Pen snowPen = new Pen(Color.Blue, 2))
            using (GraphicsPath path = new GraphicsPath())
            {
                // Создаем одну ветвь снежинки
                path.AddLine(0, 0, 0, -size / 2);
                path.AddLine(0, -size / 4, size / 4, -size / 3);
                path.AddLine(0, -size / 4, -size / 4, -size / 3);

                // Применяем трансформацию для центрального положения
                Matrix m = new Matrix();
                m.Translate(centerX, centerY);

                // Рисуем 6 ветвей снежинки (360°/6 = 60°)
                for (int i = 0; i < 6; i++)
                {
                    path.Transform(m);
                    g.DrawPath(snowPen, path);
                    m.Rotate(60, MatrixOrder.Append);
                }
            }
        }
    }
}
