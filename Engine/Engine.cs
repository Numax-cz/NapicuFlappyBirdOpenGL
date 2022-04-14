using GLFW;
using static OpenGL.GL;
using Monitor = GLFW.Monitor;

namespace Napicu.Engine
{
    public abstract class Engine
    {
        
        protected string Title { get; set; }
        protected int Width { get; set; }
        protected int Height { get; set; }
        

        public Engine(string title, int width, int height)
        {
            Title = title;
            Width = width;
            Height = height;
        }

        public void Run()
        {
            this.Init();
            
            DisplayManager.Creat(Title, Width, Height);
            
            this.LoadContent();

            while (!Glfw.WindowShouldClose(DisplayManager.Window))
            {
                EngineTime.DeltaTime = (float)Glfw.Time - EngineTime.TotalTime;
                EngineTime.TotalTime = (float)Glfw.Time;
                this.Update();

                Glfw.PollEvents();
                
                this.Render();
            }
            DisplayManager.CloseWindow();
        }
        
        protected abstract void Update();
        protected abstract void Render();
        protected abstract void Init();
        protected abstract  void LoadContent();
    }
}
