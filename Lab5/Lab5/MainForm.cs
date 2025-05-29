using System;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace Lab5
{
    public partial class MainForm : Form
    {
        private Equation currentEquation;
        private Integrator currentIntegrator;
        private Bitmap graphBitmap;
        private Graphics graphGraphics;
        private Pen graphPen = new Pen(Color.Blue, 2);
        private Font axisFont = new Font("Arial", 8);
        private Brush axisBrush = Brushes.Black;

        public MainForm()
        {
            InitializeComponent();
            InitializeComponents();
            graphBitmap = new Bitmap(picGraph.Width, picGraph.Height);
            graphGraphics = Graphics.FromImage(graphBitmap);
            picGraph.Image = graphBitmap;
        }

        private void InitializeComponents()
        {
            cmbEquationType.Items.AddRange(new object[] { "Квадратное уравнение", "Функция sin(ax)/x" });
            cmbEquationType.SelectedIndex = 0;
            cmbIntegratorType.Items.AddRange(new object[] { "Метод прямоугольников", "Метод трапеций" });
            cmbIntegratorType.SelectedIndex = 0;
            numX1.Value = -10;
            numX2.Value = 10;
            numA.Value = 1;
            numB.Value = -3;
            numC.Value = 2;
            numIntegralX1.Value = 0;
            numIntegralX2.Value = 1;
            numPartitions.Value = 1000;

            cmbEquationType_SelectedIndexChanged(null, null);
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cmbEquationType.SelectedIndex)
                {
                    case 0:
                        currentEquation = new QuadraticEquation(
                            (double)numA.Value,
                            (double)numB.Value,
                            (double)numC.Value);
                        break;
                    case 1:
                        currentEquation = new SinEquation((double)numA.Value);
                        break;
                }

                DrawFunctionGraph();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при построении графика: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawFunctionGraph()
        {
            if (currentEquation == null) return;

            double x1 = (double)numX1.Value;
            double x2 = (double)numX2.Value;
            graphGraphics.Clear(Color.White);
            var (xValues, yValues) = FunctionDataGenerator.GenerateFunctionData(x1, x2, currentEquation);
            double yMin = double.MaxValue;
            double yMax = double.MinValue;
            foreach (double y in yValues)
            {
                if (y < yMin) yMin = y;
                if (y > yMax) yMax = y;
            }
            yMin -= 0.1 * Math.Abs(yMin);
            yMax += 0.1 * Math.Abs(yMax);
            if (yMin == yMax) 
            {
                yMin -= 1;
                yMax += 1;
            }
            int padding = 40;
            int width = picGraph.Width - 2 * padding;
            int height = picGraph.Height - 2 * padding;
            int xAxisY = (int)(picGraph.Height - padding + yMax * height / (yMax - yMin));
            graphGraphics.DrawLine(Pens.Black, padding, xAxisY, picGraph.Width - padding, xAxisY);
            graphGraphics.DrawLine(Pens.Black, padding, padding, padding, picGraph.Height - padding);
            graphGraphics.DrawString("X", axisFont, axisBrush, picGraph.Width - padding + 5, xAxisY - 15);
            graphGraphics.DrawString("Y", axisFont, axisBrush, padding + 5, padding - 15);
            PointF[] points = new PointF[xValues.Length];
            for (int i = 0; i < xValues.Length; i++)
            {
                float x = padding + (float)((xValues[i] - x1) / (x2 - x1) * width);
                float y = padding + (float)((yMax - yValues[i]) / (yMax - yMin) * height);
                points[i] = new PointF(x, y);
            }
            graphGraphics.DrawCurve(graphPen, points);
            picGraph.Invalidate();
            txtFunctionInfo.Text = $"Функция: {GetFunctionString()}\r\nДиапазон: x ∈ [{x1:F2}, {x2:F2}]\r\nYmin: {yMin:F2}, Ymax: {yMax:F2}";
        }

        private string GetFunctionString()
        {
            switch (cmbEquationType.SelectedIndex)
            {
                case 0:
                    return $"{numA.Value}x² + {numB.Value}x + {numC.Value}";
                case 1:
                    return $"sin({numA.Value}x)/x";
                default:
                    return "Неизвестная функция";
            }
        }

        private void btnIntegrate_Click(object sender, EventArgs e)
        {
            if (currentEquation == null)
            {
                MessageBox.Show("Сначала постройте график функции", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                switch (cmbIntegratorType.SelectedIndex)
                {
                    case 0:
                        currentIntegrator = new RectangleIntegrator();
                        break;
                    case 1:
                        currentIntegrator = new TrapezoidalIntegrator();
                        break;
                }

                double result = currentIntegrator.Integrate(
                    currentEquation,
                    (double)numIntegralX1.Value,
                    (double)numIntegralX2.Value,
                    (int)numPartitions.Value);

                txtResult.Text = result.ToString("F6");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вычислении интеграла: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEquationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isQuadratic = cmbEquationType.SelectedIndex == 0;

            label2.Visible = isQuadratic;
            label3.Visible = isQuadratic;
            numB.Visible = isQuadratic;
            numC.Visible = isQuadratic;

            label1.Text = isQuadratic ? "Коэффициент a:" : "Коэффициент a:";
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (picGraph.Width > 0 && picGraph.Height > 0)
            {
                graphBitmap = new Bitmap(picGraph.Width, picGraph.Height);
                graphGraphics = Graphics.FromImage(graphBitmap);
                picGraph.Image = graphBitmap;
                if (currentEquation != null)
                    DrawFunctionGraph();
            }
        }
    }
}
