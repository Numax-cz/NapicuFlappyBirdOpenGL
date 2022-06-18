
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
        public Pipe[] _Pipes = new Pipe[10];
        
        
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

        protected void UpdatePipe()
        {
     

        }

        protected void CreatPipes()
        {
            for (int i = 0; i < 10; i += 2)
            {
                _renderer.Add(new Pipe(i * 300f, 40f, 100f, 200f));
                var top_pipe = new Pipe(_renderer.GetObjects()[i].Position.x, _renderer.GetObjects()[i].Position.y + 1050, 100f, 
                200f);
                top_pipe.Rotate = 180;
                _Pipes[i + 1] = top_pipe;
                _renderer.Add(top_pipe);
            }
        }


        protected void CreatPlayer()
        {
            _player = new Player(500f, 500f, 100f, 100f);
        }
        
        protected override void Render()
        { 

            glViewport(0, 0, Width, Height); 
            glClearColor(0, 0.568f, 1f, 1.0f);
            glClear(GL_COLOR_BUFFER_BIT);
            
            

            _renderer.Render();
            _player.Render();
                
            Glfw.SwapBuffers(DisplayManager.Window);

        }

        protected override void Init()
        {

        }

        protected override void LoadContent()
        {
            this.CreatPipes();
            this.CreatPlayer();
        }
    }
    
}

