
using System.Collections;
using GLFW;

using Napicu.Engine;
using Napicu.Engine.Events;
using Napicu.Engine.Math;
using NapicuGame.Objects;
using OpenGL;
using static OpenGL.GL;
using Object = Napicu.Engine.Object;


namespace NapicuGame
{
    
    public class NapicuGame : Napicu.Engine.Engine
    {

        private Object _player;
        private Object _ground;
        
        public NapicuGame(string title, int width, int height) : base(title, width, height)
        {

        }
        
        protected override void Update()
        {
            if (Keyboard.IsKeyPressed((int)GLFW.Keys.W))
            {
                _player.Position = new Vector2f(0.5f, 0.5f);
            }
        }

        protected override void Render()
        { 
            glViewport(0, 0, Width, Height); 
            glClearColor(MathF.Sin(EngineTime.TotalTime), 0, 0, 1);
           //glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            glClear(GL_COLOR_BUFFER_BIT);
            _player.Render();
            _ground.Render();
            
            Glfw.SwapBuffers(DisplayManager.Window);
        }

        protected override void Init()
        {

        }

        protected override void LoadContent()
        {
            _player = new Square(0.25f, -0.5f, -0.5f);
            
            _ground = new Block(0.15f, 0.5f, -0.5f);

        }
    }
}

