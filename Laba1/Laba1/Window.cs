﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;


namespace Laba1
{
    class Window: GameWindow
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(OpenTK.Graphics.Color4.CornflowerBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadMatrix(ref projection);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelView = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);

            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadMatrix(ref modelView);
            GL.PointSize(12);
            GL.Begin(PrimitiveType.LineLoop);

            GL.Vertex3(0.0f, 0.0f, 4.0f);
            GL.Vertex3(0.0f, 1.0f, 4.0f);
            GL.Vertex3(1.0f, 1.0f, 4.0f);
            GL.Vertex3(1.0f, 0.0f, 4.0f);

            GL.End();
            int z = 1;
            GL.Begin(PrimitiveType.LineLoop);
            for (int i = 0; i <=10; i++)
            {
                z = z ^ 1;
                GL.Vertex3(i/10f, z, 4.0f);
            }
            GL.End();

            SwapBuffers();
        }
    }
}
