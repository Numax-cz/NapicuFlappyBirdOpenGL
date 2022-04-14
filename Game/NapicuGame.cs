
using System.Collections;
using GLFW;

using Napicu.Engine;
using Napicu.Engine.Events;
using Napicu.Engine.Math;
using NapicuGame.Objects;
using OpenGL;
using static OpenGL.GL;
using Object = Napicu.Engine.GameObject;


namespace NapicuGame
{
    
    public class NapicuGame : Napicu.Engine.Engine
    {

        private static Renderer _renderer = new Renderer();
        public Object _player;
        
        public NapicuGame(string title, int width, int height) : base(title, width, height)
        {

        }
        
        protected override void Update()
        {

        }

        protected override void Render()
        { 
            glViewport(0, 0, Width, Height); 
            glClearColor(MathF.Sin(EngineTime.TotalTime), 0, 0, 1);
           //glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            glClear(GL_COLOR_BUFFER_BIT);
            
            _player.Render();
            NapicuGame._renderer.Render();

            Glfw.SwapBuffers(DisplayManager.Window);
        }

        protected override void Init()
        {

        }

        protected override void LoadContent()
        {
             _player = new Square(150f, 50f, 300f);


        }
    }
}

