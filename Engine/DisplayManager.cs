using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using GLFW;
using static OpenGL.GL;

namespace NapicuEngine.Engine
{
    public class DisplayManager
    {
        public static Window Window { get; set; }
        public static Vector2 WindowSize { get; set; }

        public static void Creat(string title, int width, int height)
        {
            WindowSize = new Vector2(width, height);
            Glfw.Init();
            //OpenGL configuration
            Glfw.WindowHint(Hint.ClientApi, ClientApi.OpenGL);
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.Focused, true);
            Glfw.WindowHint(Hint.Resizable, true);
            //Creat window
            Window = Glfw.CreateWindow(width, height, title, GLFW.Monitor.None, Window.None);

            if (Window == Window.None)
            {
                return;
            }

            CenterWindowPosition(width, height);
            
            Glfw.MakeContextCurrent(Window);
            Import(Glfw.GetProcAddress);
            
            glViewport(0, 0, width, height);
            Glfw.SwapInterval(1);//TODO Vsync
        }

        protected static void CenterWindowPosition(int windowWidth, int windowHeight)
        {
            Rectangle screen = Glfw.PrimaryMonitor.WorkArea;
            int x = (screen.Width - windowWidth) / 2;
            int y = (screen.Height - windowHeight) / 2;
            Glfw.SetWindowPosition(Window, x, y);
        }

        public static void CloseWindow()
        {
            Glfw.Terminate();
        }


    } 
}
