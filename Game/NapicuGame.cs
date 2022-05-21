
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
        public Player _player;
        
        
        public NapicuGame(string title, int width, int height) : base(title, width, height)
        {

        }
        
        protected override void Update()
        {

            Keyboard.AddEventListener((int)GLFW.Keys.Space, () =>
            {
                this._player.Jump();
                return 0;
            }, true);
            

            
        }

        protected override void Render()
        { 
            glViewport(0, 0, Width, Height); 
            //glClearColor(MathF.Sin(EngineTime.TotalTime), 0, 0, 1);
           glClearColor(0, 0.568f, 1f, 1.0f);
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
            _player = new Player(500f, 500f, 100f, 100f);


            
        }
    }
    
}

