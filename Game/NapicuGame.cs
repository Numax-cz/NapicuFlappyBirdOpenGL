
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
        public Player _player;
        public Pipe[] _pipes = new Pipe[10];
        
        
        public NapicuGame(string title, int width, int height) : base(title, width, height)
        {

        }
        
        
        protected void UpdatePipes()
        {
            foreach (var pipe in _pipes)
            {
                pipe.Position.x -= 2.5f;
                //TODO Get width
                if (pipe.Position.x < 0)
                {
                    //pipe.SetX(1300);
                }
            }
        }


        protected void CreatPlayer()
        {
            _player = new Player(500f, 500f, 70, 70);
        }
        protected void CreatPipes()
        {
            for (int i = 0; i < 10; i += 2)
            {
                _pipes[i] = new Pipe(i * 300f, new Random().Next(50, 250), 70f, 250f);

                var top_pipe = new Pipe(_pipes[i].Position.x, _pipes[i].Position.y + 800f , 70f, 250f);
                top_pipe.Rotate = 180f;
                _pipes[i + 1] = top_pipe; 
            }
        }


        
        
        
        
        
        protected override void Update()
        {
            this.UpdatePipes();
            Keyboard.AddEventListener((int)GLFW.Keys.Space, () =>
            {
                this._player.Jump();
                return 0;
            }, true);
        }
        

    
        
        protected override void Render()
        { 

            glViewport(0, 0, Width, Height); 
            glClearColor(0, 0.568f, 1f, 1.0f);
            glClear(GL_COLOR_BUFFER_BIT);
            
            

            foreach (var pipe in _pipes)
            {
                pipe.Render();
            }
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

