using Napicu.Engine;
using Napicu.Engine.Math;

namespace NapicuGame.Objects{
    
    public class Pipe : GameObject
    {
        protected override VertexArray Mesh { get; set; }
        protected override float GravityForce { get; set; } = 0f;
        protected override float VelocityForce { get; set; } = 0f;
        protected override Texture Texture { get; set; } = new Texture("/Game/assets/pipe.png");


        public Pipe(float x, float y, float width, float height)
        {
            Position = new Vector2f(x, y);

            float [] pos = new float [] {
                // positions          // colors           // texture coords
                width,  height, 0.0f,   1.0f, 0.0f, 0.0f,   1.0f, 1.0f,   // top right
                width, -height, 0.0f,   0.0f, 1.0f, 0.0f,   1.0f, 0.0f,   // bottom right
                -width, -height, 0.0f,   0.0f, 0.0f, 1.0f,   0.0f, 0.0f,   // bottom left
                -width,  height, 0.0f,   1.0f, 1.0f, 0.0f,   0.0f, 1.0f    // top left 
            };

            int[] ints = new[]
            {
                0, 1, 3,
                1, 2, 3
            };
            
            Mesh = new VertexArray(pos, ints);
        }
    }
}