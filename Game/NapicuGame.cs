
using GLFW;
using NapicuEngine.Engine;
using NapicuEngine.Objects;
using static OpenGL.GL;

namespace NapicuEngine
{
    
    public class NapicuGame : Engine.Engine
    {

        private Square Player;
        
        public NapicuGame(string title, int width, int height) : base(title, width, height)
        {

        }
        
        protected override void Update()
        {
        
        }

        protected override void Render()
        {

           glClearColor(MathF.Sin(EngineTime.TotalTime), 0, 0, 1);
           //glClearColor(0.0f, 0.0f, 0.0f, 1.0f); 
           glClear(GL_COLOR_BUFFER_BIT);
             Player.Render();
            
            Glfw.SwapBuffers(DisplayManager.Window);
        }

        protected override void Init()
        {

        }

        protected override void LoadContent()
        {
            Player = new Square(0.25f, 0.5f, 0.0f);
        }
    }
}
