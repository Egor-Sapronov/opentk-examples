using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Laba1Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int LineCount = 10;

        private GLControl glc;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            glc = new OpenTK.GLControl();

            glc.Load += glc_Load;
            glc.Paint += glc_Paint;
            glc.Resize += glc_Resize;

            Host.Child = glc;
        }
        void glc_Resize(object sender, EventArgs e)
        {
            double w = Host.Width;
            double h = Host.Height;
            GL.Viewport(glc.ClientRectangle);
            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadIdentity();
            GL.Ortho(0, 1, 0, 1, -1, 1);
            
        }
        void glc_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Color3(System.Drawing.Color.Yellow);

            int z = 1;
            GL.Begin(PrimitiveType.LineLoop);
            for (int i = 0; i <= LineCount; i++)
            {
                z = z ^ 1;
                GL.Vertex2((float)i/LineCount, (float)z);
            }
            GL.End();
            glc.SwapBuffers();
        }
        void glc_Load(object sender, EventArgs e)
        {
            GL.ClearColor(System.Drawing.Color.Black);

            double w = Host.Width;
            double h = Host.Height;

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, 1, 0, 1, -1, 1);
            GL.Viewport(0, 0, (int)w, (int)h);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LineCount = (int)e.NewValue;
            if(glc!=null)
            glc.Invalidate();
        }        
    }
}
